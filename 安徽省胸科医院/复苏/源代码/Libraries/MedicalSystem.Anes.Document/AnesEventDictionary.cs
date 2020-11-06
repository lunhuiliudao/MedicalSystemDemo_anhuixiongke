using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    public static class AnesEventDictionary
    {
      
            public static Dictionary<string, string> _keyPairList = new Dictionary<string, string>();
            static AnesEventDictionary()
            {
                _keyPairList.Add("1", "事件");
                _keyPairList.Add("2", "麻药");
                _keyPairList.Add("3", "输液");
                _keyPairList.Add("4", "输氧");
                _keyPairList.Add("5", "手术");
                _keyPairList.Add("7", "插管");
                _keyPairList.Add("~", "置管");
                _keyPairList.Add("8", "拔管");
                _keyPairList.Add("9", "呼吸");
                _keyPairList.Add("A", "呼吸");
                _keyPairList.Add("B", "输血");
                _keyPairList.Add("C", "用药");
                _keyPairList.Add("D", "出液");
                _keyPairList.Add("Y", "呼吸");
                _keyPairList.Add("O", "附记项目");//"ECG");
                _keyPairList.Add("Z", "其他");
             }      
    }
}
