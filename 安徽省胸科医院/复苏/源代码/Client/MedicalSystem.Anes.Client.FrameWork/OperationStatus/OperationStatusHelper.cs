using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Client.FrameWork
{
   public class OperationStatusHelper
    {
       private static List<MemberDetail> GetList()
       {
           List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(OperationStatus), true);
           foreach (MemberDetail item in list)
           {
               if (((OperationStatus)item.Value) == OperationStatus.InYouDao)
               {
                   item.Name = "入" + ApplicationConfiguration.YouDaoRoomTitle;
               }
               else if (((OperationStatus)item.Value) == OperationStatus.OutYouDao)
               {
                   item.Name = "出" + ApplicationConfiguration.YouDaoRoomTitle;
               }
           }
           return list;
       }


       /// <summary>
       /// 手术状态转中文名
       /// </summary>
       /// <param name="operationStatus"></param>
       /// <returns></returns>
       public static string OperationStatusToString(OperationStatus operationStatus)
       {
           List<MemberDetail> list = GetList();
           List<string> itemNames = new List<string>();
           foreach (MemberDetail item in list)
           {
               if (((OperationStatus)item.Value) == operationStatus)
               {
                   return item.Name;
               }
           }
           return "";
       }

        /// <summary>
        /// 从字符串获取手术状态
        /// </summary>
        /// <param name="operationStatusName"></param>
        /// <returns></returns>
        public static OperationStatus OperationStatusFromString(string operationStatusName)
        {
            List<MemberDetail> list = GetList();
            List<string> itemNames = new List<string>();
            foreach (MemberDetail item in list)
            {
                if (item.Name.Trim().Equals(operationStatusName.Trim()))
                {
                    return (OperationStatus)item.Value;
                }
            }
            return OperationStatus.None;
        }
        /// <summary>
        /// 取得状态时间字段
        /// </summary>
        /// <param name="operstionStatus"></param>
        /// <returns></returns>
        public static string GetTimeFieldName(OperationStatus operstionStatus)
        {
            string dtField = "";
            switch (operstionStatus)
            {
                case OperationStatus.CancelOperation:
                    dtField = "CANCEL_DATE_TIME";
                    break;
                case OperationStatus.AnesthesiaStart:
                    dtField = "ANES_START_TIME";
                    break;
                case OperationStatus.AnesthesiaEnd:
                    dtField = "ANES_END_TIME";
                    break;
                case OperationStatus.OperationStart:
                    dtField = "START_DATE_TIME";
                    break;
                case OperationStatus.OperationEnd:
                    dtField = "END_DATE_TIME";
                    break;
                case OperationStatus.InOperationRoom:
                    dtField = "IN_DATE_TIME";
                    break;
                case OperationStatus.OutOperationRoom:
                    dtField = "OUT_DATE_TIME";
                    break;
                case OperationStatus.InPACU:
                    dtField = "IN_PACU_DATE_TIME";
                    break;
                case OperationStatus.OutPACU:
                    dtField = "OUT_PACU_DATE_TIME";
                    break;
                case OperationStatus.InYouDao:
                    dtField = "INDUCE_START_TIME";
                    break;
                case OperationStatus.OutYouDao:
                    dtField = "INDUCE_END_TIME";
                    break;
                case OperationStatus.IsReady:
                    dtField = "SCHEDULED_DATE_TIME";
                    break;
                case OperationStatus.Done:
                    dtField = "DONE_DATE_TIME";
                    break;
            }
            return dtField;
        }
        /// <summary>
        /// 获取某状态操作串
        /// </summary>
        /// <param name="operationStatus"></param>
        /// <returns></returns>
        public static string GetOperAction(OperationStatus operationStatus)
        {
            string text = "";
            switch (operationStatus)
            {
                case OperationStatus.InOperationRoom:
                    text = ApplicationConfiguration.InRoomActions;
                    break;
                case OperationStatus.AnesthesiaStart:
                    text = ApplicationConfiguration.AnesthesiaStartActions;
                    break;
                case OperationStatus.OperationStart:
                    text = ApplicationConfiguration.OperationStartActions;
                    break;
                case OperationStatus.OperationEnd:
                    text = ApplicationConfiguration.OperationEndActions;
                    break;
                case OperationStatus.AnesthesiaEnd:
                    text = ApplicationConfiguration.AnesthesiaEndActions;
                    break;
                case OperationStatus.OutOperationRoom:
                    text = ApplicationConfiguration.OutRoomActions;
                    break;
                case OperationStatus.TurnToPACU:
                    text = ApplicationConfiguration.TurnToPACUActions;
                    break;
                case OperationStatus.TurnToSickRoom:
                    text = ApplicationConfiguration.TurnToSickRoomActions;
                    break;
                case OperationStatus.InPACU:
                    text = ApplicationConfiguration.InPACUActions;
                    break;
                case OperationStatus.OutPACU:
                    text = ApplicationConfiguration.OutPACUActions;
                    break;
                case OperationStatus.InYouDao:
                    text = ApplicationConfiguration.InYouDaoActions;
                    break;
                case OperationStatus.OutYouDao:
                    text = ApplicationConfiguration.OutYouDaoActions;
                    break;
                case OperationStatus.IsReady:
                    text = ApplicationConfiguration.IsReadyActions;
                    break;
                case OperationStatus.Done:
                    text = ApplicationConfiguration.DoneActions;
                    break;
                default:
                    break;
            }
            return text;
        }
        /// <summary>
        /// 获取某状态医疗文书串
        /// </summary>
        /// <param name="operationStatus"></param>
        /// <returns></returns>
        public static string GetOperDocument(OperationStatus operationStatus)
        {
            string text = "";
            switch (operationStatus)
            {
                case OperationStatus.InOperationRoom:
                    text = ApplicationConfiguration.InRoomDocuments;
                    break;
                case OperationStatus.AnesthesiaStart:
                    text = ApplicationConfiguration.AnesthesiaStartDocuments;
                    break;
                case OperationStatus.OperationStart:
                    text = ApplicationConfiguration.OperationStartDocuments;
                    break;
                case OperationStatus.OperationEnd:
                    text = ApplicationConfiguration.OperationEndDocuments;
                    break;
                case OperationStatus.AnesthesiaEnd:
                    text = ApplicationConfiguration.AnesthesiaEndDocuments;
                    break;
                case OperationStatus.OutOperationRoom:
                    text = ApplicationConfiguration.OutRoomDocuments;
                    break;
                case OperationStatus.TurnToPACU:
                    text = ApplicationConfiguration.TurnToPACUDocuments;
                    break;
                case OperationStatus.InPACU:
                    text = ApplicationConfiguration.InPACUDocuments;
                    break;
                case OperationStatus.TurnToSickRoom:
                    text = ApplicationConfiguration.TurnToSickRoomDocuments;
                    break;
                case OperationStatus.TurnToICU:
                    text = ApplicationConfiguration.TurnToICUDocuments;
                    break;
                case OperationStatus.OutPACU:
                    text = ApplicationConfiguration.OutPACUocuments;
                    break;
                case OperationStatus.InYouDao:
                    text = ApplicationConfiguration.InYouDaoDocuments;
                    break;
                case OperationStatus.OutYouDao:
                    text = ApplicationConfiguration.OutYouDaoDocuments;
                    break;
                case OperationStatus.IsReady:
                    text = ApplicationConfiguration.IsReadyDocuments;
                    break;
                case OperationStatus.Done:
                    text = ApplicationConfiguration.DoneDocuments;
                    break;
                default:
                    break;
            }
            if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass) && string.IsNullOrEmpty(text))
            {
                text = "体外循环记录单";
            }
            return text;
        }
        /// <summary>
        /// 获取某状态操作串
        /// </summary>
        /// <param name="operationStatus"></param>
        /// <returns></returns>
        public static string GetOperAction(ProgramStatus operationStatus)
        {
            string text = "";
            switch (operationStatus)
            {
                case ProgramStatus.NoPatient:
                    text = ApplicationConfiguration.NoPatientActions;
                    break;
                case ProgramStatus.PeroperativePatient:
                    text = ApplicationConfiguration.PeroperativePatientActions;
                    break;
                case ProgramStatus.AnesthesiaRecord:
                    text = ApplicationConfiguration.AnesthesiaRecordActions;
                    break;
                case ProgramStatus.PACURecord:
                    text = ApplicationConfiguration.PACURecordActions;
                    break;
                case ProgramStatus.CPBReport:
                    text = ApplicationConfiguration.CPBReportActions;
                    break;
                case ProgramStatus.PostoperativePatient:
                    text = ApplicationConfiguration.PostoperativePatientActions;
                    break;
                default:
                    break;
            }
            return text;
        }
        /// <summary>
        /// 获取某状态医疗文书串
        /// </summary>
        /// <param name="operationStatus"></param>
        /// <returns></returns>
        public static string GetOperDocument(ProgramStatus operationStatus)
        {
            string text = "";
            switch (operationStatus)
            {
                case ProgramStatus.NoPatient:
                    text = ApplicationConfiguration.NoPatientDocuments;
                    break;
                case ProgramStatus.PeroperativePatient:
                    text = ApplicationConfiguration.PeroperativePatientDocuments;
                    break;
                case ProgramStatus.AnesthesiaRecord:
                    text = ApplicationConfiguration.AnesthesiaRecordDocuments;
                    break;
                case ProgramStatus.PACURecord:
                    text = ApplicationConfiguration.PACURecordEndDocuments;
                    break;
                case ProgramStatus.CPBReport:
                    text = ApplicationConfiguration.CPBReportDocuments;
                    break;
                case ProgramStatus.PostoperativePatient:
                    text = ApplicationConfiguration.PostoperativePatientDocuments;
                    break;
                default:
                    break;
            }
            if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass) && string.IsNullOrEmpty(text))
            {
                text = "体外循环记录单";
            }
            return text;
        }
        public static void SetOperDocument(Dictionary<ProgramStatus, string> operDocuments)
       {
           if (operDocuments.Count == 0)
           {
               return;
           }
           ApplicationConfiguration.PeroperativePatientDocuments = operDocuments[ProgramStatus.PeroperativePatient];
           ApplicationConfiguration.AnesthesiaRecordDocuments = operDocuments[ProgramStatus.AnesthesiaRecord];
           ApplicationConfiguration.PACURecordEndDocuments = operDocuments[ProgramStatus.PACURecord];
           ApplicationConfiguration.PostoperativePatientDocuments = operDocuments[ProgramStatus.PostoperativePatient];
       }
        public static void SetOperAction(Dictionary<ProgramStatus, string> operActions)
        {
            if (operActions.Count == 0) return;
            ApplicationConfiguration.PeroperativePatientActions = operActions[ProgramStatus.PeroperativePatient];
            ApplicationConfiguration.AnesthesiaRecordActions = operActions[ProgramStatus.AnesthesiaRecord];
            ApplicationConfiguration.PACURecordActions = operActions[ProgramStatus.PACURecord];
            ApplicationConfiguration.PostoperativePatientActions = operActions[ProgramStatus.PostoperativePatient];
        }
        public static void SetOperDocument(Dictionary<string, string> operDocuments)
        {
            if (operDocuments.Count == 0)
            {
                return;
            }
            ApplicationConfiguration.InRoomDocuments = operDocuments[OperationStatusToString(OperationStatus.InOperationRoom)];
            ApplicationConfiguration.AnesthesiaStartDocuments = operDocuments[OperationStatusToString(OperationStatus.AnesthesiaStart)];
            ApplicationConfiguration.AnesthesiaEndDocuments = operDocuments[OperationStatusToString(OperationStatus.AnesthesiaEnd)];
            ApplicationConfiguration.OperationStartDocuments = operDocuments[OperationStatusToString(OperationStatus.OperationStart)];
            ApplicationConfiguration.OperationEndDocuments = operDocuments[OperationStatusToString(OperationStatus.OperationEnd)];
            ApplicationConfiguration.OutRoomDocuments = operDocuments[OperationStatusToString(OperationStatus.OutOperationRoom)];
            ApplicationConfiguration.InPACUDocuments = operDocuments[OperationStatusToString(OperationStatus.InPACU)];
            ApplicationConfiguration.OutPACUocuments = operDocuments[OperationStatusToString(OperationStatus.OutPACU)];
            ApplicationConfiguration.IsReadyDocuments = operDocuments[OperationStatusToString(OperationStatus.IsReady)];
            try
            {
                ApplicationConfiguration.OutYouDaoDocuments = operDocuments[OperationStatusToString(OperationStatus.OutYouDao)];
            }
            catch
            {
            }
            try
            {
                ApplicationConfiguration.InYouDaoDocuments = operDocuments[OperationStatusToString(OperationStatus.InYouDao)];
            }
            catch
            {
            }
            try
            {
                ApplicationConfiguration.TurnToPACUDocuments = operDocuments[OperationStatusToString(OperationStatus.TurnToPACU)];
            }
            catch
            {
            }
            try
            {
                ApplicationConfiguration.TurnToSickRoomDocuments = operDocuments[OperationStatusToString(OperationStatus.TurnToSickRoom)];
            }
            catch
            {
            }
            try
            {
                ApplicationConfiguration.TurnToICUDocuments = operDocuments[OperationStatusToString(OperationStatus.TurnToICU)];
            }
            catch
            {
            }
            ApplicationConfiguration.DoneDocuments = operDocuments[OperationStatusToString(OperationStatus.Done)];
        }

        public static void SetOperAction(Dictionary<string, string> operActions)
        {
            if (operActions.Count == 0)
            {
                return;
            }
            ApplicationConfiguration.InRoomActions = operActions[OperationStatusToString(OperationStatus.InOperationRoom)];
            ApplicationConfiguration.AnesthesiaStartActions = operActions[OperationStatusToString(OperationStatus.AnesthesiaStart)];
            ApplicationConfiguration.AnesthesiaEndActions = operActions[OperationStatusToString(OperationStatus.AnesthesiaEnd)];
            ApplicationConfiguration.OperationStartActions = operActions[OperationStatusToString(OperationStatus.OperationStart)];
            ApplicationConfiguration.OperationEndActions = operActions[OperationStatusToString(OperationStatus.OperationEnd)];
            ApplicationConfiguration.OutRoomActions = operActions[OperationStatusToString(OperationStatus.OutOperationRoom)];
            ApplicationConfiguration.InPACUActions = operActions[OperationStatusToString(OperationStatus.InPACU)];
            ApplicationConfiguration.OutPACUActions = operActions[OperationStatusToString(OperationStatus.OutPACU)];
            ApplicationConfiguration.IsReadyActions = operActions[OperationStatusToString(OperationStatus.IsReady)];
            try
            {
                ApplicationConfiguration.OutYouDaoActions = operActions[OperationStatusToString(OperationStatus.OutYouDao)];
            }
            catch
            {
            }
            try
            {
                ApplicationConfiguration.InYouDaoActions = operActions[OperationStatusToString(OperationStatus.InYouDao)];
            }
            catch
            {
            }
            try
            {
                ApplicationConfiguration.TurnToSickRoomActions = operActions[OperationStatusToString(OperationStatus.TurnToSickRoom)];
            }
            catch
            {
            }
            try
            {
                ApplicationConfiguration.TurnToPACUActions = operActions[OperationStatusToString(OperationStatus.TurnToPACU)];
            }
            catch
            {
            }
            ApplicationConfiguration.DoneActions = operActions[OperationStatusToString(OperationStatus.Done)];
        }

        /// <summary>
        /// 手术状态名称列表
        /// </summary>
        public static List<string> OperationStatusList
        {
            get
            {
                List<MemberDetail> list = GetList();
                List<string> itemNames = new List<string>();
                foreach (MemberDetail item in list)
                {
                    if (((int)item.Value) >= 0)
                    {
                        itemNames.Add(item.Name);
                    }
                }
                return itemNames;
            }
        }

        /// <summary>
        /// 获取某状态医疗文书串
        /// </summary>
        /// <param name="key">状态中文名称</param>
        /// <returns></returns>
        public static string GetOperDocument(string key)
        {
            return GetOperDocument(OperationStatusFromString(key));
        }

        /// <summary>
        /// 获取某状态操作串
        /// </summary>
        /// <param name="key">状态中文名称</param>
        /// <returns></returns>
        public static string GetOperAction(string key)
        {
            return GetOperAction(OperationStatusFromString(key));
        }


       
    }
}
