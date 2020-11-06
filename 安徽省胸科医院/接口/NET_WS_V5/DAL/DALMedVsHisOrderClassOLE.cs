

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:12
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
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;


namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedVsHisOrderClass
    /// </summary>

    public partial class DALMedVsHisOrderClass
    {

        private static readonly string MED_VS_HIS_ORDER_CLASS_Insert_ODBC = "INSERT INTO MED_VS_HIS_ORDER_CLASS (SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME) values (?,?,?,?,?)";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Update_ODBC = "UPDATE MED_VS_HIS_ORDER_CLASS SET SERIAL_NO=?,HIS_CLASS_CODE=?,HIS_CLASS_NAME=?,MED_CLASS_CODE=?,MED_CLASS_NAME=? WHERE HIS_CLASS_CODE=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Delete_ODBC = "Delete MED_VS_HIS_ORDER_CLASS WHERE HIS_CLASS_CODE=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Select_ODBC = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_CODE=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select_ODBC = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_NAME=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Select_ALL_ODBC = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS";
        
        private static readonly string MED_VS_HIS_ORDER_CLASS_Insert_OLE = "INSERT INTO MED_VS_HIS_ORDER_CLASS (SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME) values (?,?,?,?,?)";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Update_OLE = "UPDATE MED_VS_HIS_ORDER_CLASS SET SERIAL_NO=:,HIS_CLASS_CODE=:,HIS_CLASS_NAME=:,MED_CLASS_CODE=:,MED_CLASS_NAME=? WHERE HIS_CLASS_CODE=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Delete_OLE = "Delete MED_VS_HIS_ORDER_CLASS WHERE HIS_CLASS_CODE=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Select_OLE = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_CODE=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select_OLE = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_NAME=?";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Select_ALL_OLE = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS";
        //public DALMedVsHisOrderClass()
        //{
        //}
        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedVsHisOrderClass SQL
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrderClass")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("SerialNo",OdbcType.Decimal),
							new OdbcParameter("HisClassCode",OdbcType.VarChar),
							new OdbcParameter("HisClassName",OdbcType.VarChar),
							new OdbcParameter("MedClassCode",OdbcType.VarChar),
							new OdbcParameter("MedClassName",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOrderClass")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("SerialNo",OdbcType.Decimal),
							new OdbcParameter("HisClassCode",OdbcType.VarChar),
							new OdbcParameter("HisClassName",OdbcType.VarChar),
							new OdbcParameter("MedClassCode",OdbcType.VarChar),
							new OdbcParameter("MedClassName",OdbcType.VarChar),
							new OdbcParameter("HisClassCode",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisOrderClass")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("HisClassCode",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrderClass")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("HisClassCode",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrderClassHisClassName")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("HisClassName",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedVsHisOrderClass 
        ///Insert Table MED_VS_HIS_ORDER_CLASS
        /// </summary>
        public int InsertMedVsHisOrderClassODBC(MedVsHisOrderClass model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedVsHisOrderClass");
                if (model.SerialNo.ToString() != null)
                    oneInert[0].Value = model.SerialNo;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.HisClassCode != null)
                    oneInert[1].Value = model.HisClassCode;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.HisClassName != null)
                    oneInert[2].Value = model.HisClassName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.MedClassCode != null)
                    oneInert[3].Value = model.MedClassCode;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.MedClassName != null)
                    oneInert[4].Value = model.MedClassName;
                else
                    oneInert[4].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString,CommandType.Text, MED_VS_HIS_ORDER_CLASS_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录ODBC]
        /// <summary>
        ///Update    model  MedVsHisOrderClass 
        ///Update Table     MED_VS_HIS_ORDER_CLASS
        /// </summary>
        public int UpdateMedVsHisOrderClassODBC(MedVsHisOrderClass model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedVsHisOrderClass");
                if (model.SerialNo.ToString() != null)
                    oneUpdate[0].Value = model.SerialNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.HisClassCode != null)
                    oneUpdate[1].Value = model.HisClassCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.HisClassName != null)
                    oneUpdate[2].Value = model.HisClassName;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.MedClassCode != null)
                    oneUpdate[3].Value = model.MedClassCode;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.MedClassName != null)
                    oneUpdate[4].Value = model.MedClassName;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.HisClassCode != null)
                    oneUpdate[5].Value = model.HisClassCode;
                else
                    oneUpdate[5].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString,CommandType.Text, MED_VS_HIS_ORDER_CLASS_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录ODBC]
        /// <summary>
        ///Delete    model  MedVsHisOrderClass 
        ///Delete Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
        /// </summary>
        public int DeleteMedVsHisOrderClassODBC(string HIS_CLASS_CODE)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedVsHisOrderClass");
                if (HIS_CLASS_CODE != null)
                    oneDelete[0].Value = HIS_CLASS_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录ODBC]
        /// <summary>
        ///Select    model  MedVsHisOrderClass 
        ///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
        /// </summary>
        public MedVsHisOrderClass SelectMedVsHisOrderClassODBC(string HIS_CLASS_CODE)
        {
            MedVsHisOrderClass model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedVsHisOrderClass");
            parameterValues[0].Value = HIS_CLASS_CODE;
            decimal dc;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
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
        public List<MedVsHisOrderClass> SelectMedVsHisOrderClassListODBC()
        {
            List<MedVsHisOrderClass> modelList = new List<MedVsHisOrderClass>();
            decimal dc;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisOrderClass model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录SQL-HisClassName]
        /// <summary>
        ///Select    model  MedVsHisOrderClass 
        ///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_NAME)
        /// </summary>
        public MedVsHisOrderClass SelectMedVsHisOrderClassHisClassNameODBC(string HIS_CLASS_NAME)
        {
            MedVsHisOrderClass model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedVsHisOrderClassHisClassName");
            parameterValues[0].Value = HIS_CLASS_NAME;
            decimal dc;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
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
        ///获取参数MedVsHisOrderClass
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrderClass")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("SerialNo",OleDbType.Decimal),
						new OleDbParameter("HisClassCode",OleDbType.VarChar),
						new OleDbParameter("HisClassName",OleDbType.VarChar),
						new OleDbParameter("MedClassCode",OleDbType.VarChar),
						new OleDbParameter("MedClassName",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOrderClass")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("SerialNo",OleDbType.Decimal),
						new OleDbParameter("HisClassCode",OleDbType.VarChar),
						new OleDbParameter("HisClassName",OleDbType.VarChar),
						new OleDbParameter("MedClassCode",OleDbType.VarChar),
						new OleDbParameter("MedClassName",OleDbType.VarChar),
						new OleDbParameter("HisClassCode",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisOrderClass")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("HisClassCode",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrderClass")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("HisClassCode",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrderClassHisClassName")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("HisClassName",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedVsHisOrderClass 
        ///Insert Table MED_VS_HIS_ORDER_CLASS
        /// </summary>
        public int InsertMedVsHisOrderClassOLE(MedVsHisOrderClass model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedVsHisOrderClass");
                if (model.SerialNo.ToString() != null)
                    oneInert[0].Value = model.SerialNo;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.HisClassCode != null)
                    oneInert[1].Value = model.HisClassCode;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.HisClassName != null)
                    oneInert[2].Value = model.HisClassName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.MedClassCode != null)
                    oneInert[3].Value = model.MedClassCode;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.MedClassName != null)
                    oneInert[4].Value = model.MedClassName;
                else
                    oneInert[4].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedVsHisOrderClass 
        ///Update Table     MED_VS_HIS_ORDER_CLASS
        /// </summary>
        public int UpdateMedVsHisOrderClassOLE(MedVsHisOrderClass model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedVsHisOrderClass");
                if (model.SerialNo.ToString() != null)
                    oneUpdate[0].Value = model.SerialNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.HisClassCode != null)
                    oneUpdate[1].Value = model.HisClassCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.HisClassName != null)
                    oneUpdate[2].Value = model.HisClassName;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.MedClassCode != null)
                    oneUpdate[3].Value = model.MedClassCode;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.MedClassName != null)
                    oneUpdate[4].Value = model.MedClassName;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.HisClassCode != null)
                    oneUpdate[5].Value = model.HisClassCode;
                else
                    oneUpdate[5].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedVsHisOrderClass 
        ///Delete Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
        /// </summary>
        public int DeleteMedVsHisOrderClassOLE(string HIS_CLASS_CODE)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedVsHisOrderClass");
                if (HIS_CLASS_CODE != null)
                    oneDelete[0].Value = HIS_CLASS_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedVsHisOrderClass 
        ///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
        /// </summary>
        public MedVsHisOrderClass SelectMedVsHisOrderClassOLE(string HIS_CLASS_CODE)
        {
            MedVsHisOrderClass model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVsHisOrderClass");
            parameterValues[0].Value = HIS_CLASS_CODE;
            decimal dc;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
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
        public List<MedVsHisOrderClass> SelectMedVsHisOrderClassListOLE()
        {
            List<MedVsHisOrderClass> modelList = new List<MedVsHisOrderClass>();
            decimal dc;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisOrderClass model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录-HisClassName]
        /// <summary>
        ///Select    model  MedVsHisOrderClass 
        ///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_NAME)
        /// </summary>
        public MedVsHisOrderClass SelectMedVsHisOrderClassHisClassNameOLE(string HIS_CLASS_NAME)
        {
            MedVsHisOrderClass model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVsHisOrderClassHisClassName");
            parameterValues[0].Value = HIS_CLASS_NAME;
            decimal dc;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
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
