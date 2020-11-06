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
    public class BMedScheduleOperationName : HospitalBase
    {

        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                           new OracleParameter(":patientId",OracleType.VarChar),
                           new OracleParameter(":visitId",OracleType.VarChar),
                           new OracleParameter(":scheduleId",OracleType.VarChar)
                        };
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] {

                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.VarChar),
                             new OleDbParameter("scheduleId",OleDbType.VarChar)
                        };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] {
                            new SqlParameter("@patientId",SqlDbType.VarChar),
                            new SqlParameter("@visitId",SqlDbType.VarChar),
                            new SqlParameter("@scheduleId",SqlDbType.VarChar)
                        };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] {
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.VarChar),
                            new OdbcParameter("scheduleId",OdbcType.VarChar)
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

                InitDocare.LogDALA.Debug("开始同步手术名称信息 入参 Code:" + domain.Code);
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
                    para[0].Value = domain.Patient.PatientId;   //todo 多个参数动态怎么解决
                    para[1].Value = domain.Operation.HisVisitId;
                    para[2].Value = domain.Operation.HisScheduleId;
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogDALA.Debug("sqlDDL:" + sqlDDL);
                    // para[2].Value = domain.Operation.HisScheduleId;
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogDALA.Debug("ds" + ds.GetXml());
                    DataTable dt = ds.Tables[0];

                    //dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.ScheduleOperationName);

                    List<MedScheduledOperationName> scheduleOperationNameList = GetMedScheduledOperationName(dt);
                    MedOperationSchedule schedule = config.obj as MedOperationSchedule;
                    int i = 0;
                    foreach (MedScheduledOperationName entity in scheduleOperationNameList)
                    {
                        schedule.OperationName += entity.OperName;
                        entity.PatientId = domain.Patient.PatientId;
                        entity.VisitId = domain.Patient.VisitId.Value;
                        entity.ScheduleId = domain.Operation.ScheduleId.Value;
                        ReturnMessage += DoExecute(config, domain, entity);
                    }

                    UpdateMedOperationSchedule(schedule);
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
            try
            {
                if (!(obj is MedScheduledOperationName))
                {
                    return "异常";
                }
                MedScheduledOperationName oneMedScheduleOperationName = obj as MedScheduledOperationName;

                if (UpdateMedScheduleOperationName(oneMedScheduleOperationName) == 0)
                    InsertMedScheduleOperationName(oneMedScheduleOperationName);
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
