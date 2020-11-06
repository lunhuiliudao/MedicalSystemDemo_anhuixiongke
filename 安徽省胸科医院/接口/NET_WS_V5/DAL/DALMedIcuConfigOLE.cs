

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:09
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
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
using System.Xml;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedIcuConfig
	/// </summary>
	
	public partial class DALMedIcuConfig
	{
        private static readonly string MED_ICU_CONFIG_Select_OLE = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG WHERE CONFIG_ID = ?";
        private static readonly string MED_ICU_CONFIG_Select_ALL_OLE = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG;";


        #region [获取参数]
        /// <summary>
        ///获取参数MedIcuConfig
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIcuConfig")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("WardCode",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedIcuConfig 
        ///select Table MED_ICU_CONFIG by (string DEPT_CODE)
        /// </summary>
        public MedIcuConfig SelectMedIcuConfigOLE(string WARD_CODE)
        {
            MedIcuConfig model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedIcuConfig");
            parameterValues[0].Value = WARD_CODE;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedIcuConfig();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.ConfigId = decimal.Parse(oleReader["CONFIG_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.AuditingCondition = oleReader["AUDITING_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        string dept = oleReader["DEPT"].ToString().Trim();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(dept);
                        model.Dept = doc.GetElementsByTagName("txtDefault")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtReal")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtTimes")[0].InnerXml.Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrdersInMount = oleReader["ORDERS_IN_MOUNT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.SpecialCare = oleReader["SPECIAL_CARE"].ToString().Trim();
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
        public List<MedIcuConfig> SelectMedIcuConfigListOLE()
        {
            List<MedIcuConfig> modelList = new List<MedIcuConfig>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedIcuConfig model = new MedIcuConfig();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.ConfigId = decimal.Parse(oleReader["CONFIG_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.AuditingCondition = oleReader["AUDITING_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        string dept = oleReader["DEPT"].ToString().Trim();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(dept);
                        model.Dept = doc.GetElementsByTagName("txtDefault")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtReal")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtTimes")[0].InnerXml.Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrdersInMount = oleReader["ORDERS_IN_MOUNT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.SpecialCare = oleReader["SPECIAL_CARE"].ToString().Trim();
                    }
                }
            }
            return modelList;
        }
        #endregion	



        private static readonly string MED_ICU_CONFIG_Select_ODBC = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG WHERE CONFIG_ID = ?";
        private static readonly string MED_ICU_CONFIG_Select_ALL_ODBC = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG;";
        
        #region [获取参数]
        /// <summary>
        ///获取参数MedIcuConfig
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIcuConfig")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("WardCode",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedIcuConfig 
        ///select Table MED_ICU_CONFIG by (string DEPT_CODE)
        /// </summary>
        public MedIcuConfig SelectMedIcuConfigODBC(string WARD_CODE)
        {
            MedIcuConfig model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedIcuConfig");
            parameterValues[0].Value = WARD_CODE;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedIcuConfig();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.ConfigId = decimal.Parse(oleReader["CONFIG_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.AuditingCondition = oleReader["AUDITING_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        string dept = oleReader["DEPT"].ToString().Trim();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(dept);
                        model.Dept = doc.GetElementsByTagName("txtDefault")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtReal")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtTimes")[0].InnerXml.Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrdersInMount = oleReader["ORDERS_IN_MOUNT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.SpecialCare = oleReader["SPECIAL_CARE"].ToString().Trim();
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
        public List<MedIcuConfig> SelectMedIcuConfigListODBC()
        {
            List<MedIcuConfig> modelList = new List<MedIcuConfig>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedIcuConfig model = new MedIcuConfig();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.ConfigId = decimal.Parse(oleReader["CONFIG_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.AuditingCondition = oleReader["AUDITING_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        string dept = oleReader["DEPT"].ToString().Trim();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(dept);
                        model.Dept = doc.GetElementsByTagName("txtDefault")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtReal")[0].InnerXml.Trim() + ';' + doc.GetElementsByTagName("txtTimes")[0].InnerXml.Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrdersInMount = oleReader["ORDERS_IN_MOUNT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.SpecialCare = oleReader["SPECIAL_CARE"].ToString().Trim();
                    }
                }
            }
            return modelList;
        }
        #endregion	
		
	}
}
