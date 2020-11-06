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
    public class BMedLabTestMaster:HospitalBase
    {
        public decimal dec;
        public DateTime datetime;
        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                           new OracleParameter(":patientid",OracleType.VarChar),
                           new OracleParameter(":visitid",OracleType.VarChar)};
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] {
                          
                            new OleDbParameter("patientid",OleDbType.VarChar),
                            new OleDbParameter("visitid",OleDbType.VarChar), 
                        };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] {
                            new SqlParameter("@patientid",SqlDbType.VarChar),
                            new SqlParameter("@visitid",SqlDbType.VarChar)
                        };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] {
                            new OdbcParameter("patientid",OdbcType.VarChar),
                            new OdbcParameter("visitid",OdbcType.VarChar)
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
                InitDocare.LogA.Debug("同步检验信息：" + domain.Patient.PatientId);
                string PatientId = domain.Patient.PatientId;
                if (!domain.Patient.VisitId.HasValue)
                {
                    domain.Patient.VisitId = 1;
                    // return "visitid 为空";
                }

               
                decimal VisitId = domain.Patient.VisitId.Value;
                InitDocare.LogA.Debug("同步检验信息PatientId ：" + domain.Patient.PatientId + " VisitId:" + VisitId);
                MedVsHisPat vspat = SelectMedVsHisPat(PatientId, VisitId);
                if (vspat == null)
                {
                    vspat = new MedVsHisPat();
                    vspat.HisPatientId = PatientId;
                    vspat.HisVisitId = PatientId.ToString();
                }
                domain.Patient.InpNo = vspat.HisInpNo ;
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                InitDocare.LogDALA.Debug("Count：" + sql.Count);
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);

                    DbParameter[] para = GetPara(oneTransEntity.Dbms);
                    para[0].Value = vspat.HisPatientId;   //todo 多个参数动态怎么解决
                    para[1].Value = vspat.HisVisitId;
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogDALA.Debug("sqlDDL：" + sqlDDL);
                    LogA.Debug("para[0].Value:" + para[0].Value);
                    LogA.Debug("para[1].Value:" + para[1].Value);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogDALA.Debug("ds：" + ds.GetXml());
                    DataTable dt = ds.Tables[0];
                    dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.LabTestMaster);

                    List<MedLabTestMaster> labTestMasterList = GetMedLabTestMasterList(dt);
                    if (labTestMasterList.Count == 0)
                    {
                        return "没有查询到检验信息";
                    }
                    foreach (MedLabTestMaster oneLabTestMaster in labTestMasterList)
                    {
               
                        oneLabTestMaster.PatientId = domain.Patient.PatientId;
                        oneLabTestMaster.VisitId = domain.Patient.VisitId.Value;
                        ReturnMessage += DoExecute(config, domain, oneLabTestMaster);

                        BMedLabResult labResult = new BMedLabResult();
                        domain.LabTest = new Init.LabTest() { TestNo = oneLabTestMaster.TestNo };
                        domain.Code = "LIS901";
                        ReturnMessage += labResult.PreDataBase(config, domain);
                    }
                }
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据");
                return ex.Message;
            }
        }

        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            return base.PreReceiveMsg(config, domain);
        }

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {

            string labmess = Anterface.GetPatientLabTestMaster(domain.Patient.InpNo);

            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(labmess))
            {
                ds.ReadXml(sr);
            }
            DataTable dt = ds.Tables[0];
            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.LabTestMaster);

            List<MedLabTestMaster> labTestMasterList = GetMedLabTestMasterList(dt);

            foreach (MedLabTestMaster oneLabTestMaster in labTestMasterList)
            {
                oneLabTestMaster.PatientId = domain.Patient.PatientId;
                oneLabTestMaster.VisitId = domain.Patient.VisitId.Value;
                ReturnMessage += DoExecute(config, domain, oneLabTestMaster);

                BMedLabResult labResult = new BMedLabResult();
                domain.LabTest = new Init.LabTest() { TestNo = oneLabTestMaster.TestNo };
                ReturnMessage += labResult.PreDataBase(config, domain);
            }
            return ReturnMessage;
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                if (!(obj is MedLabTestMaster))
                {
                    return "obj is not MedLabTestMaster " + obj.ToString();
                }

                MedLabTestMaster oneMedLabTestMaster = obj as MedLabTestMaster;

                if (UpdateMedLabTestMaster(oneMedLabTestMaster) == 0)
                    InsertMedLabTestMaster(oneMedLabTestMaster);
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
