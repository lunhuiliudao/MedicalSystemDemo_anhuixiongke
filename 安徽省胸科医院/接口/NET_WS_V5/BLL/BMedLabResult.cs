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
    public class BMedLabResult:HospitalBase
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
                    DbParameter[] para = GetPara(oneTransEntity.Dbms);
                    para[0].Value = domain.LabTest.TestNo;  //todo 多个参数动态怎么解决
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    DataTable dt = ds.Tables[0];
                    dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.LabResult);
                    List<MedLabResult> labResultList = GetMedLabTestResultList(dt);
                    foreach (MedLabResult oneMedLabResult in labResultList)
                    {
                        DoExecute(config, domain, oneMedLabResult);
                    }
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
            int i = 1;
            foreach (MedLabResult oneMedLabResult in labResultList)
            {
              
                ReturnMessage += DoExecute(config, domain, oneMedLabResult);
            }
            return ReturnMessage;
        }

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {

            string mes= Anterface.GetLabTestResult(domain.LabTest.TestNo);

            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(mes))
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
                if (!(obj is MedLabResult))
                {
                    return "异常";
                }

                MedLabResult oneMedLabResult = obj as MedLabResult;

                if (UpdateMedLabResult(oneMedLabResult) == 0)
                    InsertMedLabResult(oneMedLabResult);
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据" + obj.ToString() + "\r\n");
                return ex.Message;
            }
        }
    }
}
