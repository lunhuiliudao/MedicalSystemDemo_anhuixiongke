using InitDocare;
using MedicalSytem.Soft.DAL;
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

namespace BLL
{
    /// <summary>
    /// 同步患者的术前访视单中的部分体征数据：体温，脉搏等
    /// </summary>
    public class BAnesVisitClinicalInfo:HospitalBase
    {
        /// <summary>
        /// 查询SQL的参数
        /// </summary>
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
                            new SqlParameter("@patientid",SqlDbType.VarChar)
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

        /// <summary>
        /// 执行SQL语句。需要链接到其他数据库
        /// </summary>
        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("PAT201,同步术前访视的体征信息。");
                string PatientId = domain.Patient.PatientId;
                if (!domain.Patient.VisitId.HasValue)
                {
                    domain.Patient.VisitId = 1;
                }

                if(!domain.Operation.OperId.HasValue)
                {
                    domain.Operation.OperId = 1;
                }

                decimal VisitId = domain.Patient.VisitId.Value;
                decimal operID = domain.Operation.OperId.Value;
                InitDocare.LogA.Debug("PAT201,同步术前访视的体征信息：Patient_ID:" + domain.Patient.PatientId + " VisitId:" + VisitId + "OperID:" + operID);
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
                    para[0].Value = PatientId;   //todo 多个参数动态怎么解决
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogDALA.Debug("sqlDDL：" + sqlDDL);
                    LogA.Debug("para[0].Value:" + para[0].Value);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogDALA.Debug("ds：" + ds.GetXml());

                    //string strDs = @"
                    //<NewDataSet>
                    //  <Table>
                    //    <BLH> 2019005511 </BLH>
                    //    <SYXH> 5526 </SYXH>
                    //    <TW> 36.5 </TW>
                    //    <HX> 15 </HX>
                    //    <MB> 64 </MB>
                    //    <TZB> 74 </TZB>
                    //    <XY> 124 / 82 </XY>
                    //  </Table>
                    //</NewDataSet>";

                    //StringReader sr = new StringReader(strDs);
                    //DataSet ds = new DataSet();
                    //ds.ReadXml(sr);

                    DataTable dt = ds.Tables[0];
                    LogA.Debug("dt.Rows.Count:" + dt.Rows.Count);

                    // 修改数据
                    string tw = string.Empty;
                    decimal hx = 0;
                    decimal mb = 0;
                    decimal tzb = 0;
                    string xy = string.Empty;
                    foreach(DataRow row in dt.Rows)
                    {
                        if(dt.Columns.Contains("TW"))
                        {
                            tw = row["TW"].ToString();
                        }

                        if (dt.Columns.Contains("HX"))
                        {
                            decimal.TryParse(row["HX"].ToString(), out hx);
                        }

                        if (dt.Columns.Contains("MB"))
                        {
                            decimal.TryParse(row["MB"].ToString(), out mb);
                        }

                        if (dt.Columns.Contains("TZB"))
                        {
                            decimal.TryParse(row["TZB"].ToString(), out tzb);
                        }

                        if (dt.Columns.Contains("XY"))
                        {
                            xy = row["XY"].ToString();
                        }

                        break;
                    }

                    try
                    {
                        // SQL语句
                        string planExam = string.Format("UPDATE MED_ANESTHESIA_PLAN_EXAM SET TEMPETURE='{0}', BREATH={1},PLUS={2},CARDIOTACH={2},BLOOD_PRESS='{3}' WHERE PATIENT_ID='{4}' AND VISIT_ID={5} AND OPER_ID={6}",
                                                        tw, hx, mb, xy, PatientId, VisitId, operID);
                        LogA.Debug("更新MED_ANESTHESIA_PLAN_EXAM语句：" + planExam);
                        if(0 == OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, planExam, null))
                        {
                            string insertExam = string.Format("INSERT INTO MED_ANESTHESIA_PLAN_EXAM(PATIENT_ID, VISIT_ID, OPER_ID, TEMPETURE, BREATH, PLUS, CARDIOTACH, BLOOD_PRESS) VALUES('{0}', {1}, {2}, '{3}', {4}, {5}, {5}, '{6}')", PatientId, VisitId, operID, tw, hx, mb, xy);
                            LogA.Debug("插入MED_ANESTHESIA_PLAN_EXAM语句：" + insertExam);
                            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, insertExam, null);
                        }

                        string planPmh = string.Format("UPDATE MED_ANESTHESIA_PLAN_PMH SET WEIGHT={0} WHERE PATIENT_ID='{1}' AND VISIT_ID={2} AND OPER_ID={3}",
                                                       tzb, PatientId, VisitId, operID);
                        LogA.Debug("更新MED_ANESTHESIA_PLAN_PMH语句：" + planPmh);
                        if(0 == OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, planPmh, null))
                        {
                            string insertPmh = string.Format("INSERT INTO MED_ANESTHESIA_PLAN_PMH(PATIENT_ID, VISIT_ID, OPER_ID, WEIGHT) VALUES('{0}', {1}, {2}, {3})", PatientId, VisitId, operID, tzb);
                            LogA.Debug("插入MED_ANESTHESIA_PLAN_PMH语句：" + insertPmh);
                            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, insertPmh, null);
                        }
                    }
                    catch(Exception ex)
                    {
                        InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                        ReturnMessage = ex.Message;
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

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
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
