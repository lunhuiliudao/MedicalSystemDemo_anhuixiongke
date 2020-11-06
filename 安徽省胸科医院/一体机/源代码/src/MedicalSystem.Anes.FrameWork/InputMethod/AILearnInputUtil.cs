using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork.InputMethod
{
    public class AILearnInputUtil
    {
        public static List<MED_EVENT_DICT> GetSortedList(List<MED_EVENT_DICT> anesEventDict, List<MED_EVENT_SORT> eventSortDict, string strClassCode)
        {
            List<MED_EVENT_SORT> tempList = eventSortDict.Where(p => p.EVENT_CLASS_CODE == strClassCode).OrderByDescending(o=>o.SORT_NO).ToList();
            MED_EVENT_DICT existEventData = null;
            foreach(MED_EVENT_SORT item in tempList)
            {
                existEventData = anesEventDict.Where(p => p.EVENT_ITEM_CODE == item.EVENT_ITEM_CODE).FirstOrDefault(); ;
                if (existEventData != null)
                    existEventData.SORT_NO = item.SORT_NO;
            }
            return anesEventDict.OrderByDescending(p=>p.SORT_NO).ToList();
        }

        public static List<MED_EVENT_DICT> GetSortedList(List<MED_EVENT_DICT> anesEventDict, List<MED_EVENT_SORT> eventSortDict)
        {
            List<MED_EVENT_SORT> tempList = eventSortDict.OrderByDescending(o => o.SORT_NO).ToList();
            MED_EVENT_DICT existEventData = null;
            foreach (MED_EVENT_SORT item in tempList)
            {
                existEventData = anesEventDict.Where(p => p.EVENT_ITEM_CODE == item.EVENT_ITEM_CODE).FirstOrDefault(); ;
                if (existEventData != null)
                    existEventData.SORT_NO = item.SORT_NO;
            }
            return anesEventDict.OrderByDescending(p => p.SORT_NO).ToList();
        }
    }
}
