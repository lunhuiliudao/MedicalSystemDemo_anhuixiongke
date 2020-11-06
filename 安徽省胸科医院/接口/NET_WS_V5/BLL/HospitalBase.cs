using Init;
using MedicalSytem.Soft.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class HospitalBase : IDocareComm
    {

        private static webHis.AnInterface anterface;

        public static webHis.AnInterface Anterface
        {
            get
            {
                if (anterface == null)
                {
                    anterface = new webHis.AnInterface();
                }
                return anterface;
            }
        }

        DateTime datetime;
        decimal dc;
        private DocareInterfaceTest.Service1 service = null;
        public DocareInterfaceTest.Service1 WebService
        {
            get
            {
                if (service == null)
                {
                    service = new DocareInterfaceTest.Service1();
                }
                return service;
            }
        }

        public string GetSqlPara(string para, EnumDataBase database)
        {
            string result = "";
            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        result = para.Replace("@@scheduledDateTimeStart", ":scheduledDateTimeStart")
                            .Replace("@@scheduledDateTimeEnd", ":scheduledDateTimeEnd")
                            .Replace("@@patientid", ":patientid").Replace("@@visitid", ":visitid").Replace("@@inpno", ":inpno")
                            .Replace("@@wardcode", ":wardcode").Replace("@@testno", ":testno")
                            .Replace("@@scheduleId", ":scheduleId");
                        break;
                    }
                case EnumDataBase.OLEDB:
                case EnumDataBase.ODBC:
                    {
                        result = para.Replace("@@patientid", "?").Replace("@@visitid", "?").Replace("@@inpno", "?").Replace("@@wardcode", "?").Replace("@@testno", "?");
                        break;
                    }
                case EnumDataBase.SQLSERVER:
                    {
                        result = para.Replace("@@", "@");  //para.Replace("@@patientid", "@patientid").Replace("@@visitid", "@visitid").Replace("@@inpno", "@inpno").Replace("@@wardcode", "@wardcode").Replace("@@testno", "@testno").Replace("@@");
                        break;
                    }
                default:
                    break;
            }
            return result;
        }

        public virtual string ReturnMessage { get; set; }

        public virtual System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            return null;
        }

        public virtual string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            return "传入参数同步功能不匹配或者未定义 :" + domain.Code;
        }

        public virtual string PreWebServices(InitDocare.Config2 config, ParamInputDomain domain)
        {
            return "传入参数同步功能不匹配或者未定义:" + domain.Code;
        }

        public virtual string PreReceiveMsg(InitDocare.Config2 config, ParamInputDomain domain)
        {
            return "传入参数同步功能不匹配或者未定义:" + domain.Code;
        }

        public virtual string DoExecute(InitDocare.Config2 config, ParamInputDomain domain, ModelBase obj)
        {
            return "";
        }
        public virtual List<MedHisUsers> GetMedHisUsers(DataTable dt)
        {
            decimal dec;
            List<MedHisUsers> result = new List<MedHisUsers>();
            foreach (DataRow dr in dt.Rows)
            {
                MedicalSytem.Soft.Model.MedHisUsers oneHisUsers = new MedicalSytem.Soft.Model.MedHisUsers();

                oneHisUsers.UserJobId = InitDocare.PublicString.SubString(dr["USER_JOB_ID"].ToString().Trim(), 36, false);


                oneHisUsers.UserName = InitDocare.PublicString.SubString(dr["user_name"].ToString().Trim(), 30, false);


                oneHisUsers.UserDeptCode = InitDocare.PublicString.SubString(dr["user_dept_CODE"].ToString().Trim(), 16, false);

                oneHisUsers.UserJob = InitDocare.PublicString.SubString(dr["user_job"].ToString().Trim(), 20, false);

                if (decimal.TryParse(dr["USER_STATUS"].ToString(), out dec))
                    oneHisUsers.UserStatus = Convert.ToDecimal(dr["USER_STATUS"]);

                if (DateTime.TryParse(dr["create_date"].ToString().Trim(), out datetime))
                {
                    oneHisUsers.CreateDate = datetime;
                }
                oneHisUsers.InputCode = InitDocare.PublicString.GetPYString(oneHisUsers.UserName);
                oneHisUsers.InputCode = InitDocare.PublicString.SubString(oneHisUsers.InputCode, 8, false);
                oneHisUsers.Reserved01 = InitDocare.PublicString.SubString(dr["RESERVED01"].ToString().Trim(), 20, false);

                result.Add(oneHisUsers);
            }
            return result;
        }

        public virtual List<MedOperationDict> GetMedOperationDict(DataTable dt)
        {
            List<MedOperationDict> result = new List<MedOperationDict>();
            foreach (DataRow dr in dt.Rows)
            {
                MedOperationDict entity = new MedOperationDict();

                decimal StdIndicator = 0;

                decimal.TryParse(dr["STD_INDICATOR"].ToString().Trim(), out StdIndicator);

                entity.StdIndicator = StdIndicator;

                //InitDocare.LogDALA.Debug("STD_INDICATOR" + StdIndicator);

                decimal ApprovedIndicator = 0;

                decimal.TryParse(dr["APPROVED_INDICATOR"].ToString().Trim(), out ApprovedIndicator);

                entity.ApprovedIndicator = ApprovedIndicator;

                //InitDocare.LogDALA.Debug("APPROVED_INDICATOR" + ApprovedIndicator);

                entity.OperationCode = InitDocare.PublicString.SubString(dr["OPERATION_CODE"].ToString().Trim(), 16, false);

                entity.OperationName = InitDocare.PublicString.SubString(dr["OPERATION_NAME"].ToString().Trim(), 60, false);
                entity.OperationScale = InitDocare.PublicString.SubString(dr["OPERATION_SCALE"].ToString().Trim(), 2, false);
                entity.InputCode = InitDocare.PublicString.SubString(dr["INPUT_CODE"].ToString().Trim(), 8, false);
                result.Add(entity);

            }
            return result;

        }

        public virtual List<MedDeptDict> GetMedDeptDictList(DataTable dt)
        {
            List<MedDeptDict> result = new List<MedDeptDict>();
            foreach (DataRow dr in dt.Rows)
            {
                MedDeptDict dict = new MedDeptDict();
                //if (decimal.TryParse(dr["SORT_NO"].ToString(), out dc))
                //{
                //    dict.SortNo = dc;
                //}
                dict.SortNo = dc++;
                dict.DeptType = dr["DEPT_TYPE"].ToString().Trim();
                dict.DeptAlis = dr["DEPT_ALIAS"].ToString().Trim();
                dict.WardCode = dr["WARD_CODE"].ToString().Trim();
                dict.DeptCode = dr["dept_code"].ToString().Trim();
                dict.DeptName = dr["dept_name"].ToString().Trim();
                dict.InputCode = dr["input_code"].ToString().Trim();
                result.Add(dict);
            }
            return result;
        }

        /// <summary>
        /// 获取患者在院信息
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public virtual MedPatsInHospital GetMedPatsInHospital(DataTable dt)
        {

            MedPatsInHospital onePatsInHospital = null;

            foreach (DataRow oleReader2 in dt.Rows)
            {
                onePatsInHospital = new MedPatsInHospital();
                onePatsInHospital.PatientId = InitDocare.PublicString.SubString(oleReader2["PATIENT_ID"].ToString().Trim(), 20, false);

                onePatsInHospital.Reserved03 = oleReader2["VISIT_ID"].ToString().Trim();

                onePatsInHospital.DEPT_FROM = oleReader2["DEPT_FROM"].ToString().Trim();
                onePatsInHospital.ALERGY_DRUGS = oleReader2["ALERGY_DRUGS"].ToString().Trim();

                if (decimal.TryParse(oleReader2["PATIENT_SOURCE"].ToString().Trim(), out dc))
                {
                    onePatsInHospital.PatientSource = dc;
                }
                else
                {
                    onePatsInHospital.PatientSource = 1;//默认为1
                }
                onePatsInHospital.DepId = (decimal)1;

                onePatsInHospital.WardCode = InitDocare.PublicString.SubString(oleReader2["WARD_CODE"].ToString().Trim(), 16, false);

                onePatsInHospital.DeptCode = InitDocare.PublicString.SubString(oleReader2["DEPT_CODE"].ToString().Trim(), 16, false);

                onePatsInHospital.BedNo = InitDocare.PublicString.SubString(oleReader2["BED_NO"].ToString().Trim(), 20, false);

                if (DateTime.TryParse(oleReader2["ADMISSION_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    onePatsInHospital.AdmissionDateTime = datetime;
                }

                if (DateTime.TryParse(oleReader2["ADM_WARD_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    onePatsInHospital.AdmWardDateTime = datetime;

                }

                onePatsInHospital.Diagnosis = InitDocare.PublicString.SubString(oleReader2["DIAGNOSIS"].ToString().Trim(), 200, false);

                onePatsInHospital.DoctorInCharge = InitDocare.PublicString.SubString(oleReader2["DOCTOR_IN_CHARGE"].ToString().Trim(), 30, false);


                onePatsInHospital.InpNo = oleReader2["INP_NO"].ToString().Trim(); ;

                onePatsInHospital.HospBranch = oleReader2["HOSP_BRANCH"].ToString().Trim(); ;


                onePatsInHospital.BloodType = oleReader2["BLOOD_TYPE"].ToString().Trim(); ;

                onePatsInHospital.BloodTypeRh = oleReader2["BLOOD_TYPE_RH"].ToString().Trim(); ;

                if (decimal.TryParse(oleReader2["PATIENT_SOURCE"].ToString(), out dc))
                {
                    onePatsInHospital.PatientSource = dc;
                }
                if (decimal.TryParse(oleReader2["BODY_HEIGHT"].ToString(), out dc))
                {
                    onePatsInHospital.BodyHeight = dc;
                }
                if (decimal.TryParse(oleReader2["BODY_WEIGHT"].ToString(), out dc))
                {
                    onePatsInHospital.BodyWeight = dc;
                }

                onePatsInHospital.SPECIAL_MARK = oleReader2["SPECIAL_MARK"].ToString().Trim(); ;
                onePatsInHospital.BedNo = oleReader2["BED_NO"].ToString().Trim(); ;
                onePatsInHospital.DEPT_FROM = oleReader2["PATIENT_SOURCE"].ToString().Trim(); ;
                break;
            }
            return onePatsInHospital;
        }

        /// <summary>
        /// 转换患者基本信息
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public virtual MedPatMasterIndex GetMedPatMasterIndex(DataTable dt)
        {
            MedPatMasterIndex PatMasterIndex = null;

            foreach (DataRow oleReader in dt.Rows)
            {
                PatMasterIndex = new MedPatMasterIndex();

                PatMasterIndex.InPno = InitDocare.PublicString.SubString(oleReader["PATIENT_ID"].ToString().Trim(), 30, false);

                PatMasterIndex.PatientId = InitDocare.PublicString.SubString(oleReader["PATIENT_ID"].ToString().Trim(), 20, false);

                PatMasterIndex.Name = InitDocare.PublicString.SubString(oleReader["NAME"].ToString().Trim(), 30, false);

                PatMasterIndex.NamePhonetic = InitDocare.PublicString.SubString(oleReader["NAME_PHONETIC"].ToString().Trim(), 16, false);

                PatMasterIndex.Sex = InitDocare.PublicString.SubString(oleReader["SEX"].ToString().Trim(), 4, false);

                if (DateTime.TryParse(oleReader["DATE_OF_BIRTH"].ToString().Trim(), out datetime))
                {
                    PatMasterIndex.DateOfBirth = datetime;
                }

                PatMasterIndex.BirthPlace = InitDocare.PublicString.SubString(oleReader["BIRTH_PLACE"].ToString().Trim(), 60, false);

                PatMasterIndex.Citizenship = InitDocare.PublicString.SubString(oleReader["CITIZENSHIP"].ToString().Trim(), 30, false);

                PatMasterIndex.Nation = InitDocare.PublicString.SubString(oleReader["NATION"].ToString().Trim(), 30, false);

                PatMasterIndex.IdNo = InitDocare.PublicString.SubString(oleReader["ID_NO"].ToString().Trim(), 20, false);

                //PatMasterIndex.ChargeType = InitDocare.PublicString.SubString(oleReader["CHARGE_TYPE"].ToString().Trim(), 30, false);

                PatMasterIndex.UnitInContract = InitDocare.PublicString.SubString(oleReader["UNIT_IN_CONTRACT"].ToString().Trim(), 30, false);

                PatMasterIndex.MailingAddress = InitDocare.PublicString.SubString(oleReader["MAILING_ADDRESS"].ToString().Trim(), 80, false);


                PatMasterIndex.PhoneNumberHome = InitDocare.PublicString.SubString(oleReader["PHONE_NUMBER_HOME"].ToString().Trim(), 40, false);

                PatMasterIndex.PhoneNumberBusiness = InitDocare.PublicString.SubString(oleReader["PHONE_NUMBER_BUSINESS"].ToString().Trim(), 40, false);

                PatMasterIndex.NextOfKin = InitDocare.PublicString.SubString(oleReader["NEXT_OF_KIN"].ToString().Trim(), 30, false);

                PatMasterIndex.Relationship = InitDocare.PublicString.SubString(oleReader["RELATIONSHIP"].ToString().Trim(), 20, false);

                PatMasterIndex.NextOfKinAddr = InitDocare.PublicString.SubString(oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim(), 80, false);

                PatMasterIndex.NextOfKinZipCode = InitDocare.PublicString.SubString(oleReader["NEXT_OF_KIN_ZIP_CODE"].ToString().Trim(), 6, false);

                PatMasterIndex.NextOfKinPhone = InitDocare.PublicString.SubString(oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim(), 40, false);

                PatMasterIndex.Identity = InitDocare.PublicString.SubString(oleReader["IDENTITY"].ToString().Trim(), 30, false);

                PatMasterIndex.ChargeType = InitDocare.PublicString.SubString(oleReader["CHARGE_TYPE"].ToString().Trim(), 30, false);

                if (dt.Columns.Contains("LCLJ"))
                {
                    PatMasterIndex.Lclj = InitDocare.PublicString.SubString(oleReader["LCLJ"].ToString().Trim(), 30, false);
                }
                break;
            }

            return PatMasterIndex;
        }

        public virtual MedPatVisit GetMedPatVisit(DataTable dt)
        {
            MedPatVisit PatVisit = null;

            foreach (DataRow oleReader2 in dt.Rows)
            {
                PatVisit = new MedPatVisit();
                PatVisit.PatientId = oleReader2["PATIENT_ID"].ToString().Trim(); ;
                PatVisit.InpNo = oleReader2["INP_NO"].ToString().Trim(); ;
                PatVisit.HospBranch = oleReader2["HOSP_BRANCH"].ToString().Trim(); ;
                if (decimal.TryParse(oleReader2["PATIENT_SOURCE"].ToString().Trim(), out dc))
                {
                    PatVisit.PatientSource = dc;
                }
                else
                {
                    PatVisit.PatientSource = 1;
                }
                PatVisit.Reserved03 = oleReader2["VISIT_ID"].ToString().Trim();
                PatVisit.Reserved01 = InitDocare.PublicString.SubString(oleReader2["WARD_CODE"].ToString().Trim(), 16, false);//WardCode
                PatVisit.DEPT_ADMISSION_TO = InitDocare.PublicString.SubString(oleReader2["DEPT_CODE"].ToString().Trim(), 16, false);
                PatVisit.Reserved02 = InitDocare.PublicString.SubString(oleReader2["BED_NO"].ToString().Trim(), 50, false);//bed_no

                if (DateTime.TryParse(oleReader2["ADMISSION_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    PatVisit.AdmissionDateTime = datetime;
                }

                PatVisit.Reserved05 = oleReader2["ADM_WARD_DATE_TIME"].ToString().Trim();

                PatVisit.Reserved04 = InitDocare.PublicString.SubString(oleReader2["DIAGNOSIS"].ToString().Trim(), 50, false);
                PatVisit.DoctorInCharge = InitDocare.PublicString.SubString(oleReader2["DOCTOR_IN_CHARGE"].ToString().Trim(), 30, false);
                PatVisit.ChargeType = InitDocare.PublicString.SubString(oleReader2["RESERVED01"].ToString().Trim(), 30, false);
                break;
            }
            return PatVisit;
        }

        public virtual List<MedOperationSchedule> GetMedOperationSchedule(DataTable dt)
        {
            List<MedOperationSchedule> scheduleList = new List<MedOperationSchedule>();

            foreach (DataRow dr in dt.Rows)
            {
                MedOperationSchedule entity = new MedOperationSchedule();
                entity.PatientId = dr["Patient_Id"].ToString().Trim();
                entity.HisPatientId = dr["Patient_Id"].ToString().Trim();
                entity.HisVisitId = dr["Visit_Id"].ToString().Trim();
                entity.HisScheduleId = dr["Schedule_Id"].ToString().Trim();
                entity.HisOperStatus = dr["his_oper_status"].ToString().Trim();
                entity.AnesConfirm = "0";
                entity.AnesDoctor = dr["anes_doctor"].ToString().Trim();
                entity.AnesMethod = dr["ANES_METHOD"].ToString().Trim();
                //entity.AsaGrade = dr["Asa_Grade"].ToString();
                entity.BedNo = dr["Bed_No"].ToString().Trim();
                // entity.CpbDoctor = dr["Cpb_Doctor"].ToString();
                entity.DeptCode = dr["dept_code"].ToString().Trim();
                entity.DiagBeforeOperation = dr["Diag_Before_Operation"].ToString().Trim();
                if (Decimal.TryParse(dr["emergency_ind"].ToString().Trim(), out dc))
                {
                    entity.EmergencyInd = dc;
                }
                entity.FirstAnesAssistant = dr["first_anes_assistant"].ToString().Trim();
                entity.FirstAnesNurse = dr["first_anes_nurse"].ToString().Trim();
                //entity.FirstCpbAssistant = dr["First_Cpb_Assistant"].ToString().Trim();
                entity.FirstOperAssistant = dr["first_oper_assistant"].ToString().Trim();
                entity.FirstOperNurse = dr["first_oper_nurse"].ToString().Trim();
                //entity.FirstPacuAssistant = dr["First_Pacu_Assistant"].ToString()
                //entity.FirstPacuNurse = dr["First_Pacu_Nurse"].ToString();
                entity.FirstSupplyNurse = dr["first_supply_nurse"].ToString();
                //entity.FourthAnesAssistant = dr["Fourth_Anes_Assistant"].ToString().Trim();
                //   entity.FourthCpbAssistant = dr["Fourth_Cpb_Assistant"].ToString();
                // entity.FourthOperAssistant = dr["Fourth_Oper_Assistant"].ToString();
                // entity.FourthSupplyNurse = dr["Fourth_Supply_Nurse"].ToString();
                // entity.FourthOperNurse = dr["Fourth_Oper_Nurse"].ToString();
                // entity.HospBranch = dr["Hosp_Branch"].ToString();

                //if (decimal.TryParse(dr["INFECTED_IND"].ToString(), out dc))
                //    entity.InfectedInd = dc;

                if (Decimal.TryParse(dr["isolation_ind"].ToString(), out dc))
                    entity.IsolationInd = dc;
                entity.NotesOnOperation = dr["NOTES_ON_OPERATION"].ToString().Trim();
                entity.NurseConfirm = "0";
                //if (Decimal.TryParse(dr["Operating_Time"].ToString(), out dc))
                //{
                //    entity.OperatingTime = dc;
                //}
                //entity.OperationName = dr["Operation_Name"].ToString();
                entity.Operator = dr["operator"].ToString().Trim(); ;
                //entity.OperClass = dr["Oper_Class"].ToString().Trim(); ;
                
                entity.OperDeptCode = dr["oper_dept_code"].ToString().Trim();

                //entity.OperPosition = dr["Oper_Position"].ToString().Trim(); ;

                string operRoom = dr["oper_room"].ToString().Trim();
                if (operRoom == "1040210")
                {
                    operRoom = "1040200";
                }
                entity.OperRoom = operRoom;
                //entity.OperRoom = dr["oper_room"].ToString().Trim(); ;

                entity.OperRoomNo = dr["oper_room_no"].ToString().Trim();
                entity.OperScale = dr["OPER_SCALE"].ToString().Trim();
                //if (Decimal.TryParse(dr["Oper_Source"].ToString().Trim(), out dc))
                //{
                //    entity.OperSource = dc;
                //}
                entity.OperStatusCode = "0";
                //   entity.PacuDoctor = dr["Pacu_Doctor"].ToString();
                entity.PatientCondition = dr["PATIENT_CONDITION"].ToString();
                //if (Decimal.TryParse(dr["Radiate_Ind"].ToString().Trim(), out dc))
                //{
                //    entity.RadiateInd = dc;
                //}

                if (DateTime.TryParse(dr["Scheduled_Date_Time"].ToString().Trim(), out datetime))
                {
                    entity.ScheduledDateTime = datetime;
                }
                if (DateTime.TryParse(dr["Req_Date_Time"].ToString().Trim(), out datetime))
                {
                    entity.ReqDateTime = datetime;
                }
                else
                {
                    entity.ReqDateTime = entity.ScheduledDateTime;
                }
                entity.SecondAnesAssistant = dr["second_anes_assistant"].ToString().Trim(); ;
                // entity.SecondAnesNurse = dr["Second_Anes_Nurse"].ToString();
                // entity.SecondCpbAssistant = dr["Second_Cpb_Assistant"].ToString();
                entity.SecondOperAssistant = dr["Second_Oper_Assistant"].ToString();
                // entity.SecondOperNurse = dr["Second_Oper_Nurse"].ToString();
                //   entity.SecondPacuAssistant = dr["Second_Pacu_Assistant"].ToString();
                //  entity.SecondPacuNurse = dr["Second_Pacu_Nurse"].ToString();
                //  entity.SecondSupplyNurse = dr["Second_Supply_Nurse"].ToString();
                if (Decimal.TryParse(dr["Sequence"].ToString(), out dc))
                {
                    entity.Sequence = dc;
                }
                // entity.SpecialEquipment = dr["Special_Equipment"].ToString();
                // entity.SpecialInfect = dr["Special_Infect"].ToString();
                entity.Surgeon = dr["surgeon"].ToString().Trim(); ;
                //   entity.ThirdAnesNurse = dr["Third_Anes_Nurse"].ToString();
                //   entity.ThirdCpbAssistant = dr["Third_Cpb_Assistant"].ToString();
                entity.ThirdAnesAssistant = dr["third_anes_assistant"].ToString().Trim(); ;
                // entity.ThirdOperAssistant = dr["Third_Oper_Assistant"].ToString();
                // entity.ThirdOperNurse = dr["Third_Oper_Nurse"].ToString();
                // entity.ThirdSupplyNurse = dr["Third_Supply_Nurse"].ToString();
                //entity.WardCode = dr["WARD_CODE"].ToString().Trim();
                if (dr.Table.Columns.Contains("WOUND_TYPE") && !dr.IsNull("WOUND_TYPE"))
                {
                    entity.WoundType = dr["WOUND_TYPE"].ToString().Trim();
                }
                scheduleList.Add(entity);
            }
            return scheduleList;
        }

        public virtual List<MedScheduledOperationName> GetMedScheduledOperationName(DataTable dt)
        {
            int i = 1;
            List<MedScheduledOperationName> scheduleNameList = new List<MedScheduledOperationName>();
            foreach (DataRow dr in dt.Rows)
            {
                MedScheduledOperationName entity = new MedScheduledOperationName();
                entity.PatientId = dr["PATIENT_ID"].ToString().Trim(); ;
                entity.OperCode = dr["OPER_CODE"].ToString().Trim(); ;
                entity.OperName = dr["OPER_NAME"].ToString().Trim(); ;
                entity.OperNo = i++;
                entity.OperScale = dr["OPER_SCALE"].ToString().Trim(); ;
                entity.WoundType = dr["WOUND_TYPE"].ToString().Trim(); ;
                scheduleNameList.Add(entity);
            }
            return scheduleNameList;
        }


        public virtual List<MedOrders> GetMedOrder(DataTable dt)
        {
            decimal dec = 0;
            List<MedOrders> result = new List<MedOrders>();
            foreach (DataRow dr in dt.Rows)
            {
                MedicalSytem.Soft.Model.MedOrders order = new MedicalSytem.Soft.Model.MedOrders();

                order.PatientId = InitDocare.PublicString.SubString(dr["PATIENT_ID"].ToString(), 20, false);

                order.HisOrderSubNo = dr["ORDER_NO"].ToString().Trim(); ;



                if (dr["ORDER_SUB_NO"].Equals(DBNull.Value) || string.IsNullOrEmpty(dr["ORDER_SUB_NO"].ToString()))
                {
                    order.OrderNo = order.HisOrderSubNo;
                }
                else
                {
                    order.OrderNo = dr["ORDER_SUB_NO"].ToString();
                }

                //InitDocare.LogDALA.Debug("order.HisOrderSubNo:" + order.HisOrderSubNo + "  order.OrderNo" + order.OrderNo);

                order.RepeatIndicator = dr["REPEAT_INDICATOR"].ToString() == "Y" ? 1 : 0;

                order.OrderText = InitDocare.PublicString.SubString(dr["ORDER_TEXT"].ToString().Trim(), 200, false);

                order.OrderCode = InitDocare.PublicString.SubString(dr["ORDER_CODE"].ToString().Trim(), 20, false);

                if (decimal.TryParse(dr["DOSAGE"].ToString().Trim(), out dc))
                {
                    order.Dosage = dc;
                }

                order.DosageUnits = InitDocare.PublicString.SubString(dr["DOSAGE_UNITS"].ToString().Trim(), 8, false);

                order.Administration = InitDocare.PublicString.SubString(dr["ADMINISTRATION"].ToString().Trim(), 30, false);

                if (DateTime.TryParse(dr["START_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    order.StartDateTime = datetime;
                }

                if (DateTime.TryParse(dr["STOP_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    order.StopDateTime = datetime;
                }
                order.OrderClass = dr["ORDER_CLASS"].ToString().Trim();

                order.DurationUnits = InitDocare.PublicString.SubString(dr["DURATION_UNITS"].ToString().Trim(), 8, false);

                //order.Frequency = InitDocare.PublicString.SubString(oleReader["FREQUENCY"].ToString().Trim(), 30, false);
                order.Frequency = InitDocare.PublicString.SubString(dr["FREQUENCY"].ToString().Trim(), 30, false);
                //把频次转换成执行时间，需要在MedPerformDefaultSchedule中进行配置，然后下面的PERFORM_SCHEDULE字段就可以屏蔽了
                MedicalSytem.Soft.Model.MedPerformDefaultSchedule oneMedPerformDefaultSchedule = SelectMedPerformDefaultSchedule(dr["FREQUENCY"].ToString());
                if (oneMedPerformDefaultSchedule == null)
                    order.PerformSchedule = "";
                else
                    order.PerformSchedule = oneMedPerformDefaultSchedule.DefaultSchedule;


                order.FreqIntervalUnit = InitDocare.PublicString.SubString(dr["FREQ_INTERVAL_UNIT"].ToString().Trim(), 8, false);

                order.FreqDetail = InitDocare.PublicString.SubString(dr["FREQ_DETAIL"].ToString().Trim(), 30, false);

                if (decimal.TryParse(dr["QTY"].ToString(), out dec))
                {
                    order.Qty = dec;
                }

                order.PerformResult = InitDocare.PublicString.SubString(dr["PERFORM_RESULT"].ToString().Trim(), 20, false);

                order.OrderingDept = InitDocare.PublicString.SubString(dr["ORDERING_DEPT"].ToString().Trim(), 16, false);

                order.Doctor = InitDocare.PublicString.SubString(dr["DOCTOR"].ToString().Trim(), 30, false);

                order.StopDoctor = InitDocare.PublicString.SubString(dr["STOP_DOCTOR"].ToString().Trim(), 30, false);

                order.Nurse = InitDocare.PublicString.SubString(dr["NURSE"].ToString().Trim(), 30, false);

                order.StopNurse = InitDocare.PublicString.SubString(dr["STOP_NURSE"].ToString().Trim(), 30, false);

                if (DateTime.TryParse(dr["ENTER_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    order.EnterDateTime = datetime;
                }

                if (DateTime.TryParse(dr["STOP_ORDER_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    order.StopOrderDateTime = datetime;
                }

                //医嘱的执行状态：1、新开；2-校对；3-停止；4-作废
                order.OrderStatus = InitDocare.PublicString.SubString(dr["ORDER_STATUS"].ToString().Trim(), 1, false);

                string mess = dr["CURRENT_PRESC_NO"].ToString().Trim(); ;

                order.Reserved1 = mess;

                InitDocare.LogDALA.Debug(" order.Reserved1:" + order.Reserved1);
                //if (mess.IndexOf("!!") >= 0)
                //{
                //    mess = mess.Replace("!!", "!");

                //    order.Reserved2 = mess.Split('!')[1];
                //}
                // order.DispenseMemos = InitDocare.PublicString.SubString(dr["DISPENSE_MEMOS"].ToString(), 20, false);
                result.Add(order);

            }
            return result;
        }

        public virtual List<MedPatsInHospital> GetMedPatsInHospitalList(DataTable dt)
        {
            List<MedPatsInHospital> pats = new List<MedPatsInHospital>();
            foreach (DataRow oleReader2 in dt.Rows)
            {
                MedPatsInHospital onePatsInHospital = new MedPatsInHospital();
                onePatsInHospital.PatientId = InitDocare.PublicString.SubString(oleReader2["PATIENT_ID"].ToString().Trim(), 20, false);

                onePatsInHospital.Reserved03 = oleReader2["VISIT_ID"].ToString().Trim();

                onePatsInHospital.InpNo = oleReader2["INP_NO"].ToString().Trim();

                onePatsInHospital.DepId = (decimal)1;
                if (decimal.TryParse(oleReader2["PATIENT_SOURCE"].ToString().Trim(), out dc))
                {
                    onePatsInHospital.PatientSource = dc;
                }
                else
                {
                    onePatsInHospital.PatientSource = 1;//默认为1
                }
                onePatsInHospital.WardCode = InitDocare.PublicString.SubString(oleReader2["WARD_CODE"].ToString().Trim(), 16, false);

                onePatsInHospital.DeptCode = InitDocare.PublicString.SubString(oleReader2["DEPT_CODE"].ToString().Trim(), 16, false);

                onePatsInHospital.BedNo = InitDocare.PublicString.SubString(oleReader2["BED_NO"].ToString().Trim(), 20, false);

                if (DateTime.TryParse(oleReader2["ADMISSION_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    onePatsInHospital.AdmissionDateTime = datetime;
                }
                if (DateTime.TryParse(oleReader2["ADM_WARD_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    onePatsInHospital.AdmWardDateTime = datetime;

                }
                onePatsInHospital.Diagnosis = InitDocare.PublicString.SubString(oleReader2["DIAGNOSIS"].ToString().Trim(), 200, false);

                onePatsInHospital.DoctorInCharge = InitDocare.PublicString.SubString(oleReader2["DOCTOR_IN_CHARGE"].ToString().Trim(), 30, false);

                onePatsInHospital.HospBranch = oleReader2["HOSP_BRANCH"].ToString().Trim(); ;

                onePatsInHospital.BloodType = oleReader2["BLOOD_TYPE"].ToString().Trim(); ;

                onePatsInHospital.BloodTypeRh = oleReader2["BLOOD_TYPE_RH"].ToString().Trim(); ;

                if (decimal.TryParse(oleReader2["PATIENT_SOURCE"].ToString().Trim(), out dc))
                {
                    onePatsInHospital.PatientSource = dc;
                }
                if (decimal.TryParse(oleReader2["BODY_HEIGHT"].ToString().Trim(), out dc))
                {
                    onePatsInHospital.BodyHeight = dc;
                }
                if (decimal.TryParse(oleReader2["BODY_WEIGHT"].ToString(), out dc))
                {
                    onePatsInHospital.BodyWeight = dc;
                }
                onePatsInHospital.DEPT_FROM = oleReader2["PATIENT_SOURCE"].ToString().Trim();

                pats.Add(onePatsInHospital);
            }

            return pats;

        }

        public virtual List<MedLabTestMaster> GetMedLabTestMasterList(DataTable dt)
        {
            List<MedLabTestMaster> result = new List<MedLabTestMaster>();
            foreach (DataRow dr in dt.Rows)
            {
                MedLabTestMaster oneLabTestMaster = new MedLabTestMaster();

                if (decimal.TryParse(dr["Age"].ToString(), out dc))
                {
                    oneLabTestMaster.Age = dc;
                }
                oneLabTestMaster.Barcode = dr["Barcode"].ToString();

                oneLabTestMaster.TestNo = InitDocare.PublicString.SubString(dr["TEST_NO"].ToString().Trim(), 20, false);

                oneLabTestMaster.PatientId = InitDocare.PublicString.SubString(dr["PATIENT_ID"].ToString().Trim(), 20, false);


                string HisVisitID = string.Empty;

                HisVisitID = dr["VISIT_ID"].ToString().Trim();

                oneLabTestMaster.WorkingId = InitDocare.PublicString.SubString(dr["WORKING_ID"].ToString().Trim(), 20, false);

                oneLabTestMaster.Name = InitDocare.PublicString.SubString(dr["NAME"].ToString().Trim(), 30, false);

                //显示在界面上的--检验目的
                oneLabTestMaster.TestCause = InitDocare.PublicString.SubString(dr["TEST_CAUSE"].ToString().Trim(), 500, false);

                oneLabTestMaster.RelevantClinicDiag = InitDocare.PublicString.SubString(dr["RELEVANT_CLINIC_DIAG"].ToString().Trim(), 200, false);

                oneLabTestMaster.Specimen = InitDocare.PublicString.SubString(dr["SPECIMEN"].ToString().Trim(), 100, false);

                if (DateTime.TryParse(dr["SPCM_RECEIVED_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    oneLabTestMaster.SpcmReceivedDateTime = datetime;
                }

                oneLabTestMaster.OrderingDept = InitDocare.PublicString.SubString(dr["ORDERING_DEPT"].ToString().Trim(), 16, false);

                oneLabTestMaster.OrderingProvider = InitDocare.PublicString.SubString(dr["ORDERING_PROVIDER"].ToString().Trim(), 30, false);

                oneLabTestMaster.PerformedBy = InitDocare.PublicString.SubString(dr["PERFORMED_BY"].ToString().Trim(), 16, false);
                oneLabTestMaster.ResultStatus = InitDocare.PublicString.SubString(dr["RESULT_STATUS"].ToString().Trim(), 1, false);


                if (DateTime.TryParse(dr["RESULTS_RPT_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    oneLabTestMaster.ResultsRptDateTime = datetime;
                    oneLabTestMaster.ExecuteDate = datetime;
                }
                oneLabTestMaster.Transcriptionist = InitDocare.PublicString.SubString(dr["TRANSCRIPTIONIST"].ToString().Trim(), 30, false);

                oneLabTestMaster.VerifiedBy = InitDocare.PublicString.SubString(dr["VERIFIED_BY"].ToString().Trim(), 8, false);
                result.Add(oneLabTestMaster);
            }
            return result;
        }

        public virtual List<MedLabResult> GetMedLabTestResultList(DataTable dt)
        {
            decimal i = 1;
            List<MedLabResult> result = new List<MedLabResult>();
            foreach (DataRow dr in dt.Rows)
            {
                MedLabResult oneMedLabResult = new MedLabResult();
                if (decimal.TryParse(dr["Item_No"].ToString().Trim(), out dc))
                {
                    oneMedLabResult.ItemNo = dc;
                }
                else
                {
                    oneMedLabResult.ItemNo = i++;
                }
                oneMedLabResult.PrintOrder = oneMedLabResult.ItemNo;
                oneMedLabResult.AbnormalIndicator = dr["ABNORMAL_INDICATOR"].ToString().Trim();
                oneMedLabResult.InstrumentId = dr["InstrumentId"].ToString().Trim();
                oneMedLabResult.TestNo = dr["TEST_NO"].ToString().Trim();
                oneMedLabResult.ReferenceResult = dr["REFERENCE_RESULT"].ToString().Trim();
                if (DateTime.TryParse(dr["RESULT_DATE_TIME"].ToString().Trim(), out datetime))
                {
                    oneMedLabResult.ResultDateTime = datetime;
                }
                oneMedLabResult.Units = dr["Units"].ToString().Trim();
                oneMedLabResult.Result = dr["Result"].ToString().Trim();
                oneMedLabResult.ReportItemName = dr["REPORT_ITEM_NAME"].ToString().Trim();
                oneMedLabResult.ReportItemCode = dr["REPORT_ITEM_CODE"].ToString().Trim();

                result.Add(oneMedLabResult);
            }
            return result;
        }

    }
}
