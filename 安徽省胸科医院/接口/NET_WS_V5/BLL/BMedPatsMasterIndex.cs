using System;
using System.Collections.Generic;
using System.Text;
using MedicalSytem.Soft.Model;
using System.Data;
using Init;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.IO;
using InitDocare;
using NET_WS_V5;

namespace BLL
{
    public partial class BMedPatsMasterIndex : HospitalBase //参数提到一个类，组合()...
    {
     
        public override DbParameter[] GetPara(EnumDataBase database)
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

        /// <summary>
        /// 读取数据,从数据库中
        /// </summary>
        /// <param name="config"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public override string PreDataBase(InitDocare.Config2 config, ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("开始同步BMedPatsMasterIndex 入参PATIENT_ID:" + domain.Patient.PatientId);
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
                    para[0].Value = domain.Patient.PatientId;   //todo 多个参数动态怎么解决(组合)

                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogDALA.Debug("sqlDDL:" + sqlDDL);
                    InitDocare.LogDALA.Debug(" para[0].Value :" + para[0].Value);

                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogDALA.Debug("ds:" + ds.GetXml());

                    //调试
                    //string strDs = @"<NewDataSet>
                    //    <Table>
                    //        <PATIENT_ID>2019005828</PATIENT_ID>
                    //        <INP_NO>2019005828</INP_NO>
                    //        <NAME>陈世华</NAME>
                    //        <NAME_PHONETIC />
                    //        <SEX>女  </SEX>
                    //        <DATE_OF_BIRTH>1948-08-07</DATE_OF_BIRTH>
                    //        <BIRTH_PLACE />
                    //        <CITIZENSHIP>CN</CITIZENSHIP>
                    //        <NATION>汉族</NATION>
                    //        <ID_NO />
                    //        <UNIT_IN_CONTRACT />
                    //        <MAILING_ADDRESS />
                    //        <ZIP_CODE />
                    //        <PHONE_NUMBER_HOME />
                    //        <PHONE_NUMBER_BUSINESS />
                    //        <NEXT_OF_KIN />
                    //        <RELATIONSHIP />
                    //        <NEXT_OF_KIN_ADDR />
                    //        <NEXT_OF_KIN_ZIP_CODE />
                    //        <NEXT_OF_KIN_PHONE />
                    //        <CHARGE_TYPE>住院全费</CHARGE_TYPE>
                    //        <LCLJ>是</LCLJ>
                    //  </Table>
                    //</NewDataSet>";
                    //StringReader sr = new StringReader(strDs);
                    //DataSet ds = new DataSet();
                    //ds.ReadXml(sr);

                    DataTable dt = ds.Tables[0];
                    if (dt == null)
                    {
                        return "患者基本信息为空 请重新检查输入PatientID 是否正确，patientid" + domain.Patient.PatientId;
                    }

                    dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.PatMasterIndex);
                    MedPatMasterIndex PatMasterIndex = GetMedPatMasterIndex(dt);
                    if (domain.Route == 1) //直接返回患者基本信息
                    {
                        if (PatMasterIndex == null)
                        {
                            return "";
                        }
                        else
                        {
                            return @"<PATINFO><PATIENT_ID>" + PatMasterIndex.PatientId + "</PATIENT_ID><BIRTH_PLACE>" + PatMasterIndex.BirthPlace + @"</BIRTH_PLACE><CITIZENSHIP>" + PatMasterIndex.Citizenship + "</CITIZENSHIP><DATE_OF_BIRTH>" + PatMasterIndex.DateOfBirth + "</DATE_OF_BIRTH><IDENTITY>" + PatMasterIndex.Identity + "</IDENTITY><ID_NO>" + PatMasterIndex.IdNo + "</ID_NO><MAILING_ADDRESS>" + PatMasterIndex.MailingAddress + "</MAILING_ADDRESS><NAME>" + PatMasterIndex.Name + @"</NAME>
                            <NAME_PHONETIC>" + PatMasterIndex.NamePhonetic + "</NAME_PHONETIC><NATION>" + PatMasterIndex.Nation + "</NATION><NEXT_OF_KIN>" + PatMasterIndex.NextOfKin + "</NEXT_OF_KIN><NEXT_OF_KIN_ADDR>" + PatMasterIndex.NextOfKinAddr + "</NEXT_OF_KIN_ADDR><NEXT_OF_KIN_PHONE>" + PatMasterIndex.NextOfKinPhone + "</NEXT_OF_KIN_PHONE><NEXT_OF_KIN_ZIP_CODE>" + PatMasterIndex.NextOfKinZipCode + "</NEXT_OF_KIN_ZIP_CODE><PHONE_NUMBER_BUSINESS>" + PatMasterIndex.PhoneNumberBusiness + "</PHONE_NUMBER_BUSINESS><PHONE_NUMBER_HOME>" + PatMasterIndex.PhoneNumberHome + "</PHONE_NUMBER_HOME><RELATIONSHIP" + PatMasterIndex.Relationship + "></RELATIONSHIP><SEX>" + PatMasterIndex.Sex + "</SEX><UNIT_IN_CONTRACT>" + PatMasterIndex.UnitInContract + "</UNIT_IN_CONTRACT><ZIP_CODE>" + PatMasterIndex.ZipCode + "</ZIP_CODE></PATINFO>";
                        }
                    }
                    ReturnMessage += DoExecute(config, domain, PatMasterIndex);
                    if (domain.Reserved9 != "ICU")
                    {
                        BMedPatInHospital bMedPatHosPital = new BMedPatInHospital();
                        domain.Patient.PatientId = PatMasterIndex.PatientId;
                        domain.Code = "PAT103";
                        ReturnMessage += bMedPatHosPital.PreDataBase(config, domain);
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

        /// <summary>
        /// webservices 读取数据
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public override string PreWebServices(InitDocare.Config2 config, ParamInputDomain domain)
        {

            string resultXml = Anterface.GetPatientMasterIndex(domain.Patient.PatientId);
            InitDocare.LogDALA.Debug("mess:" + resultXml);
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(resultXml))
            {
                ds.ReadXml(sr);
            }
            DataTable dt = ds.Tables[0];
            if (dt == null)
            {
                return "患者基本信息为空，patientid" + domain.Patient.PatientId;
            }

            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.PatMasterIndex);

            MedPatMasterIndex PatMasterIndex = GetMedPatMasterIndex(dt);
            if (domain.Route == 1) //直接返回患者基本信息
            {
                if (PatMasterIndex == null)
                {
                    return "";
                }
                else
                {
                    return @"<PATINFO><PATIENT_ID>" + PatMasterIndex.PatientId + "</PATIENT_ID><BIRTH_PLACE>" + PatMasterIndex.BirthPlace + @"</BIRTH_PLACE><CITIZENSHIP>" + PatMasterIndex.Citizenship + "</CITIZENSHIP><DATE_OF_BIRTH>" + PatMasterIndex.DateOfBirth + "</DATE_OF_BIRTH><IDENTITY>" + PatMasterIndex.Identity + "</IDENTITY><ID_NO>" + PatMasterIndex.IdNo + "</ID_NO><MAILING_ADDRESS>" + PatMasterIndex.MailingAddress + "</MAILING_ADDRESS><NAME>" + PatMasterIndex.Name + @"</NAME>
                            <NAME_PHONETIC>" + PatMasterIndex.NamePhonetic + "</NAME_PHONETIC><NATION>" + PatMasterIndex.Nation + "</NATION><NEXT_OF_KIN>" + PatMasterIndex.NextOfKin + "</NEXT_OF_KIN><NEXT_OF_KIN_ADDR>" + PatMasterIndex.NextOfKinAddr + "</NEXT_OF_KIN_ADDR><NEXT_OF_KIN_PHONE>" + PatMasterIndex.NextOfKinPhone + "</NEXT_OF_KIN_PHONE><NEXT_OF_KIN_ZIP_CODE>" + PatMasterIndex.NextOfKinZipCode + "</NEXT_OF_KIN_ZIP_CODE><PHONE_NUMBER_BUSINESS>" + PatMasterIndex.PhoneNumberBusiness + "</PHONE_NUMBER_BUSINESS><PHONE_NUMBER_HOME>" + PatMasterIndex.PhoneNumberHome + "</PHONE_NUMBER_HOME><RELATIONSHIP" + PatMasterIndex.Relationship + "></RELATIONSHIP><SEX>" + PatMasterIndex.Sex + "</SEX><UNIT_IN_CONTRACT>" + PatMasterIndex.UnitInContract + "</UNIT_IN_CONTRACT><ZIP_CODE>" + PatMasterIndex.ZipCode + "</ZIP_CODE></PATINFO>";
                }
            }
            ReturnMessage += DoExecute(config, domain, PatMasterIndex);

            if (domain.Reserved9 != "ICU")
            {
                BMedPatInHospital bMedPatHosPital = new BMedPatInHospital();
                domain.Patient.PatientId = PatMasterIndex.PatientId;
                domain.Patient.InpNo = PatMasterIndex.InPno;
                domain.Code = "PAT103";
                ReturnMessage += bMedPatHosPital.PreDataBase(config, domain);
            }
            return ReturnMessage;
        }
            

        /// <summary>
        /// 接受推送数据，可能HL7，xml，JOSN,cdr 等等
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public override string PreReceiveMsg(InitDocare.Config2 config, ParamInputDomain domain)
        {
            DoExecute(config, domain, null);
            return domain.Result;
        }

        /// <summary>
        /// 处理数据写表
        /// </summary>
        /// <param name="config"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public override string DoExecute(InitDocare.Config2 config, ParamInputDomain domain, ModelBase obj)
        {
            try
            {
                if (!(obj is MedPatMasterIndex))
                {
                    return "";
                }
                MedPatMasterIndex oneMedPatMasterIndex = obj as MedPatMasterIndex;

                if (UpdateMedPatMasterIndex(oneMedPatMasterIndex) == 0)
                    InsertMedPatMasterIndex(oneMedPatMasterIndex);

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
