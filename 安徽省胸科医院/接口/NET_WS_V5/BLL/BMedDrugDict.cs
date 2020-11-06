using InitDocare;
using MedicalSytem.Soft.Model;
using NET_WS_V5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedDrugDict:HospitalBase
    {

        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                           new OracleParameter(":testno",OracleType.VarChar),};
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] {
                          
                            new OleDbParameter("testno",OleDbType.VarChar),
                      
                        };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] {
                            new SqlParameter("@testno",SqlDbType.VarChar),
                       
                        };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] {
                            new OdbcParameter("testno",OdbcType.VarChar),
                         
                        };
                    }
                    break;
            }
            return parms;
        }

        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);

                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, temp.SqlText, oneTransEntity.Dbparm, null);
                    InitDocare.LogA.Debug("ds:" + ds.GetXml());
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        return "没有查询到药品字典";
                    }
                    config.obj = dt;
                    return DoExecute(config, domain, null);
                 
                }
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return ex.Message;
            }
        }

        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
          
            return ReturnMessage;
        }

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        { 
            return ReturnMessage;
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                DataTable dt = config.obj as DataTable;
                if (dt == null)
                {
                    return "没有查询到数据";
                }
                string sqlInsert = "";
                foreach (DataRow dr in dt.Rows)
                {
                    sqlInsert += @"insert into med_drug_dict(DRUG_CODE,DRUG_NAME,DRUG_SPEC,UNITS,DRUG_FORM,SUPPLIER_NAME,DOSE_PER_UNIT,DOSE_UNITS,DRUG_CLASS,ANESTHETIC_CLASS,CODE_IN_HIS,INPUT_CODE)
                     values('" + dr["DRUG_CODE"].ToString().Replace("'", "") + "','" + dr["DRUG_NAME"].ToString().Replace("'", "") + "','" + dr["DRUG_SPEC"].ToString().Replace("'", "") + "','" + dr["UNITS"].ToString().Replace("'", "") + "','" + dr["DRUG_FORM"].ToString().Replace("'", "") + @"',
                   '" + dr["SUPPLIER_NAME"].ToString().Replace("'", "") + "','" + dr["DOSE_PER_UNIT"].ToString().Replace("'", "") + "','" + dr["DOSE_UNITS"].ToString().Replace("'", "") + "','" + dr["DRUG_CLASS"].ToString().Replace("'", "") + "','" + dr["ANESTHETIC_CLASS"].ToString().Replace("'", "") + "','" + dr["CODE_IN_HIS"].ToString().Replace("'", "") + "','" + dr["INPUT_CODE"].ToString().Replace("'", "") + "');";
                }

                using (OracleConnection conn = new OracleConnection(IDataBase.SelectDataBase(EnumDataBase.ORACLE).Connection))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    OracleTransaction ots = conn.BeginTransaction();
                    try
                    {
                        string sql = "Delete from med_drug_dict";

                        sqlInsert = "begin " + sqlInsert + " end;";
                        IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(ots, CommandType.Text, sql);
                        IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(ots, CommandType.Text, sqlInsert);
                        ots.Commit();
                    }
                    catch (Exception ex)
                    {
                        ots.Rollback();
                        conn.Dispose();
                        throw ex;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据\r\n");
                return ex.Message;
            }
        }
    }
}
