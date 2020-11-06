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

namespace BLL
{
    public class BOperationSchedule : HospitalBase
    {

        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{

                            new OracleParameter(":scheduledDateTimeStart",OracleType.DateTime),
                            new OracleParameter(":scheduledDateTimeEnd",OracleType.DateTime),
                               new OracleParameter(":patientId",OracleType.VarChar),
                        };
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] {

                            new OleDbParameter("scheduledDateTimeStart", OleDbType.Date),
                            new OleDbParameter("scheduledDateTimeEnd",OleDbType.Date),
                            new OleDbParameter("patientId",OleDbType.VarChar),
                        };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] {

                            new SqlParameter("@scheduledDateTimeStart", SqlDbType.DateTime),
                            new SqlParameter("@scheduledDateTimeEnd",SqlDbType.DateTime),
                                new SqlParameter("@patientId", SqlDbType.VarChar),

                        };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] {

                            new OdbcParameter("scheduledDateTimeStart", OdbcType.DateTime),
                            new OdbcParameter("scheduledDateTimeEnd",OdbcType.DateTime),
                             new OdbcParameter("patientId",OdbcType.VarChar),
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
                InitDocare.LogDALA.Debug("开始同步手术预约信息Code:" + domain.Code);
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                InitDocare.LogDALA.Debug("sql;" + sql.Count);
                DataSet dsResult = new DataSet();
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    InitDocare.LogDALA.Debug("temp.TransName:" + temp.TransName);
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);
                    InitDocare.LogDALA.Debug("oneTransEntity.Dbms:" + oneTransEntity.Dbms);
                    DbParameter[] para = GetPara(oneTransEntity.Dbms);

                    para[0].Value = domain.Operation.StartDataTime.Value.AddHours(8);
                    para[1].Value = domain.Operation.StopDataTime.Value.AddHours(8);
                    para[2].Value = string.IsNullOrEmpty(domain.Patient.PatientId) ? "ALL" : domain.Patient.PatientId;   //todo 多个参数动态怎么解决



                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);

                    InitDocare.LogDALA.Debug(para[0].Value + "," + para[1].Value + "," + para[2].Value);

                    InitDocare.LogDALA.Debug(sqlDDL);
                    InitDocare.LogDALA.Debug(oneTransEntity.Dbparm);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);

                    // 调试
                                       //string strDs = @"
  //                  <NewDataSet>
  //                        <Table>
  //  <PATIENT_ID>2019005828</PATIENT_ID>
  //  <VISIT_ID>1</VISIT_ID>
  //  <SCHEDULE_ID>480</SCHEDULE_ID>
  //  <OPER_ID>480</OPER_ID>
  //  <HOSP_BRANCH>安徽省胸科医院</HOSP_BRANCH>
  //  <WARD_CODE>08          </WARD_CODE>
  //  <DEPT_CODE>202031      </DEPT_CODE>
  //  <OPER_DEPT_CODE>303001      </OPER_DEPT_CODE>
  //  <OPER_ROOM>303001      </OPER_ROOM>
  //  <SEQUENCE>1</SEQUENCE>
  //  <OPER_CLASS>1</OPER_CLASS>
  //  <DIAG_BEFORE_OPERATION>右上中肺结节</DIAG_BEFORE_OPERATION>
  //  <PATIENT_CONDITION />
  //  <OPER_SCALE>3 </OPER_SCALE>
  //  <WOUND_TYPE>3</WOUND_TYPE>
  //  <ASA_GRADE />
  //  <EMERGENCY_IND>0</EMERGENCY_IND>
  //  <OPER_SOURCE>1</OPER_SOURCE>
  //  <ISOLATION_IND />
  //  <INFECTED_IND />
  //  <RADIATE_IND />
  //  <SURGEON>华丛书</SURGEON>
  //  <FIRST_OPER_ASSISTANT>吴峰</FIRST_OPER_ASSISTANT>
  //  <SECOND_OPER_ASSISTANT>王文生</SECOND_OPER_ASSISTANT>
  //  <FOURTH_OPER_ASSISTANT />
  //  <ANES_METHOD>复合麻醉</ANES_METHOD>
  //  <SECOND_ANES_ASSISTANT />
  //  <THIRD_ANES_ASSISTANT />
  //  <FOURTH_ANES_ASSISTANT />
  //  <CPB_DOCTOR />
  //  <FIRST_CPB_ASSISTANT />
  //  <SECOND_CPB_ANESTHESIA />
  //  <THIRD_CPB_ANESTHESIA />
  //  <FOURTH_CPB_ANESTHESIA />
  //  <FIRST_OPER_NURSE />
  //  <SECOND_OPER_NURSE />
  //  <THIRD_OPER_NURSE />
  //  <FOURTH_OPER_NURSE />
  //  <FIRST_ANES_NURSE />
  //  <SECOND_ANES_NURSE />
  //  <THIRD_ANES_NURSE />
  //  <FIRST_SUPPLY_NURSE />
  //  <SECOND_SUPPLY_NURSE />
  //  <THIRD_SUPPLY_NURSE />
  //  <FOURTH_SUPPLY_NURSE />
  //  <REQ_DATE_TIME>2019-12-11 08:18:47</REQ_DATE_TIME>
  //  <SCHEDULED_DATE_TIME>2019-12-11 08:18:47</SCHEDULED_DATE_TIME>
  //  <PACU_DOCTOR />
  //  <FIRST_PACU_ASSISTANT />
  //  <SECOND_PACU_ASSISTANT />
  //  <FIRST_PACU_NURSE />
  //  <SECOND_PACU_NURSE />
  //  <OPER_POSITION>左侧卧位</OPER_POSITION>
  //  <BED_NO>20</BED_NO>
  //  <SPECIAL_EQUIPMENT />
  //  <SPECIAL_INFECT />
  //  <NOTES_ON_OPERATION />
  //  <OPERATOR />
  //  <HIS_PATIENT_ID>2019005828</HIS_PATIENT_ID>
  //  <HIS_VISIT_ID>1</HIS_VISIT_ID>
  //  <HIS_SCHEDULE_ID>480</HIS_SCHEDULE_ID>
  //  <OPERATING_TIME>2019-12-10 08:39:28</OPERATING_TIME>
  //  <RESERVED1 />
  //  <RESERVED2 />
  //  <RESERVED3 />
  //</Table>
  //                   </NewDataSet>
  //                   ";
  //                  StringReader sr = new StringReader(strDs);
  //                  DataSet ds = new DataSet();
  //                  ds.ReadXml(sr);

                    InitDocare.LogDALA.Debug("ds;" + ds.GetXml());
                    DataTable dt = ds.Tables[0];
                    InitDocare.LogDALA.Debug("dt;" + dt.Rows.Count);

                    List<MedOperationSchedule> operationScheduleList = GetMedOperationSchedule(dt);
                    foreach (MedOperationSchedule oneMedOperationSchedule in operationScheduleList)
                    {
                        ReturnMessage += DoExecute(config, domain, oneMedOperationSchedule);
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

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            string mess = WebService.DoCareInterFaceInput("", "");
            return "";
        }

        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            return "";
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                if (!(obj is MedOperationSchedule))
                {
                    throw new Exception("obj is not MedOperationSchedule,obj.GetType().ToString()" + obj.GetType().ToString());
                }

                MedOperationSchedule oneOperationSchedule = obj as MedOperationSchedule;

                BMedPatsMasterIndex BPatIndex = new BMedPatsMasterIndex();
                domain.Patient.PatientId = oneOperationSchedule.PatientId;
                domain.Operation.HisScheduleId = oneOperationSchedule.HisScheduleId;
                domain.Operation.HisVisitId = oneOperationSchedule.HisVisitId;
                domain.Code = "PAT101";
                string getPatientID = BPatIndex.PreDataBase(config, domain);

                //BMedPatInHospital Bhos = new BMedPatInHospital();
                //domain.Code = "PAT103";
                //getPatientID = BPatIndex.PreDataBase(config, domain);

                MedicalSytem.Soft.Model.MedVsHisOperApplyV2 oneMedVsHisOperApply = SelectMedVsHisOperApplyV2HisReq(oneOperationSchedule.HisScheduleId, oneOperationSchedule.PatientId, oneOperationSchedule.HisVisitId, oneOperationSchedule.HisScheduleId, oneOperationSchedule.ReqDateTime.ToString("yyyyMMddhh"));

                //已经有同步信息
                if (oneMedVsHisOperApply != null)
                {
                    oneOperationSchedule.ScheduleId = oneMedVsHisOperApply.MedScheduleId;
                    oneOperationSchedule.OperId = oneMedVsHisOperApply.MedScheduleId;
                    oneOperationSchedule.PatientId = oneMedVsHisOperApply.MedPatientId;
                    oneOperationSchedule.VisitId = oneMedVsHisOperApply.MedVisitId;
                    MedicalSytem.Soft.Model.MedOperationSchedule oneMedOperationScheduleTemp = SelectMedOperationSchedule(oneOperationSchedule.PatientId, oneOperationSchedule.VisitId, oneOperationSchedule.ScheduleId);
                    if (oneMedOperationScheduleTemp == null)
                    {
                        InsertMedOperationSchedule(oneOperationSchedule);
                    }
                    else
                    {
                        if (oneOperationSchedule.HisOperStatus == "-1")//取消手术1作废
                        {
                            oneOperationSchedule.OperStatusCode = "-1";
                            UpdateMedOperationSchedule(oneOperationSchedule);
                            return "";
                        }
                        if (oneMedOperationScheduleTemp.OperStatusCode != "0")
                        {

                            oneOperationSchedule.OperStatusCode = oneMedOperationScheduleTemp.OperStatusCode;
                            oneOperationSchedule.OperId = oneMedOperationScheduleTemp.OperId;
                            oneOperationSchedule.ScheduledDateTime = oneMedOperationScheduleTemp.ScheduledDateTime;
                            oneOperationSchedule.OperRoom = oneMedOperationScheduleTemp.OperRoom;
                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.AnesMethod))
                                oneOperationSchedule.AnesMethod = oneMedOperationScheduleTemp.AnesMethod;
                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.AnesDoctor))
                                oneOperationSchedule.AnesDoctor = oneMedOperationScheduleTemp.AnesDoctor;
                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.FirstAnesAssistant))
                                oneOperationSchedule.FirstAnesAssistant = oneMedOperationScheduleTemp.FirstAnesAssistant;
                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.OperRoomNo))
                                oneOperationSchedule.OperRoomNo = oneMedOperationScheduleTemp.OperRoomNo;
                            if (oneMedOperationScheduleTemp.Sequence != (decimal)0)
                                oneOperationSchedule.Sequence = oneMedOperationScheduleTemp.Sequence;
                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.FirstOperAssistant))
                                oneOperationSchedule.FirstOperAssistant = oneMedOperationScheduleTemp.FirstOperAssistant;
                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.SecondOperNurse))
                                oneOperationSchedule.SecondOperNurse = oneMedOperationScheduleTemp.SecondOperNurse;

                            oneOperationSchedule.FirstOperNurse = oneMedOperationScheduleTemp.FirstOperNurse;
                            oneOperationSchedule.SecondOperNurse = oneMedOperationScheduleTemp.SecondOperNurse;

                            oneOperationSchedule.ThirdOperNurse = oneMedOperationScheduleTemp.ThirdOperNurse;

                            oneOperationSchedule.FourthOperNurse = oneMedOperationScheduleTemp.FourthOperNurse;

                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.FirstSupplyNurse))
                                oneOperationSchedule.FirstSupplyNurse = oneMedOperationScheduleTemp.FirstSupplyNurse;
                            if (!string.IsNullOrEmpty(oneMedOperationScheduleTemp.SecondSupplyNurse))
                                oneOperationSchedule.SecondSupplyNurse = oneMedOperationScheduleTemp.SecondSupplyNurse;




                            oneOperationSchedule.OperatingTime = oneMedOperationScheduleTemp.OperatingTime;
                            oneOperationSchedule.AnesConfirm = oneMedOperationScheduleTemp.AnesConfirm;
                            oneOperationSchedule.NurseConfirm = oneMedOperationScheduleTemp.NurseConfirm;


                        }

                        UpdateMedOperationSchedule(oneOperationSchedule);
                    }
                }
                else
                {
                    if (oneOperationSchedule.HisOperStatus == "-1")//取消手术1作废
                    {
                        return "";
                    }

                    //非军惠则转换VISITID
                    if (oneOperationSchedule.VisitId.ToString() == null)
                        oneOperationSchedule.VisitId = (decimal)0;
                    //INP_NO 为onePatsInHospital.VisitId.ToString() 或者 PatMasterIndex.PatientId
                    MedicalSytem.Soft.Model.MedVsHisPat oneMedVsHisPat = SelectMedVsHisPatHis(oneOperationSchedule.PatientId, oneOperationSchedule.HisVisitId, oneOperationSchedule.HisVisitId);
                    if (oneMedVsHisPat == null) //为门诊病人 visitId  = 0
                    {
                        oneMedVsHisPat = new MedicalSytem.Soft.Model.MedVsHisPat();
                        oneMedVsHisPat.MedPatientId = oneOperationSchedule.PatientId;
                        oneMedVsHisPat.MedVisitId = oneOperationSchedule.VisitId;
                        if (oneMedVsHisPat.MedVisitId < decimal.Parse("1"))
                            oneMedVsHisPat.MedVisitId = (decimal)0;
                        if (oneMedVsHisPat.MedVisitId > decimal.Parse("9999"))
                            oneMedVsHisPat.MedVisitId = (decimal)0;
                    }
                    //插入预约手术信息-------------------------------------------------------
                    //得到ScheduleId的序号
                    int OperIdForScheduleId = SelectMaxOperId(oneMedVsHisPat.MedPatientId, oneMedVsHisPat.MedVisitId);
                    //写MedVsHisOperApply中间表的信息
                    oneMedVsHisOperApply = new MedicalSytem.Soft.Model.MedVsHisOperApplyV2();
                    oneMedVsHisOperApply.MedPatientId = oneMedVsHisPat.MedPatientId;
                    oneMedVsHisOperApply.MedVisitId = oneMedVsHisPat.MedVisitId;
                    oneMedVsHisOperApply.MedScheduleId = (decimal)(OperIdForScheduleId + 1);
                    oneMedVsHisOperApply.HisApplyNo = oneOperationSchedule.HisScheduleId;
                    oneMedVsHisOperApply.HisPatientId = oneOperationSchedule.PatientId;
                    oneMedVsHisOperApply.HisVisitId = oneOperationSchedule.HisVisitId;
                    oneMedVsHisOperApply.HisScheduleId = oneOperationSchedule.HisScheduleId;
                    oneMedVsHisOperApply.ReqDateTime = oneOperationSchedule.ReqDateTime.ToString("yyyyMMddhh");

                    if (UpdateMedVsHisOperApplyV2(oneMedVsHisOperApply) == 0)
                        InsertMedVsHisOperApplyV2(oneMedVsHisOperApply);

                    oneOperationSchedule.ScheduleId = oneMedVsHisOperApply.MedScheduleId;
                    oneOperationSchedule.OperId = oneMedVsHisOperApply.MedScheduleId;
                    oneOperationSchedule.PatientId = oneMedVsHisOperApply.MedPatientId;
                    oneOperationSchedule.VisitId = oneMedVsHisOperApply.MedVisitId;

                    if (UpdateMedOperationSchedule(oneOperationSchedule) == 0)
                        InsertMedOperationSchedule(oneOperationSchedule);
                }

                BMedScheduleOperationName boperationName = new BMedScheduleOperationName();
                config.obj = oneOperationSchedule;
                domain.Patient.VisitId = oneOperationSchedule.VisitId;
                domain.Operation.ScheduleId = oneOperationSchedule.ScheduleId;
                domain.Code = "OPER106";
                ReturnMessage += boperationName.PreDataBase(config, domain);

                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细信息" + obj.ToString());
                return "信息接口提示[V4版本]:" + ex.Message;
            }
        }
    }
}
