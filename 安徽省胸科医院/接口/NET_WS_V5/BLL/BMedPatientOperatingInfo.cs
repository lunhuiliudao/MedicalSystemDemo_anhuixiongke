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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedPatientOperatingInfo : HospitalBase
    {
        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                            new OracleParameter(":inpno", OracleType.VarChar),};
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] { new OleDbParameter("inpno", OleDbType.VarChar), };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] { new SqlParameter("@inpno", SqlDbType.VarChar), };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] { new OdbcParameter("inpno", OdbcType.VarChar), };
                    }
                    break;
            }
            return parms;
        }

        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("开始准备数据....");

                InitDocare.LogA.Debug("domain.Patient.PatientId" + domain.Patient.PatientId + "domain.Patient.VisitId" + domain.Patient.VisitId.Value + "Inpnp;" + domain.Patient.InpNo);

                MedPatsInHospital hos = SelectMedPatsInHospital(domain.Patient.PatientId, domain.Patient.VisitId.Value);
                if (hos == null)
                {
                    hos = new MedPatsInHospital();
                    string sqltemp = "select inp_no from med_pat_inicu_information where patient_id='" + domain.Patient.PatientId + "' and VISIT_ID=" + domain.Patient.VisitId.Value + "";
                    DataSet ds = IDataBase.SelectDataBase(EnumDataBase.ORACLE).GetDataSet(CommandType.Text, sqltemp, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hos.InpNo = ds.Tables[0].Rows[0][0].ToString();
                        InitDocare.LogA.Debug("hos.InpNo:" + hos.InpNo);
                    }
                }
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                DataSet dsResult = new DataSet();
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);
                    DbParameter[] para = GetPara(oneTransEntity.Dbms);
                    para[0].Value = hos.InpNo;   //todo 多个参数动态怎么解决(组合)
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogA.Debug("ds:" + ds.GetXml());
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string sqlInsert = @"Insert into med_patient_operating_info(PATIENT_ID,VISIT_ID,DEP_ID,OPERATING_NAME,OPERATING_DATE,OPERATOR_TIME,OPERATOR,ID) 
                        values('" + domain.Patient.PatientId + "','" + domain.Patient.VisitId + "','" + domain.Patient.DEP_ID + "','" + dr["OPERATING_NAME"].ToString() + "',to_date('" + dr["OPERATING_DATE"].ToString() + "','yyyy-MM-dd HH24:mi:ss'), sysdate,'','" + dr["id"].ToString() + "')";

                        string update = "Update med_patient_operating_info set OPERATING_DATE=to_date('" + dr["OPERATING_DATE"].ToString() + "','yyyy-MM-dd HH24:mi:ss'),OPERATING_NAME='" + dr["OPERATING_NAME"].ToString() + "',OPERATOR_TIME=sysdate where ID='" + dr["id"].ToString() + "' ";

                        if (IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(CommandType.Text, update, null, null) == 0)
                            IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(CommandType.Text, sqlInsert, null, null);

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
            return base.PreReceiveMsg(config, domain);
        }

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            return base.PreWebServices(config, domain);
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            return base.DoExecute(config, domain, obj);
        }
    }
}
