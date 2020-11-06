using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalSystem.Anes.Client.AppPC
{
    public class PatientSignWarning
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        public List<MED_VITAL_SIGN> SetSignAlarmInfo(List<MED_VITAL_SIGN> vitalSignList)
        {
            List<MED_VITAL_SIGN> vitalSignAlarmList = null;
            List<MED_PAT_MONITOR_DATA_DICT> monitorDict = comnDictRepository.GetPatMonitorDict().Data;
            decimal value = 0;
            if (vitalSignList != null && vitalSignList.Count > 0 && monitorDict != null && monitorDict.Count > 0)
            {
                DateTime lastTime = vitalSignList[vitalSignList.Count - 1].TIME_POINT;
                vitalSignList = vitalSignList.Where(p => p.TIME_POINT == lastTime).ToList();
                foreach (MED_VITAL_SIGN signRow in vitalSignList)
                {
                    foreach (MED_PAT_MONITOR_DATA_DICT row in monitorDict)
                    {
                        if (signRow.ITEM_CODE == row.DB_DATA_NAME)
                        {
                            if (!string.IsNullOrEmpty(signRow.ITEM_VALUE))
                            {
                                value = decimal.Parse(signRow.ITEM_VALUE);
                                if ((row.LOW_SIGNS_VALUES.HasValue && value > 0 && value < row.LOW_SIGNS_VALUES))
                                {
                                    vitalSignAlarmList.Add(signRow);
                                }
                                if (row.HIGH_SIGNS_VALUES.HasValue && value > 0 && value > row.HIGH_SIGNS_VALUES)
                                {
                                    vitalSignAlarmList.Add(signRow);
                                }
                            }
                        }
                    }
                }
            }
            return vitalSignAlarmList;
        }
        public void SetSignAlarmInfoList(List<MED_VITAL_SIGN> vitalSignList)
        {
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            List<MED_VITALSIGN_ALARM> vitalSignAlarmList = null;
            //List<MED_PAT_MONITOR_DATA_DICT> monitorDict = CommDictService.GetPatMonitorDict();
            //List<MED_RESCUE_MESSAGE_LOG> messageList = RescueService.GetRescueMessageList();
            //if (messageList != null && messageList.Count > 0)
            //    messageList = messageList.Where(p => p.MESSAGE_TYPE == 1 && p.PATIENT_ID == ExtendApplicationContext.Current.PatientContextExtend.PatientID &&
            //        p.VISIT_ID == ExtendApplicationContext.Current.PatientContextExtend.VisitID && p.OPER_ID == ExtendApplicationContext.Current.PatientContextExtend.OperID).ToList();
            //decimal value = 0;
            //if (vitalSignList != null && vitalSignList.Count > 0 && monitorDict != null && monitorDict.Count > 0)
            //{
            //    DateTime lastTime = vitalSignList[vitalSignList.Count - 1].TIME_POINT;
            //    vitalSignList = vitalSignList.Where(p => p.TIME_POINT == lastTime).ToList();
            //    foreach (MED_VITAL_SIGN signRow in vitalSignList)
            //    {
            //        MED_RESCUE_MESSAGE_LOG messageRow = messageList.Where(p => p.GROUP_ID == signRow.ITEM_CODE && p.SEND_TIME == signRow.TIME_POINT).FirstOrDefault();
            //        if (messageRow == null)
            //        {
            //            foreach (MED_PAT_MONITOR_DATA_DICT row in monitorDict)
            //            {
            //                if (signRow.ITEM_CODE == row.DB_DATA_NAME)
            //                {
            //                    if (!string.IsNullOrEmpty(signRow.ITEM_VALUE))
            //                    {
            //                        value = decimal.Parse(signRow.ITEM_VALUE);
            //                        MED_RESCUE_MESSAGE_LOG logRow = new MED_RESCUE_MESSAGE_LOG();
            //                        string message = "";
            //                        if ((row.LOW_SIGNS_VALUES.HasValue && value > 0 && value < row.LOW_SIGNS_VALUES))
            //                        {
            //                            logRow.MESSAGE_TYPE = 1;
            //                            logRow.SEND_CLIENT_IP = ipAddr.ToString();
            //                            logRow.SEND_USER_ID = "体征预警";
            //                            logRow.GROUP_ID = signRow.ITEM_CODE;
            //                            logRow.EXPERT_ID = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
            //                            logRow.PATIENT_ID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            //                            logRow.VISIT_ID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            //                            logRow.OPER_ID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            //                            logRow.MESSAGE = signRow.TIME_POINT.ToString("yyyy-MM-dd hh:mm:ss") + " " + signRow.ITEM_NAME + " 值为:" + signRow.ITEM_VALUE + " 低于预设的警戒值 : " + row.LOW_SIGNS_VALUES;
            //                            logRow.SEND_TIME = signRow.TIME_POINT;
            //                            logRow.SEND_CONFIRM = 0;
            //                            logRow.RECEIVE_CONFIRM = 0;
            //                            messageList.Add(logRow);
            //                        }
            //                        if (row.HIGH_SIGNS_VALUES.HasValue && value > 0 && value > row.HIGH_SIGNS_VALUES)
            //                        {
            //                            logRow.MESSAGE_TYPE = 1;
            //                            logRow.SEND_CLIENT_IP = ipAddr.ToString();
            //                            logRow.SEND_USER_ID = "体征预警";
            //                            logRow.GROUP_ID = signRow.ITEM_CODE;
            //                            logRow.EXPERT_ID = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
            //                            logRow.PATIENT_ID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            //                            logRow.VISIT_ID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            //                            logRow.OPER_ID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            //                            logRow.MESSAGE = signRow.TIME_POINT.ToString("yyyy-MM-dd hh:mm:ss") + " " + signRow.ITEM_NAME + " 值为:" + signRow.ITEM_VALUE + " 高于预设的警戒值 : " + row.HIGH_SIGNS_VALUES;
            //                            logRow.SEND_TIME = signRow.TIME_POINT;
            //                            logRow.SEND_CONFIRM = 0;
            //                            logRow.RECEIVE_CONFIRM = 0;
            //                            messageList.Add(logRow);
            //                        }

            //                    }
            //                }
            //            }
            //        }

            //    }
            //    RescueService.SaveRescueMessage(messageList);
            //}
        }
    }
}
