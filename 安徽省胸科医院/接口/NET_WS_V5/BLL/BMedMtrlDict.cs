using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Data.Common;
using System.Data;
using NET_WS_V5;
using MedicalSytem.Soft.Model;
using InitDocare;


namespace BLL
{
    public class BMedMtrlDict : HospitalBase
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
                        return "没有查询到耗材字典";
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
            string mess = WebService.DoCareInterFaceInput(domain.Reserved1, domain.Reserved2);
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(mess))
            {
                ds.ReadXml(sr);
            }
            DataTable dt = ds.Tables[0];
            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.LabResult);

            List<MedLabResult> labResultList = GetMedLabTestResultList(dt);
            // int i = 1;
            foreach (MedLabResult oneMedLabResult in labResultList)
            {

                ReturnMessage += DoExecute(config, domain, oneMedLabResult);
            }
            return ReturnMessage;
        }

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(domain.ReceiveMessage))
            {
                ds.ReadXml(sr);
            }
            DataTable dt = ds.Tables[0];
            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.LabResult);

            List<MedLabResult> labResultList = GetMedLabTestResultList(dt);
            foreach (MedLabResult oneMedLabResult in labResultList)
            {
                ReturnMessage += DoExecute(config, domain, oneMedLabResult);
            }
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
                    string spec = dr["MTRL_SPEC"].ToString();
                    if (string.IsNullOrEmpty(spec))
                    {
                        spec = dr["UNITS"].ToString();

                        if (string.IsNullOrEmpty(spec))
                        {
                            continue;
                        }
                    }

                    sqlInsert += @"insert into med_mtrl_dict(MTRL_CODE,MTRL_NAME,MTRL_SPEC,UNITS,MTRL_CLASS,CODE_IN_HIS,INPUT_CODE)
                     values('" + dr["MTRL_CODE"].ToString().Replace("'", "") + "','" + dr["MTRL_NAME"].ToString().Replace("'", "") + "','" + spec.Replace("'", "") + "','" + dr["UNITS"].ToString().Replace("'", "") + "','" + dr["MTRL_CLASS"].ToString().Replace("'", "") + @"',
                   '" + dr["CODE_IN_HIS"].ToString().Replace("'", "") + "','" + dr["INPUT_CODE"].ToString().Replace("'", "") + "');";
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
                        string sql = "Delete from med_mtrl_dict";

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
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return ex.Message;
            }
        }

    }
}
