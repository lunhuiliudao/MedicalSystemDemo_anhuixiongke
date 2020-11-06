using System;
using System.Collections.Generic;

namespace MedicalSystem.MedScreen.Common
{
    public static class ScreenTypeHelper
    {
        public static List<string> ScreenTypeNameList = GetScreenTypeNameList();

        public static List<string> GetScreenTypeNameList()
        {
            Array intArray = Enum.GetValues(typeof(ScreenType));
            List<string> retList = new List<string>(intArray.Length);
            foreach (int i in intArray)
            {
                retList.Add(GetScreenNameByType((ScreenType)i));
            }
            return retList;
        }

        public static string GetScreenNameByType(ScreenType type)
        {
            string result = string.Empty;
            switch (type)
            {
                case ScreenType.FamilyWaitScreen:
                    result = "家属等待";
                    break;
                case ScreenType.OperScheduleScreen:
                    result = "手术排班";
                    break;
            }
            return result;
        }

        public static ScreenType GetScreenTypeByName(string name)
        {
            ScreenType type = ScreenType.FamilyWaitScreen;
            switch (name)
            {
                case "家属等待":
                    type = ScreenType.FamilyWaitScreen;
                    break;
                case "手术排班":
                    type = ScreenType.OperScheduleScreen;
                    break;
            }
            return type;
        }
    }
}
