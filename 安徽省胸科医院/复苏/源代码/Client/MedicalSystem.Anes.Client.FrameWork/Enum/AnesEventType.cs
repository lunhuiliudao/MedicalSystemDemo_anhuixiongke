
using MedicalSystem.Anes.Document.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork.Enum
{
    public class AnesEventType
    {
        /// <summary>
        /// 麻醉操作类型
        /// </summary>
        public enum AnesClassType
        {
            /// <summary>
            /// 数据修改-0
            /// </summary>
            DataModify,
            /// <summary>
            /// 事件-1
            /// </summary>
            Event,
            /// <summary>
            /// 麻醉用药-2
            /// </summary>
            AnesDrug,
            /// <summary>
            /// 输液-3
            /// </summary>
            InLiquid,
            /// <summary>
            /// 输氧-4
            /// </summary>
            InOxygen,
            /// <summary>
            /// 手术-5
            /// </summary>
            Operation,
            /// <summary>
            /// 麻醉-6
            /// </summary>
            Anesthesia,
            /// <summary>
            /// 插管-7
            /// </summary>
            PutPipe,
            /// <summary>
            /// 拔管-8
            /// </summary>
            PullPipe,
            /// <summary>
            /// 辅助呼吸-9
            /// </summary>
            AssistBreath,
            /// <summary>
            /// 控制呼吸-A
            /// </summary>
            ControlBreath,
            /// <summary>
            /// 输血-B
            /// </summary>
            InBlood,
            /// <summary>
            /// 用药-C
            /// </summary>
            Drug,
            /// <summary>
            /// 混合液-X
            /// </summary>
            MixLiquid,
            /// <summary>
            /// 呼吸-Y
            /// </summary>
            Breath,
            /// <summary>
            /// ECG-O
            /// </summary>
            ECG,
            /// <summary>
            /// 其他-Z
            /// </summary>
            Other,
            /// <summary>
            /// 置管-~
            /// </summary>
            ZhiGuan,
            /// <summary>
            /// 出液-~
            /// </summary>
            OutLiquid,
            /// <summary>
            /// 局部麻药-R
            /// </summary>
            JBAnesDurg,
            /// <summary>
            /// 静脉麻药-S
            /// </summary>
            JMAnesDurg,
            /// <summary>
            /// 吸入麻药-T
            /// </summary>
            XLAnesDurg,
            /// <summary>
            /// 无状态
            /// </summary>
            Default, 

        }

        public  static KeyPairDictionary<string, string> _keyPairList = new KeyPairDictionary<string, string>();
        static AnesEventType()
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
        private static Dictionary<string, string> _CPBEventType;
        public static Dictionary<string, string> CPBEventType
        {
            get
            {
                if (_CPBEventType == null)
                {
                    _CPBEventType = new Dictionary<string, string>();
                    _CPBEventType.Add("事件", "1");
                    _CPBEventType.Add("输液", "3");
                    _CPBEventType.Add("输血", "B");
                    _CPBEventType.Add("用药", "C");
                    _CPBEventType.Add("灌注", "I");
                    _CPBEventType.Add("出量", "U");
                    _CPBEventType.Add("其他", "Z");
                }
                return _CPBEventType;
            }
        }
        /// <summary>
        /// 麻醉操作类型对应保存在数据库中的字符
        /// </summary>
        /// <param name="anesClassType">麻醉操作类型</param>
        /// <returns>麻醉操作类型对应保存在数据库中的字符</returns>
        public static string GetAnesClassTypeString(AnesClassType anesClassType)
        {
            string anesClassTypeStrings = "0123456789ABCXYOZ~D";
            int anesClassTypeIndex = (int)anesClassType;
            if (anesClassTypeIndex < anesClassTypeStrings.Length)
            {
                return anesClassTypeStrings.Substring(anesClassTypeIndex, 1);
            }
            else
            {
                return "";
            }
        }
        public static KeyPairDictionary<string, string> SwitchKeyValue
        {
            get
            {
                return _keyPairList.SwitchKeyValue();
            }
        }
    }
}
