using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document;

namespace MedicalSystem.Anes.FrameWork
{
    public class OperationStatusHelper
    {
        private static List<MemberDetail> GetList()
        {
            List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(OperationStatus), true);
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

        public static int GetOperStatusIndex(int operStatu)
        {
            int index = -1;
            if (operStatu >= (int)OperationStatus.OutOperationRoom)
            {
                index = 6;
            }

            switch (operStatu)
            {
                case (int)OperationStatus.InOperationRoom:
                    index = 1;
                    break;
                case (int)OperationStatus.AnesthesiaStart:
                    index = 2;
                    break;
                case (int)OperationStatus.OperationStart:
                    index = 3;
                    break;
                case (int)OperationStatus.OperationEnd:
                    index = 4;
                    break;
                case (int)OperationStatus.AnesthesiaEnd:
                    index = 5;
                    break;
                case (int)OperationStatus.OutOperationRoom:
                    index = 6;
                    break;
            }

            return index;
        }
    }
}
