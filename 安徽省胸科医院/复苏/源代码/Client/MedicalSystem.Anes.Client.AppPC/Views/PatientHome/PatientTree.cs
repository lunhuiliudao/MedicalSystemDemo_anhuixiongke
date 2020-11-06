using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;
using Medicalsystem.Anes.Framework.Utilities;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatientTree : BaseView
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        string patientID = string.Empty;
        decimal visitID = 0;
        decimal operID = 0;
        public PatientTree(string _patientID, decimal _visitID, decimal _operID)
        {
            InitializeComponent();

            patientID = _patientID;
            visitID = _visitID;
            operID = _operID;
        }

        private void PatientTree_Load(object sender, EventArgs e)
        {


            MED_PATIENT_CARD cardRow = patientInfoRepository.GetPatCard(patientID, (int)visitID, (int)operID).Data;
            labelName.Text = GetValue(cardRow.NAME);
            labelBaseInfo.Text = string.Format("{0}    {1}    {2}", GetValue(cardRow.SEX), DateDiff.CalAge(cardRow.DATE_OF_BIRTH.Value, cardRow.SCHEDULED_DATE_TIME.Value), GetValue(cardRow.INP_NO));

            MED_PAT_VISIT patVisit = operationInfoRepository.GetPatVisit(patientID, (int)visitID).Data;

            if (patVisit == null)
                patVisit = new MED_PAT_VISIT();

            string admission_date_time = string.Empty;
            if (patVisit.ADMISSION_DATE_TIME != null)
                admission_date_time = patVisit.ADMISSION_DATE_TIME.Value.ToString("yyyy-MM-dd");

            labelZD.Text = string.Format("{0}{1}{2}", admission_date_time, GetValue(patVisit.PAT_ADM_CONDITION), GetValue(patVisit.INSURANCE_TYPE));

            #region 术后随访
            List<MED_ANESTHESIA_INQUIRY> anesthesia_inquiry = operationInfoRepository.GetAnesInquiryList(patientID, (int)visitID, (int)operID).Data;
            if (anesthesia_inquiry != null && anesthesia_inquiry.Count > 0)
            {
                labelINQUIRY_DATE.Text = anesthesia_inquiry[0].INQUIRY_DATE.ToString("yyyy-MM-dd");
                labelDocName.Text = RefUsersDT(anesthesia_inquiry[0].INQUIRY_DOCTOR);
            }
            else
            {
                labelINQUIRY_DATE.Text = string.Empty;
                labelDocName.Text = string.Empty;
            }
            #endregion

            #region 患者复苏

            string[] tempArr = new string[10] { "", "", "", "", "", "", "", "", "", "" };
            StringBuilder sb = new StringBuilder();
            sb.Append("入室：{0}     出室：{1}\r\n");
            sb.Append("复苏市时长：{2}分钟\r\n");
            sb.Append("入室情况：体温{3}℃ 意识：{4} 呼吸：{5}次/分\r\n");
            sb.Append("苏醒评分：{6}分\r\n");
            sb.Append("出室情况：体温{7}℃ 意识：{8} 呼吸：{9}次/分\r\n");

            if (cardRow.IN_PACU_DATE_TIME != null)
            {
                labelFuSuDate.Text = cardRow.IN_PACU_DATE_TIME.Value.ToString("yyyy-MM-dd");
                tempArr[0] = cardRow.IN_PACU_DATE_TIME.Value.ToString("HH:mm");
            }
            else
            {
                labelFuSuDate.Text = string.Empty;
            }

            if (cardRow.OUT_PACU_DATE_TIME != null)
                tempArr[1] = cardRow.OUT_PACU_DATE_TIME.Value.ToString("HH:mm");

            if (cardRow.IN_PACU_DATE_TIME != null && cardRow.OUT_PACU_DATE_TIME != null)
                tempArr[2] = (cardRow.OUT_PACU_DATE_TIME.Value - cardRow.IN_PACU_DATE_TIME.Value).Minutes.ToString();
            //入室
            MED_CONFIRMATION_PACU in_confirmation_pacu = operationInfoRepository.GetConfirmationPACU(patientID, (int)visitID, (int)operID, 45).Data;
            if (in_confirmation_pacu != null)
            {
                tempArr[3] = in_confirmation_pacu.BODY_TEMP.Value.ToString();
                tempArr[4] = in_confirmation_pacu.CONSCIOUSNESS;
                tempArr[5] = in_confirmation_pacu.RESP.Value.ToString();
            }
            List<MED_STEWARD_MARK> steward_mark = operationInfoRepository.GetStewardMarkList(patientID, (int)visitID, (int)operID).Data;
            if (steward_mark != null && steward_mark.Count > 0)
                tempArr[6] = steward_mark[steward_mark.Count - 1].TOTAL_MATK.ToString();
            //出室
            MED_CONFIRMATION_PACU out_confirmation_pacu = operationInfoRepository.GetConfirmationPACU(patientID, (int)visitID, (int)operID, 55).Data;
            if (out_confirmation_pacu != null)
            {
                tempArr[7] = out_confirmation_pacu.BODY_TEMP.Value.ToString();
                tempArr[8] = out_confirmation_pacu.CONSCIOUSNESS;
                tempArr[9] = out_confirmation_pacu.RESP.Value.ToString();
            }

            labelPACU.Text = string.Format(sb.ToString(), tempArr);



            #endregion


            #region  术中麻醉
            MED_ANESTHESIA_INPUT_DATA input_data = operationInfoRepository.GetAnesInputData(patientID, (int)visitID, (int)operID).Data;
            if (cardRow.START_DATE_TIME != null)
                labelShouShuZhongDate.Text = cardRow.START_DATE_TIME.Value.ToString("yyyy-MM-dd");
            else
                labelShouShuZhongDate.Text = string.Empty;

            string ANALGESIA_EFFECT = string.Empty;
            if (input_data != null)
            {
                ANALGESIA_EFFECT = input_data.ANALGESIA_EFFECT;
            }

            if (cardRow.OUT_DATE_TIME != null && cardRow.IN_DATE_TIME != null)
            {

                TimeSpan span = (TimeSpan)(cardRow.OUT_DATE_TIME - cardRow.IN_DATE_TIME);
                int hour = span.Days * 24;
                lbloperTime.Text = string.Format("手术时长：{0}小时 {1}分钟   麻醉效果：{2}", hour + span.Hours, span.Minutes, ANALGESIA_EFFECT);
                lbInRoomTime.Text = cardRow.IN_DATE_TIME.Value.ToString("HH:mm");
                lbAnesStartTime.Text = cardRow.ANES_START_TIME.Value.ToString("HH:mm");
                lbOperStartTime.Text = cardRow.START_DATE_TIME.Value.ToString("HH:mm");
                lbOperEndTime.Text = cardRow.END_DATE_TIME.Value.ToString("HH:mm");
                lbAnesEndTime.Text = cardRow.ANES_END_TIME.Value.ToString("HH:mm");
                lbOutRomTime.Text = cardRow.OUT_DATE_TIME.Value.ToString("HH:mm");
            }
            else
            {
                lbloperTime.Text = string.Format("手术时长：            麻醉效果：");
                lbInRoomTime.Text = "--:--";
                lbAnesStartTime.Text = "--:--";
                lbAnesStartTime.Text = "--:--";
                lbOperStartTime.Text = "--:--";
                lbOperEndTime.Text = "--:--";
                lbAnesEndTime.Text = "--:--";
                lbOutRomTime.Text = "--:--";
            }

            MED_OPERATION_MASTER_EXT master_ext = operationInfoRepository.GetOperMasterExt(patientID, (int)visitID, (int)operID).Data;

            string[] arrayInOrOut = new string[8] { "", "", "", "", "", "", "", "" };
            if (master_ext == null)
                master_ext = new MED_OPERATION_MASTER_EXT();
            if (master_ext.INFUSION_TRAN_VOL != null)
                arrayInOrOut[0] = GetValue(master_ext.INFUSION_TRAN_VOL.ToString());

            if (master_ext.OUT_FLUIDS_AMOUNT != null)
                arrayInOrOut[1] = GetValue(master_ext.OUT_FLUIDS_AMOUNT.ToString());

            if (master_ext.BLOOD_TRANSFUSED != null)
                arrayInOrOut[2] = GetValue(master_ext.BLOOD_TRANSFUSED.ToString());

            if (master_ext.CRY_WATHER != null)
                arrayInOrOut[3] = GetValue(master_ext.CRY_WATHER.ToString());


            List<MED_VITAL_SIGN> vitalSignList = new OperationVitalSignRepository().GetVitalSignData(patientID, (int)visitID, (int)operID, "0", false);
            if (vitalSignList != null && vitalSignList.Count > 0)
            {
                DateTime lastTime = vitalSignList[vitalSignList.Count - 1].TIME_POINT;
                vitalSignList = vitalSignList.Where(p => p.TIME_POINT == lastTime).ToList();
                foreach (MED_VITAL_SIGN row in vitalSignList)
                {
                    if (row.ITEM_CODE == "100") //体温
                    {
                        arrayInOrOut[4] = GetValue(row.ITEM_VALUE);
                    }
                    else if (row.ITEM_CODE == "89")//血压高
                    {
                        arrayInOrOut[5] = GetValue(row.ITEM_VALUE);
                    }
                    else if (row.ITEM_CODE == "90")//血压低
                    {
                        arrayInOrOut[6] = GetValue(row.ITEM_VALUE);
                    }
                    else if (row.ITEM_CODE == "44")//脉搏
                    {
                        arrayInOrOut[7] = GetValue(row.ITEM_VALUE);
                    }
                }
            }

            labelInOrOut.Text = string.Format("术中输液：入量：{0}ml 出量：{1}ml\r\n输血：{2}ml 自体血：{3}\r\n出室时：体温：{4}℃ 血压：{5}/{6} 脉搏：{7}", arrayInOrOut);

            MED_OPERATION_MASTER master = operationInfoRepository.GetOperMaster(patientID, (int)visitID, (int)operID).Data;

            labelAnesOper.Text = string.Format("麻：{0}  护：{1}\r\n手：{2}",
   RefUsersDT(master.ANES_DOCTOR) + " " + RefUsersDT(master.FIRST_ANES_ASSISTANT),
     RefUsersDT(master.FIRST_OPER_NURSE) + " " + RefUsersDT(master.FIRST_SUPPLY_NURSE),
     RefUsersDT(master.SURGEON) + " " + RefUsersDT(master.FIRST_OPER_ASSISTANT));

            #endregion

            #region 术前访视
            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = operationInfoRepository.GetAnesPlanExam(patientID, (int)visitID, (int)operID).Data;
            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = operationInfoRepository.GetAnesPlanPmh(patientID, (int)visitID, (int)operID).Data;
            MED_ANESTHESIA_PLAN anesPlan = operationInfoRepository.GetAnesPlan(patientID, (int)visitID, (int)operID).Data;


            if (anesPlanExam == null)
                anesPlanExam = new MED_ANESTHESIA_PLAN_EXAM();

            if (anesPlanPmh == null)
                anesPlanPmh = new MED_ANESTHESIA_PLAN_PMH();

            if (anesPlan == null)
                anesPlan = new MED_ANESTHESIA_PLAN();


            if (anesPlan.INQUIRY_BEFORE_DATE != null)
                labelFangShiDate.Text = anesPlan.INQUIRY_BEFORE_DATE.Value.ToString("yyyy-MM-dd");
            else
                labelFangShiDate.Text = string.Empty;

            labelFangShiName.Text = GetValue(anesPlan.INQUIRY_DOCTOR);
            labelPatient.Text = string.Format("{0}cm，{1}kg{2}/{3}mmHg{4}次/分，{5}次/分",
                                 GetValue(anesPlanPmh.HEIGHT.ToString()), GetValue(anesPlanPmh.WEIGHT.ToString()), GetValue(anesPlanExam.BLOOD_PRESS_HIGH.ToString()),
                                 GetValue(anesPlanExam.BLOOD_PRESS_LOW.ToString()), GetValue(anesPlanExam.CARDIOTACH.ToString()), GetValue(anesPlanExam.BREATH.ToString()));

            labelSQ1.Text = string.Format("血常规：{0}         心电图：{1}", "", GetValue(anesPlanExam.ECG_EXAM));
            labelSQ2.Text = string.Format("生化：{0}             意识：{1}", "", "");
            labelSQ3.Text = string.Format("{0}         {1}", "", "");
            labelSQ4.Text = string.Format("执行麻醉：{0}         ASA分级：{1}", GetValue(anesPlan.ANESTHESIA_METHOD), GetValue(cardRow.ASA_GRADE));

            #endregion

            List<MED_OPERATION_SCHEDULE> operScheduleList = operationInfoRepository.GetOperScheduleList(patientID, (int)visitID).Data.ToList();
            if (operScheduleList != null && operScheduleList.Count > 0)
            {
                operScheduleList = operScheduleList.Where(x => x.OPER_ID == (int)operID).ToList();
            }

            #region 手术安排

            StringBuilder sbschedule1 = new StringBuilder();
            sbschedule1.Append("手术安排日期：{0}\r\n");
            sbschedule1.Append("麻：{1}\r\n");
            sbschedule1.Append("护：{2}\r\n");
            sbschedule1.Append("手术间：{3}         台次：{4}");
            string[] tempSchedule1Arr = new string[5] { "", "", "", "", "" };

            if (operScheduleList != null && operScheduleList.Count > 0)
            {
                MED_OPERATION_SCHEDULE tempoperation_schedule1 = operScheduleList[0];
                tempSchedule1Arr[0] = tempoperation_schedule1.SCHEDULED_DATE_TIME.Value.ToString("yyyy-MM-dd");
                StringBuilder sbOperAnes = new StringBuilder();
                sbOperAnes.Append(RefUsersDT(tempoperation_schedule1.ANES_DOCTOR));
                sbOperAnes.Append(RefUsersDT(tempoperation_schedule1.FIRST_ANES_ASSISTANT));
                sbOperAnes.Append(RefUsersDT(tempoperation_schedule1.SECOND_ANES_ASSISTANT));
                sbOperAnes.Append(RefUsersDT(tempoperation_schedule1.THIRD_ANES_ASSISTANT));
                sbOperAnes.Append(RefUsersDT(tempoperation_schedule1.FOURTH_ANES_ASSISTANT));
                tempSchedule1Arr[1] = sbOperAnes.ToString();

                StringBuilder sbOperNurse = new StringBuilder();
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.FIRST_OPER_NURSE));
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.SECOND_OPER_NURSE));
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.THIRD_OPER_NURSE));
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.FOURTH_OPER_NURSE));
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.FIRST_OPER_NURSE));
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.SECOND_SUPPLY_NURSE));
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.THIRD_SUPPLY_NURSE));
                sbOperNurse.Append(RefUsersDT(tempoperation_schedule1.FOURTH_SUPPLY_NURSE));
                tempSchedule1Arr[2] = sbOperNurse.ToString();

                tempSchedule1Arr[3] = GetValue(tempoperation_schedule1.OPER_ROOM_NO);
                if (tempoperation_schedule1.SEQUENCE != null)
                    tempSchedule1Arr[4] = tempoperation_schedule1.SEQUENCE.ToString();
                labelSchedule.Text = string.Format(sbschedule1.ToString(), tempSchedule1Arr);
                labelOperScheduleTime.Text = tempoperation_schedule1.SCHEDULED_DATE_TIME.Value.ToString("yyyy-MM-dd");

            }
            else
            {
                labelSchedule.Text = string.Format(sbschedule1.ToString(), tempSchedule1Arr);
                labelOperScheduleTime.Visible = false;
            }
            #endregion

            #region 手术申请
            if (operScheduleList != null && operScheduleList.Count > 0)
            {
                MED_OPERATION_SCHEDULE tempoperation_schedule = operScheduleList[0];

                string[] tempScheduleArr = new string[7] { "", "", "", "", "", "", "" };
                tempScheduleArr[0] = RefDeptDT(tempoperation_schedule.DEPT_CODE);
                tempScheduleArr[1] = GetValue(tempoperation_schedule.BED_NO);
                tempScheduleArr[2] = GetValue(tempoperation_schedule.DIAG_BEFORE_OPERATION);
                tempScheduleArr[3] = GetValue(tempoperation_schedule.OPERATION_NAME);
                tempScheduleArr[4] = GetValue(tempoperation_schedule.OPER_SCALE);
                tempScheduleArr[5] = GetValue(tempoperation_schedule.OPER_POSITION);

                labelOperReg.Text = string.Format("{0}{1}\r\n{2}\r\n{3}{4}\r\n{5}", tempScheduleArr);
                StringBuilder sbOper = new StringBuilder();
                sbOper.Append(RefUsersDT(tempoperation_schedule.SURGEON));
                sbOper.Append(RefUsersDT(tempoperation_schedule.FIRST_OPER_ASSISTANT));
                sbOper.Append(RefUsersDT(tempoperation_schedule.SECOND_OPER_ASSISTANT));
                sbOper.Append(RefUsersDT(tempoperation_schedule.THIRD_OPER_ASSISTANT));
                sbOper.Append(RefUsersDT(tempoperation_schedule.FOURTH_ANES_ASSISTANT));
                labelOper.Text = string.Format("手：{0}", sbOper.ToString());

                labelCreateDate.Text = tempoperation_schedule.REQ_DATE_TIME.Value.ToString("yyyy-Mm-dd");

                if (cardRow.EMERGENCY_IND == 1)
                    pictureBoxJZ.Visible = true;
                if (cardRow.RADIATE_IND == 2)
                    pictureBoxFS.Visible = true;
                if (cardRow.ISOLATION_IND == 2)
                    pictureBoxGL.Visible = true;
            }
            else
            {
                labelOperReg.Text = string.Empty;
                labelOper.Text = "手：";
                labelCreateDate.Text = string.Empty;
            }
            #endregion
        }

        private string GetValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            return string.Empty;
        }

        private string GetName(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                return code;
            }
            return string.Empty;
        }
        private string RefUsersDT(string userID)
        {
            foreach (MED_HIS_USERS user in ExtendApplicationContext.Current.CommDict.HisUsersDict)
            {
                if (user.USER_JOB_ID == userID)
                {
                    userID = user.USER_NAME;
                    break;
                }
            }
            return userID;
        }
        private string RefDeptDT(string deptID)
        {
            foreach (MED_DEPT_DICT user in ExtendApplicationContext.Current.CommDict.DeptDict)
            {
                if (user.DEPT_CODE == deptID)
                {
                    deptID = user.DEPT_NAME;
                    break;
                }
            }
            return deptID;
        }
    }
}
