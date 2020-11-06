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
    public class BMedPatInHospitalByWardCode:HospitalBase
    {
        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                            new OracleParameter(":wardcode", OracleType.VarChar),};
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] { new OleDbParameter("wardcode", OleDbType.VarChar), };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] { new SqlParameter("@wardcode", SqlDbType.VarChar), };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] { new OdbcParameter("wardcode", OdbcType.VarChar), };
                    }
                    break;
            }
            return parms;
        }

        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("科室同步患者信息:" + domain.Patient.WardCode);
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
                    para[0].Value = domain.Patient.WardCode; //todo 多个参数动态怎么解决
                    string sqlDDL = temp.SqlText + " " + GetSqlPara (temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogA.Debug("sqlDDL:" + sqlDDL);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogA.Debug("ds:" + ds.GetXml());
                    DataTable dt = ds.Tables[0];
                    InitDocare.LogA.Debug("dtCount:" + dt.Rows.Count);
                    dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.PatsInHospital);

                    List<MedPatsInHospital> PatsInHospitalList = GetMedPatsInHospitalList(dt);

                    config.obj = PatsInHospitalList;
                    ReturnMessage += DoExecute(config, domain, null);
                  
                }
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return "BMedPatInHospitalByWardCode:" + ex.Message;
            }
        }

        public string DoExecutePatVisitId(InitDocare.Config2 config, Init.ParamInputDomain domain, MedPatVisit patvisitid)
        {
            try
            {
                if (UpdateMedPatVisit(patvisitid) == 0)
                    InsertMedPatVisit(patvisitid);
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据" + patvisitid.ToString() + "\r\n");
                return ex.Message;
            }
        }

        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            return base.PreReceiveMsg(config, domain);
        }

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {

            try
            {
                InitDocare.LogA.Debug("科室同步患者信息:" + domain.Patient.WardCode);
                string resultXml = Anterface.GetInICUPatientInfo(domain.Patient.WardCode);
                InitDocare.LogA.Debug("resultXml:" + resultXml);
                DataSet ds = new DataSet();
                using (StringReader sr = new StringReader(resultXml))
                {
                    ds.ReadXml(sr);
                }

                DataTable dt = ds.Tables[0];
 
                InitDocare.LogA.Debug("dtCount:" + dt.Rows.Count);
                dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.PatsInHospital);

                List<MedPatsInHospital> PatsInHospitalList = GetMedPatsInHospitalList(dt);

                config.obj = PatsInHospitalList;
                ReturnMessage += DoExecute(config, domain, null);
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return "BMedPatInHospitalByWardCode:" + ex.Message;
            }
         
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                List<MedPatsInHospital> PatsInHospitalList = config.obj as List<MedPatsInHospital>;

                BMedPatsMasterIndex PatMasterIndex = new BMedPatsMasterIndex();
                foreach (MedPatsInHospital onePatsInHospital in PatsInHospitalList)
                {
                    domain.Code = "PAT101";
                    domain.Patient.PatientId = onePatsInHospital.PatientId;
                    domain.Reserved9 = "ICU";
                    InitDocare.LogDALA.Debug("domain.Patient.PatientId:" + domain.Patient.PatientId);
                    PatMasterIndex.PreDataBase(config, domain);
                    decimal medVisit = 0;
                    MedicalSytem.Soft.Model.MedVsHisPat oneExeistMedVsHisPat = SelectMedVsHisPatHis(onePatsInHospital.PatientId, onePatsInHospital.InpNo, onePatsInHospital.Reserved03);
                    if (oneExeistMedVsHisPat == null)
                    {
                        medVisit = (decimal)((int)SelectMaxMedVsHisPat(onePatsInHospital.PatientId) + 1);

                        MedicalSytem.Soft.Model.MedVsHisPat oneExeistMedVsHisPatNew = new MedicalSytem.Soft.Model.MedVsHisPat();
                        oneExeistMedVsHisPatNew.MedPatientId = onePatsInHospital.PatientId;
                        oneExeistMedVsHisPatNew.MedVisitId = medVisit;
                        oneExeistMedVsHisPatNew.HisPatientId = onePatsInHospital.PatientId;
                        //oneExeistMedVsHisPatNew.HisInpNo = onePatsInHospital.InpNo;
                        oneExeistMedVsHisPatNew.HisInpNo = onePatsInHospital.Reserved03;
                        oneExeistMedVsHisPatNew.HisVisitId = onePatsInHospital.Reserved03;
                        //Reserved01用来存放INP_NO的值
                        oneExeistMedVsHisPatNew.Reserved01 = onePatsInHospital.InpNo;
                        oneExeistMedVsHisPatNew.CreateDate = DateTime.Now;
                        InsertMedVsHisPat(oneExeistMedVsHisPatNew);

                        onePatsInHospital.VisitId = medVisit;
                    }
                    else
                    {
                        medVisit = oneExeistMedVsHisPat.MedVisitId;
                        onePatsInHospital.VisitId = oneExeistMedVsHisPat.MedVisitId;
                    }


                    MedPatVisit PatVisit = new MedPatVisit();
                    PatVisit.PatientId = onePatsInHospital.PatientId;
                    PatVisit.VisitId = onePatsInHospital.VisitId;
                    if (onePatsInHospital.AdmissionDateTime.HasValue)
                        PatVisit.AdmissionDateTime = onePatsInHospital.AdmissionDateTime.Value;
                    PatVisit.PatientCondition = onePatsInHospital.PatientCondition;

                    PatVisit.PatientSource = onePatsInHospital.PatientSource;
                    PatVisit.BloodType = onePatsInHospital.BloodType;
                    PatVisit.BloodTypeRh = onePatsInHospital.BloodTypeRh;
                    if (onePatsInHospital.BodyHeight.HasValue)
                        PatVisit.BodyHeight = onePatsInHospital.BodyHeight.Value;
                    if (onePatsInHospital.BodyWeight.HasValue)
                        PatVisit.BodyWeight = onePatsInHospital.BodyWeight.Value;

                    PatVisit.DoctorInCharge = onePatsInHospital.DoctorInCharge;
                    PatVisit.HospBranch = onePatsInHospital.HospBranch;
                    PatVisit.InpNo = onePatsInHospital.InpNo;

                    ReturnMessage += DoExecutePatVisitId(config, domain, PatVisit);

                    if (UpdateMedPatsInHospital(onePatsInHospital) == 0)
                        InsertMedPatsInHospital(onePatsInHospital);

                }

                #region 转出出科病人
                //历史在科病人
                List<MedicalSytem.Soft.Model.MedPatsInHospital> medPatsInHosptal = SelectDeptMedPatsInHospital(domain.Patient.WardCode);
                InitDocare.LogA.Debug("docareDeptCode:" + medPatsInHosptal.Count);
                InitDocare.LogA.Debug("HisCount:" + PatsInHospitalList.Count);
                //先转出出科病人
                foreach (MedicalSytem.Soft.Model.MedPatsInHospital patsOut in medPatsInHosptal)
                {
                    int forAt = 0;//1 为在科 0 为 出科
                    foreach (MedicalSytem.Soft.Model.MedPatsInHospital patsAt in PatsInHospitalList)
                    {
                        InitDocare.LogA.Debug("patientid His:" + patsAt.PatientId + " deptCode:" + patsAt.DeptCode + " docare patient :" + patsOut.PatientId + " deptCode:" + patsOut.DeptCode);
                        if (patsAt.PatientId == patsOut.PatientId && patsAt.DeptCode == patsOut.DeptCode)
                        {
                            forAt = 1;
                            break;
                        }
                    }
                    if (forAt == 0)
                    {
                        InitDocare.LogA.Debug("delete from :patientid" + patsOut.PatientId);
                        DeleteMedPatsInHospital(patsOut);
                    }
                }
                #endregion
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据");
                return ex.Message;
            }
        }
    }
}
