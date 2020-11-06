

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
using MedicalSytem.Soft.Model;
using System.Xml;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedIcuConfig
	/// </summary>
	
	public partial class DALMedIcuConfig
	{
        private static readonly string MED_ICU_CONFIG_Select = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG WHERE CONFIG_ID = :WardCode";
        private static readonly string MED_ICU_CONFIG_Select_ALL = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG;";
        public DALMedIcuConfig()
        {
        }
        #region [获取参数]
        /// <summary>
        ///获取参数MedIcuConfig
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIcuConfig")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedIcuConfig 
        ///select Table MED_ICU_CONFIG by (string DEPT_CODE)
        /// </summary>
        public MedIcuConfig SelectMedIcuConfig(string WARD_CODE)
        {
            MedIcuConfig model;
            OracleParameter[] parameterValues = GetParameter("SelectMedIcuConfig");
            parameterValues[0].Value = WARD_CODE;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select, parameterValues))
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
        public List<MedIcuConfig> SelectMedIcuConfigList()
        {
            List<MedIcuConfig> modelList = new List<MedIcuConfig>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select_ALL, null))
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







        private static readonly string MED_ICU_CONFIG_Select_SQL = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG WHERE CONFIG_ID = @WardCode";
        private static readonly string MED_ICU_CONFIG_Select_ALL_SQL = "SELECT CONFIG_ID,AUDITING_CONDITION,DEPT,ORDERS_IN_MOUNT,SPECIAL_CARE FROM MED_ICU_CONFIG;";
        
        #region [获取参数]
        /// <summary>
        ///获取参数MedIcuConfig
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIcuConfig")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedIcuConfig 
        ///select Table MED_ICU_CONFIG by (string DEPT_CODE)
        /// </summary>
        public MedIcuConfig SelectMedIcuConfigSQL(string WARD_CODE)
        {
            MedIcuConfig model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedIcuConfig");
            parameterValues[0].Value = WARD_CODE;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select_SQL, parameterValues))
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
        public List<MedIcuConfig> SelectMedIcuConfigListSQL()
        {
            List<MedIcuConfig> modelList = new List<MedIcuConfig>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_ICU_CONFIG_Select_ALL_SQL, null))
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
