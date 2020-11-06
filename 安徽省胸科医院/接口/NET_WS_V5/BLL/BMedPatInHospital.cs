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
    public class BMedPatInHospital : HospitalBase
    {
        decimal dc;
        DateTime datetime;
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

        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("开始同步BMedPatInHospital 入参 InpNo:" + domain.Patient.PatientId);
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);

                DataSet dsResult = new DataSet();
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                  //  InitDocare.LogDALA.Debug("temp.TransName:" + temp.TransName);
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);
                  //  InitDocare.LogDALA.Debug("oneTransEntity.Dbms:" + oneTransEntity.Dbms);
                    DbParameter[] para = GetPara(oneTransEntity.Dbms);
                    para[0].Value = domain.Patient.PatientId;   //todo 多个参数动态怎么解决
                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogA.Debug("BMedPatInHospitalsqlDDL:" + sqlDDL);

                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogA.Debug("BMedPatInHospitaldsGetXml:" + ds.GetXml());

                    //调试
                    //string strDs = @"<NewDataSet>
                    //     <Table>
                    //        <PATIENT_ID>2019005828</PATIENT_ID>
                    //        <INP_NO>2019005828</INP_NO>
                    //        <VISIT_ID>1</VISIT_ID>
                    //        <PATIENT_SOURCE>0</PATIENT_SOURCE>
                    //        <HOSP_BRANCH>安徽省胸科医院</HOSP_BRANCH>
                    //        <WARD_CODE>08          </WARD_CODE>
                    //        <DEP_ID />
                    //        <DEPT_CODE>202031      </DEPT_CODE>
                    //        <BED_NO>20</BED_NO>
                    //        <ADMISSION_DATE_TIME>2019-12-09 12:08:00</ADMISSION_DATE_TIME>
                    //        <ADM_WARD_DATE_TIME>2019-12-09 12:18:54</ADM_WARD_DATE_TIME>
                    //        <DEPT_DISCHARGE_FROM />
                    //        <DISCHARGE_DATE_TIME />
                    //        <DIAGNOSIS>肺结节</DIAGNOSIS>
                    //        <PATIENT_CONDITION />
                    //        <BLOOD_TYPE />
                    //        <BLOOD_TYPE_RH />
                    //        <BODY_HEIGHT />
                    //        <BODY_WEIGHT />
                    //        <NURSING_CLASS />
                    //        <DOCTOR_IN_CHARGE>吴峰</DOCTOR_IN_CHARGE>
                    //        <PREPAYMENTS />
                    //        <SETTLED_INDICATOR />
                    //        <INSURANCE_TYPE>住院全费</INSURANCE_TYPE>
                    //        <INSURANCE_NO />
                    //        <PATIENT_CLASS />
                    //        <ADMISSION_CAUSE />
                    //        <CONSULTING_DOCTOR>712059      </CONSULTING_DOCTOR>
                    //        <ADMITTRD_BY />
                    //        <RESERVED01>5843</RESERVED01>
                    //        <RESERVED02>4948</RESERVED02>
                    //        <RESERVED03 />
                    //        <RESERVED_DATE01 />
                    //        <RESERVED_DATE02 />
                    //      </Table>
                    //</NewDataSet> ";
                    //StringReader sr = new StringReader(strDs);
                    //DataSet ds = new DataSet();
                    //ds.ReadXml(sr);

                    DataTable dt = ds.Tables[0];
                    InitDocare.LogA.Debug("BMedPatInHospitaldsGetXml:" + dt.Rows.Count);
                    dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.PatsInHospital);

                    MedPatsInHospital onePatsInHospital = GetMedPatsInHospital(dt);
                    if (onePatsInHospital == null)
                    {
                        return "";// "查询到患者信息为空， patient_id" + domain.Patient.PatientId;
                    }
                    if (domain.Route == 1)
                    {
                        if (onePatsInHospital == null)
                        {
                            return "";
                        }
                        else
                        {
                            return @"<PATSHOSINFO><SPECIAL_MARK>" + onePatsInHospital.SPECIAL_MARK + "</SPECIAL_MARK><PATIENT_ID>" + onePatsInHospital.PatientId + "</PATIENT_ID><VISIT_ID>" + onePatsInHospital.Reserved03 + "</VISIT_ID><ADMISSION_DATE_TIME>" + onePatsInHospital.AdmissionDateTime + "</ADMISSION_DATE_TIME><ADM_WARD_DATE_TIME>" + onePatsInHospital.AdmWardDateTime + "</ADM_WARD_DATE_TIME><BLOOD_TYPE>" + onePatsInHospital.BloodType + "</BLOOD_TYPE><BLOOD_TYPE_RH>" + onePatsInHospital.BloodTypeRh + @"</BLOOD_TYPE_RH>
                            <BODY_HEIGHT>" + onePatsInHospital.BodyHeight + "</BODY_HEIGHT><BODY_WEIGHT>" + onePatsInHospital.BodyWeight + "</BODY_WEIGHT><DEP_ID>" + onePatsInHospital.DepId + "</DEP_ID><DEPT_CODE>" + onePatsInHospital.DeptCode + "</DEPT_CODE><DIAGNOSIS>" + onePatsInHospital.Diagnosis + "</DIAGNOSIS><DOCTOR_IN_CHARGE>" + onePatsInHospital.DoctorInCharge + "</DOCTOR_IN_CHARGE><HOSP_BRANCH>" + onePatsInHospital.HospBranch + @"</HOSP_BRANCH>
                            <INP_NO>" + onePatsInHospital.InpNo + "</INP_NO><BED_NO>" + onePatsInHospital.BedNo + "</BED_NO><DEPT_FROM>" + onePatsInHospital.DEPT_FROM + "</DEPT_FROM><ALERGY_DRUGS>" + onePatsInHospital.ALERGY_DRUGS + "</ALERGY_DRUGS><NURSE_IN_CHARGE>" + onePatsInHospital.NurseInCharge + "</NURSE_IN_CHARGE> <NURSING_CLASS>" + onePatsInHospital.NursingClass + "</NURSING_CLASS> <PATIENT_CONDITION>" + onePatsInHospital.PatientCondition + "</PATIENT_CONDITION><PATIENT_SOURCE>" + onePatsInHospital.PatientSource + "</PATIENT_SOURCE><WARD_CODE>" + onePatsInHospital.WardCode + "</WARD_CODE></PATSHOSINFO>";

                        }
                    }
                    ReturnMessage += DoExecute(config, domain, onePatsInHospital);
                }
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                if (domain.Route == 1)
                {
                    return "";
                }
                return ex.Message;
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

            string resultXml = Anterface.GetInPatientInfor(domain.Patient.InpNo);
            InitDocare.LogDALA.Debug("mess:" + resultXml);
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(resultXml))
            {
                ds.ReadXml(sr);
            }

            DataTable dt = ds.Tables[0];

            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.PatsInHospital);

            MedPatsInHospital onePatsInHospital = GetMedPatsInHospital(dt);
            if (domain.Route == 1)
            {
                if (onePatsInHospital == null)
                {
                    return "";
                }
                else
                {
                    return @"<PATSHOSINFO><SPECIAL_MARK>" + onePatsInHospital.SPECIAL_MARK + "</SPECIAL_MARK><PATIENT_ID>" + onePatsInHospital.PatientId + "</PATIENT_ID><VISIT_ID>" + onePatsInHospital.Reserved03 + "</VISIT_ID><ADMISSION_DATE_TIME>" + onePatsInHospital.AdmissionDateTime + "</ADMISSION_DATE_TIME><ADM_WARD_DATE_TIME>" + onePatsInHospital.AdmWardDateTime + "</ADM_WARD_DATE_TIME><BLOOD_TYPE>" + onePatsInHospital.BloodType + "</BLOOD_TYPE><BLOOD_TYPE_RH>" + onePatsInHospital.BloodTypeRh + @"</BLOOD_TYPE_RH>
                       <BODY_HEIGHT>" + onePatsInHospital.BodyHeight + "</BODY_HEIGHT><BODY_WEIGHT>" + onePatsInHospital.BodyWeight + "</BODY_WEIGHT><DEP_ID>" + onePatsInHospital.DepId + "</DEP_ID><DEPT_CODE>" + onePatsInHospital.DeptCode + "</DEPT_CODE><DIAGNOSIS>" + onePatsInHospital.Diagnosis + "</DIAGNOSIS><DOCTOR_IN_CHARGE>" + onePatsInHospital.DoctorInCharge + "</DOCTOR_IN_CHARGE><HOSP_BRANCH>" + onePatsInHospital.HospBranch + @"</HOSP_BRANCH>
                       <INP_NO>" + onePatsInHospital.InpNo + "</INP_NO><BED_NO>" + onePatsInHospital.BedNo + "</BED_NO><DEPT_FROM>" + onePatsInHospital.DEPT_FROM + "</DEPT_FROM><ALERGY_DRUGS>" + onePatsInHospital.ALERGY_DRUGS + "</ALERGY_DRUGS><NURSE_IN_CHARGE>" + onePatsInHospital.NurseInCharge + "</NURSE_IN_CHARGE> <NURSING_CLASS>" + onePatsInHospital.NursingClass + "</NURSING_CLASS> <PATIENT_CONDITION>" + onePatsInHospital.PatientCondition + "</PATIENT_CONDITION><PATIENT_SOURCE>" + onePatsInHospital.PatientSource + "</PATIENT_SOURCE><WARD_CODE>" + onePatsInHospital.WardCode + "</WARD_CODE></PATSHOSINFO>";
                }
            }
            ReturnMessage += DoExecute(config, domain, onePatsInHospital);
            return ReturnMessage;
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, ModelBase obj)
        {
            try
            {
                 
                if (!(obj is MedPatsInHospital))
                {
                    return "obj is not MedPatsInHospital " + obj.ToString();
                }

                MedPatsInHospital onePatsInHospital = obj as MedPatsInHospital;

                decimal medVisit = 0;
                MedicalSytem.Soft.Model.MedVsHisPat oneExeistMedVsHisPat = SelectMedVsHisPatHis(onePatsInHospital.PatientId, onePatsInHospital.Reserved03, onePatsInHospital.Reserved03);
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

                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据" + obj.ToString() + "\r\n");
                return ex.Message;
            }
        }
    }
}
