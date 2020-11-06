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
    public class BMedPatientDiagnosis:HospitalBase
    {

        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                           new OracleParameter(":inpno",OracleType.VarChar),};
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] {
                          
                            new OleDbParameter("inpno",OleDbType.VarChar),
                      
                        };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] {
                            new SqlParameter("@inpno",SqlDbType.VarChar),
                       
                        };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] {
                            new OdbcParameter("inpno",OdbcType.VarChar),
                         
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
                InitDocare.LogA.Debug("开始准备同步数据诊断信息......" + PublicParmDoamin.ParaDomainToString(domain));
              
                MedPatsInHospital hos = SelectMedPatsInHospital(domain.Patient.PatientId, domain.Patient.VisitId.Value);
                if (hos == null)
                {
                    hos = new MedPatsInHospital();
                    hos.InpNo = domain.Patient.InpNo;
                }
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                InitDocare.LogA.Debug("viewSqlCount:" + sql.Count);
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);
                    DbParameter[] para = GetPara(oneTransEntity.Dbms);
                    para[0].Value = hos.InpNo;  //todo 多个参数动态怎么解决
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogA.Debug("sql" + sqlDDL);
                    InitDocare.LogA.Debug("inpno"+hos.InpNo);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogA.Debug("ds:" + ds.GetXml());
                    DataTable dt = ds.Tables[0];
                    config.obj = dt;
                    ReturnMessage = DoExecute(config, domain, null);
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
                foreach (DataRow dr in dt.Rows)
                {
                    string id = domain.Patient.PatientId + domain.Patient.VisitId.Value + DateTime.Parse(dr["DATE1"].ToString()).ToString("yyyyMMddHHmm");
                    string insert = @"Insert into MED_PATIENT_DIAGNOSIS_INFO(PATIENT_ID,VISIT_ID,DEP_ID,DIAGNOSIS,RECORDING_DATE,DIAGNOSIS_OPERATOR,OPERATOR_TIME,OPERATOR,ID) 
                               values('" + domain.Patient.PatientId + "','" + domain.Patient.VisitId.Value  + "','" + domain.Patient.DEP_ID + "','" + dr["DIAGNOSIS"].ToString() + "',to_date('" + dr["DATE1"].ToString() + "','yyyy-MM-dd HH24:mi:ss'),'" + dr["DIAGNOSIS_OPERATOR"].ToString() + "',sysdate,'" + domain.OperatorBase.Operator + "','" + id + "')";

                    string update = "Update MED_PATIENT_DIAGNOSIS_INFO set PATIENT_ID='" + domain.Patient.PatientId + "',VISIT_ID='" + domain.Patient.VisitId + "',DEP_ID='" + domain.Patient.DEP_ID + "',DIAGNOSIS='" + dr["DIAGNOSIS"].ToString() + "',RECORDING_DATE=to_date('" + dr["DATE1"].ToString() + "','yyyy-MM-dd HH24:mi:ss'),DIAGNOSIS_OPERATOR='" + dr["DIAGNOSIS_OPERATOR"].ToString() + "',OPERATOR_TIME=sysdate,OPERATOR='" + dr["OPERATOR"].ToString() + "' where ID='" + id + "'";

                    InitDocare.LogA.Debug("insert:" + insert);
                    InitDocare.LogA.Debug("update:" + update);
                    if (IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(CommandType.Text, update, null) == 0)
                        IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(CommandType.Text, insert, null);
                }
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据");
                return ex.Message;
            }
        }
    }
}
