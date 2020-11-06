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
    public class BMedPatOperation:HospitalBase
    {
        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                            new OracleParameter(":patientid", OracleType.VarChar),};
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] { new OleDbParameter("patientid", OleDbType.VarChar), };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] { new SqlParameter("@patientid", SqlDbType.VarChar), };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] { new OdbcParameter("patientid", OdbcType.VarChar), };
                    }
                    break;
            }
            return parms;
        }

        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("开始同步BMedPatOperation 入参PATIENT_ID:" + domain.Patient.PatientId);
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                InitDocare.LogDALA.Debug("sql.Count;" + sql.Count);
                DataSet dsResult = new DataSet();
                foreach (MedIfHisViewSql2 temp in sql)
                {

                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);

                    DbParameter[] para = GetPara(oneTransEntity.Dbms);
                    para[0].Value = domain.Patient.PatientId;  //todo 多个参数动态怎么解决(组合)
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogA.Debug("sqlDDL" + sqlDDL);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    string mes = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        List<OperationMdsd> opList = Change(ds);

                        opList = opList.OrderByDescending(p => p.Oper_id).ToList();
                        OperationMdsd one = opList[0];

                        opList = opList.FindAll(p => p.PATIENT_ID == one.PATIENT_ID && p.visit_id == one.visit_id && p.Oper_id == one.Oper_id);

                        //where PATIENT_ID = @@patientid
                        string blood = "";
                        bool flag = false;
                        foreach (OperationMdsd entiy in opList)
                        {
                            if (!flag)
                            {
                                mes += @"<OPERINFO><INPNO>" + domain.Patient.InpNo + "</INPNO><OPERATE_DATE>" + entiy.OPERATE_TIME + "</OPERATE_DATE><OPERATING_NAME>" + entiy.OPERATING_NAME + "</OPERATING_NAME><OPERATING_SITE>" + entiy.OPERATING_SITE + @"</OPERATING_SITE>
                                    <TRANSFER_WAY>" + entiy.TRANSFER_WAY + "</TRANSFER_WAY><ANESTHESIA_METHOD>" + entiy.ANESTHESIA_METHOD + "</ANESTHESIA_METHOD><OPERATION_INFO>" + entiy.OPERATION_INFO + "</OPERATION_INFO><NICK_STATUS>" + entiy.NICK_STATUS + "</NICK_STATUS><NICK_INFO>" + entiy.NICK_INFO + "</NICK_INFO><OUT_OPERATINGROOM_DATE_TIME>" + entiy.OUT_OPERATINGROOM_DATE_TIME + "</OUT_OPERATINGROOM_DATE_TIME><BLOODINFO>bloodMsg</BLOODINFO></OPERINFO>";
                                flag = true;
                            }
                            blood += "<BLOOD><BLOOD_CLASS>" + entiy.BLOOD_CLASS + "</BLOOD_CLASS><BLOOD_AMOUNT>" + entiy.BLOOD_AMOUNT + "</BLOOD_AMOUNT><BLOOD_UNIT>" + entiy.BLOOD_UNIT + "</BLOOD_UNIT><BLOOD_RH>" + entiy.BLOOD_RH + "</BLOOD_RH><BLOOD_DATE_TIME>" + entiy.BLOOD_DATE_TIME + "</BLOOD_DATE_TIME></BLOOD>";
                        }
                        mes = mes.Replace("bloodMsg", blood);
                    }

                    BMedPatsMasterIndex patno = new BMedPatsMasterIndex();
                    domain.Route = 1;
                    domain.Code = "PAT101";
                    string patinfo = patno.PreDataBase(config, domain);
                    string pats = "";

                    BMedPatInHospital hos = new BMedPatInHospital();
                    domain.Route = 1;
                    domain.Code = "PAT103";

                    pats = hos.PreDataBase(config, domain);


                    mes = "<Root>" + mes + patinfo + pats + "</Root>";
                    return mes;
                }
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return ex.Message;
            }
        }

        private string GetPatientId(string patientid)
        {
            try
            {
                DataSet ds = new DataSet();
                using (StringReader sr = new StringReader(patientid))
                {
                    ds.ReadXml(sr);
                }
                if(ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
                {
                    return ds.Tables[0].Rows[0]["PATIENT_ID"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
       

        public List<OperationMdsd> Change(DataSet ds)
        {
            List<OperationMdsd> entity = new List<OperationMdsd>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                OperationMdsd one = new OperationMdsd();
                one.PATIENT_ID = dr["PATIENT_ID"].ToString();
                one.visit_id = dr["visit_id"].ToString();
                one.Oper_id = decimal.Parse(dr["Oper_id"].ToString());
                one.inp_no = dr["inp_no"].ToString();
                one.OPERATE_TIME = dr["OPERATE_TIME"].ToString();
                one.OPERATING_NAME = dr["OPERATING_NAME"].ToString();
                one.OPERATING_SITE = dr["OPERATING_SITE"].ToString();
                one.TRANSFER_WAY = dr["TRANSFER_WAY"].ToString();
                one.ANESTHESIA_METHOD = dr["ANESTHESIA_METHOD"].ToString();
                one.BLOOD_CLASS = dr["BLOOD_CLASS"].ToString();
                one.BLOOD_AMOUNT = dr["BLOOD_AMOUNT"].ToString();
                one.BLOOD_UNIT = dr["BLOOD_UNIT"].ToString();

                one.BLOOD_RH = dr["BLOOD_RH"].ToString();

                one.BLOOD_DATE_TIME = dr["BLOOD_DATE_TIME"].ToString();
                one.OPERATION_INFO = dr["OPERATION_INFO"].ToString();
                one.NICK_STATUS = dr["NICK_STATUS"].ToString();
                one.OUT_OPERATINGROOM_DATE_TIME = dr["OUT_OPERATINGROOM_DATE_TIME"].ToString();
             
                entity.Add(one);
            }
            return entity;

        }

        public class OperationMdsd
        {
            public string PATIENT_ID { get; set; }

            public string  visit_id { get; set; }

            public decimal Oper_id { get; set; }

            public string inp_no { get; set; }

            public string OPERATE_TIME { get; set; }

            public string OPERATING_NAME { get; set; }

            public string OPERATING_SITE { get; set; }
            public string TRANSFER_WAY { get; set; }
            public string ANESTHESIA_METHOD { get; set; }
            public string BLOOD_CLASS { get; set; }
            public string BLOOD_AMOUNT { get; set; }

            public string BLOOD_UNIT { get; set; }

            public string BLOOD_RH { get; set; }

            public string BLOOD_DATE_TIME { get; set; }
            public string OPERATION_INFO { get; set; }

            public string NICK_STATUS { get; set; }

            public string NICK_INFO { get; set; }

            public string OUT_OPERATINGROOM_DATE_TIME { get; set; }

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
