using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraTreeList;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.Anes.Document
{
    /// <summary>
    /// 医疗文书类型
    /// </summary>
    public enum DocKind
    {
        /// <summary>
        /// 默认普通文书
        /// </summary>
        Default,
        /// <summary>
        /// 麻醉单文书
        /// </summary>
        Anes,
        /// <summary>
        /// 复苏单
        /// </summary>
        PACU,
        /// <summary>
        /// 体外循环单
        /// </summary>
        CPB
    }
    /// <summary>
    /// 文书模板定位标识，所需模板若不在枚举中，则选DocTempletType.Other并且在OtherTempletFlagString属性中自定义名称，
    /// 同时在CustomSetting中自行添加到集合ExtendAppContext.CurntSelect.CustomSettingContext.CustomTempletFlagNames
    /// </summary>
    public enum DocTempletType
    {
        /// <summary>
        /// 非模板标志
        /// </summary>
        [Description("非模板标志")]
        None,
        /// <summary>
        /// 器械清点
        /// </summary>
        [Description("器械清点")]
        QiXieQingDian,
        /// <summary>
        /// 麻醉总结
        /// </summary>
        [Description("麻醉总结")]
        AnesSummary,
        /// <summary>
        /// 麻醉前小结
        /// </summary>
        [Description("麻醉前小结")]
        PreAnesSummary,
        /// <summary>
        /// 随访记录
        /// </summary>
        [Description("随访记录")]
        VisitRecord,
        /// <summary>
        /// 其它
        /// </summary>
        [Description("其它")]
        Other,
        /// <summary>
        /// 整套模板
        /// </summary>
        [Description("整套模板")]
        ALL
    }

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
        /// 出量-D
        /// </summary>
        OutLiquid,
        /// <summary>
        /// 诱导-!
        /// </summary>
        YouDao,
        /// <summary>
        /// @
        /// </summary>
        ZhenTong,
        /// <summary>
        /// #
        /// </summary>
        KangShengSu,
        /// <summary>
        /// $
        /// </summary>
        TeShuCaiLiao,


        Unknow,
    }

    public enum TimeScaleType
    {
        [Description("自然单位")]
        None,
        [Description("一分钟为单位")]
        OneMinute,
        [Description("五分钟为单位")]
        FiveMinute,
        [Description("一刻钟为单位")]
        Quarter,
        [Description("半小时为单位")]
        HaveHour,
    }

    public static class EventTypeHelper
    {
        private static KeyPairDictionary<string, string> _keyPairList = new KeyPairDictionary<string, string>();
        static EventTypeHelper()
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
            _keyPairList.Add("D", "出量");
            _keyPairList.Add("Y", "呼吸");
            _keyPairList.Add("O", "附记项目");//"ECG");
            _keyPairList.Add("Z", "其他");
            _keyPairList.Add("!", "诱导");
            _keyPairList.Add("@", "镇痛");
            _keyPairList.Add("#", "抗生素");
            _keyPairList.Add("$", "特殊材料");
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

        public static KeyPairDictionary<string, string> SwitchKeyValue
        {
            get
            {
                return _keyPairList.SwitchKeyValue();
            }
        }

        public static KeyPairDictionary<string, string> List
        {
            get
            {
                return _keyPairList;
            }
        }

        /// <summary>
        /// 麻醉操作类型对应保存在数据库中的字符
        /// </summary>
        /// <param name="anesClassType">麻醉操作类型</param>
        /// <returns>麻醉操作类型对应保存在数据库中的字符</returns>
        public static string GetAnesClassTypeString(AnesClassType anesClassType)
        {
            string anesClassTypeStrings = "0123456789ABCXYOZ~D!@#$";
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

        //public static List<MED_EVENT_DICT> RefreshEventOpenDataTalbe(string event_item_Class, string eventAttr)
        //{
        //    var tmpList = DictService.ClientInstance.GetEventDictList();
        //    if (string.IsNullOrEmpty(eventAttr))
        //    {
        //        return tmpList.FindAll(x => x.EVENT_CLASS_CODE == event_item_Class);
        //    }
        //    else if (event_item_Class == "9" && eventAttr == "4")//9为呼吸
        //    {
        //        return tmpList.Where(x => new string[] { "9", "A", "Y" }.Contains(x.EVENT_CLASS_CODE)
        //            || new string[] { "辅助呼吸", "控制呼吸", "自主呼吸" }.Contains(x.EVENT_ITEM_NAME))
        //            .OrderBy(x => x.SORT_NO).ToList();
        //    }
        //    else
        //    {
        //        return tmpList.Where(x => x.EVENT_CLASS_CODE == event_item_Class && x.EVENT_ATTR2 == eventAttr)
        //            .OrderBy(x => x.SORT_NO).ToList();
        //    }
        //}

        public static string GetEventType(string event_item_Class)
        {
            string result = null;
            if (event_item_Class.Contains("麻药"))
            {
                if (!event_item_Class.Equals("麻药"))
                {
                    Dictionary<string, string> attrDict = new Dictionary<string, string>();
                    attrDict.Add("吸入麻药", "1");
                    attrDict.Add("局部麻药", "2");
                    attrDict.Add("静脉麻药", "3");
                    if (attrDict.ContainsKey(event_item_Class))
                    {
                        result = attrDict[event_item_Class];
                    }
                }
            }
            else if (event_item_Class.Equals("呼吸"))
            {
                result = "4";
            }
            return result;
        }

        public static void InitTree(System.Windows.Forms.TreeView treeViewEventTypes)
        {
            treeViewEventTypes.Nodes.Clear();
            treeViewEventTypes.Nodes.Add("全部", "全部");
            treeViewEventTypes.Nodes.Add("事件", "事件");
            treeViewEventTypes.Nodes.Add("麻药", "麻药");
            treeViewEventTypes.Nodes.Add("用药", "用药");
            treeViewEventTypes.Nodes.Add("输血", "输血");
            treeViewEventTypes.Nodes.Add("输液", "输液");
            treeViewEventTypes.Nodes.Add("输氧", "输氧");
            treeViewEventTypes.Nodes.Add("岀液", "岀液");
            treeViewEventTypes.Nodes.Add("手术", "手术");
            treeViewEventTypes.Nodes.Add("麻醉", "麻醉");
            treeViewEventTypes.Nodes.Add("插管", "插管");
            treeViewEventTypes.Nodes.Add("置管", "置管");
            treeViewEventTypes.Nodes.Add("拔管", "拔管");
            //treeViewEventTypes.Nodes.Add("镇痛药", "镇痛药");
            //treeViewEventTypes.Nodes.Add("术后镇痛", "术后镇痛");
            treeViewEventTypes.Nodes.Add("呼吸", "呼吸");
            //treeViewEventTypes.Nodes.Add("数据修改", "数据修改");
            //treeViewEventTypes.Nodes.Add("排出", "排出");
            //treeViewEventTypes.Nodes.Add("护理", "护理");
            //treeViewEventTypes.Nodes.Add("体位", "体位");
            //treeViewEventTypes.Nodes.Add("检查", "检查");
            //treeViewEventTypes.Nodes.Add("麻醉平面", "麻醉平面");
            //treeViewEventTypes.Nodes.Add("EKG", "EKG");
            //treeViewEventTypes.Nodes.Add("ECG", "ECG");
            treeViewEventTypes.Nodes.Add("附记项目", "附记项目");
            //treeViewEventTypes.Nodes.Add("血气分析", "血气分析");
            //treeViewEventTypes.Nodes.Add("混合液", "混合液");
            //treeViewEventTypes.Nodes.Add("出血", "出血");
            //treeViewEventTypes.Nodes.Add("尿液", "尿液");
            //treeViewEventTypes.Nodes.Add("特殊材料", "特殊材料");
            //treeViewEventTypes.Nodes.Add("备药", "备药");
            treeViewEventTypes.Nodes.Add("其他", "其他");
            treeViewEventTypes.Nodes["麻药"].Nodes.Add("吸入麻药", "吸入麻药");
            treeViewEventTypes.Nodes["麻药"].Nodes.Add("局部麻药", "局部麻药");
            treeViewEventTypes.Nodes["麻药"].Nodes.Add("静脉麻药", "静脉麻药");
            treeViewEventTypes.Nodes["呼吸"].Nodes.Add("辅助呼吸", "辅助呼吸");
            treeViewEventTypes.Nodes["呼吸"].Nodes.Add("控制呼吸", "控制呼吸");
            treeViewEventTypes.Nodes["呼吸"].Nodes.Add("自主呼吸", "自主呼吸");
        }

        public static void InitTree(DevExpress.XtraTreeList.TreeList treeList)
        {
            treeList.Nodes.Clear();
            treeList.AppendNode("全部", -1).SetValue(0, "全部");
            treeList.AppendNode("事件", -1).SetValue(0, "事件");
            DevExpress.XtraTreeList.Nodes.TreeListNode node1 = treeList.AppendNode("麻药", -1);
            node1.SetValue(0, "麻药");
            treeList.AppendNode("用药", -1).SetValue(0, "用药");
            treeList.AppendNode("输血", -1).SetValue(0, "输血");
            treeList.AppendNode("输液", -1).SetValue(0, "输液");
            treeList.AppendNode("输氧", -1).SetValue(0, "输氧");
            treeList.AppendNode("岀液", -1).SetValue(0, "岀液");
            treeList.AppendNode("手术", -1).SetValue(0, "手术");
            treeList.AppendNode("麻醉", -1).SetValue(0, "麻醉");
            treeList.AppendNode("插管", -1).SetValue(0, "插管");
            treeList.AppendNode("置管", -1).SetValue(0, "置管");
            treeList.AppendNode("拔管", -1).SetValue(0, "拔管");

            DevExpress.XtraTreeList.Nodes.TreeListNode node2 = treeList.AppendNode("呼吸", -1);
            node2.SetValue(0, "呼吸");

            treeList.AppendNode("附记项目", -1).SetValue(0, "附记项目");
            treeList.AppendNode("其他", -1).SetValue(0, "其他");
            treeList.AppendNode("诱导", -1).SetValue(0, "诱导");
            treeList.AppendNode("镇痛", -1).SetValue(0, "镇痛");
            treeList.AppendNode("抗生素", -1).SetValue(0, "抗生素");
            treeList.AppendNode("特殊材料", -1).SetValue(0, "特殊材料");

            treeList.AppendNode("吸入麻药", node1).SetValue(0, "吸入麻药");
            treeList.AppendNode("局部麻药", node1).SetValue(0, "局部麻药");
            treeList.AppendNode("静脉麻药", node1).SetValue(0, "静脉麻药");
            treeList.AppendNode("辅助呼吸", node2).SetValue(0, "辅助呼吸");
            treeList.AppendNode("控制呼吸", node2).SetValue(0, "控制呼吸");
            treeList.AppendNode("自主呼吸", node2).SetValue(0, "自主呼吸");

        }
        public static void InitalizeOtherTabTree(TreeList treeList)
        {
            treeList.Nodes.Clear();
            treeList.AppendNode("医生字典", -1).SetValue(0, "医生字典");
            treeList.AppendNode("护士字典", -1).SetValue(0, "护士字典");
            treeList.AppendNode("诊断字典", -1).SetValue(0, "诊断字典");
            treeList.AppendNode("手术名称", -1).SetValue(0, "手术名称");
            treeList.Nodes[0].ExpandAll();
        }
        public static void InitalizeExpertTabTree(TreeList treeList)
        {
            treeList.Nodes.Clear();
            treeList.AppendNode("抢救专家维护", -1).SetValue(0, "抢救专家维护");
            treeList.AppendNode("专家组维护", -1).SetValue(0, "专家组维护");
            treeList.AppendNode("专家与专家组", -1).SetValue(0, "专家与专家组");
            treeList.AppendNode("专家组与科室", -1).SetValue(0, "专家组与科室");
            treeList.Nodes[0].ExpandAll();
        }
        public static List<LookUpEditItem> GetItemList()
        {
            List<LookUpEditItem> data = new List<LookUpEditItem>();
            data.Add(new LookUpEditItem("事件", "1"));
            data.Add(new LookUpEditItem("麻药", "2"));
            data.Add(new LookUpEditItem("用药", "C"));
            data.Add(new LookUpEditItem("镇痛药", "K"));
            data.Add(new LookUpEditItem("术后镇痛", "P"));
            data.Add(new LookUpEditItem("输液", "3"));
            data.Add(new LookUpEditItem("输氧", "4"));
            data.Add(new LookUpEditItem("岀液", "D"));
            data.Add(new LookUpEditItem("手术", "5"));
            data.Add(new LookUpEditItem("麻醉", "6"));
            data.Add(new LookUpEditItem("插管", "7"));
            data.Add(new LookUpEditItem("置管", "~"));
            data.Add(new LookUpEditItem("拔管", "8"));
            data.Add(new LookUpEditItem("辅助呼吸", "9"));
            data.Add(new LookUpEditItem("呼吸", "9"));
            data.Add(new LookUpEditItem("控制呼吸", "A"));
            data.Add(new LookUpEditItem("输血", "B"));
            data.Add(new LookUpEditItem("数据修改", "0"));
            data.Add(new LookUpEditItem("排出", "D"));
            data.Add(new LookUpEditItem("护理", "E"));
            data.Add(new LookUpEditItem("体位", "F"));
            data.Add(new LookUpEditItem("检查", "G"));
            data.Add(new LookUpEditItem("麻醉平面", "L"));
            data.Add(new LookUpEditItem("EKG", "M"));
            data.Add(new LookUpEditItem("ECG", "O"));
            data.Add(new LookUpEditItem("附记项目", "O"));
            data.Add(new LookUpEditItem("血气分析", "N"));
            data.Add(new LookUpEditItem("其他", "Z"));
            data.Add(new LookUpEditItem("混合液", "X"));
            data.Add(new LookUpEditItem("自主呼吸", "Y"));
            data.Add(new LookUpEditItem("出血", "H"));
            data.Add(new LookUpEditItem("尿液", "I"));
            //data.Add(new LookUpEditItem("特殊材料", "J"));
            data.Add(new LookUpEditItem("备药", "Q"));
            data.Add(new LookUpEditItem("诱导", "!"));
            data.Add(new LookUpEditItem("镇痛", "@"));
            data.Add(new LookUpEditItem("抗生素", "#"));
            data.Add(new LookUpEditItem("特殊材料", "$"));
            return data;
        }
        public static string FindItemClass(string event_item_Class)
        {
            string result = null;
            if (event_item_Class.Equals("事件"))
                event_item_Class = "1";
            else if (event_item_Class.Contains("麻药"))
            {
                if (!event_item_Class.Equals("麻药"))
                {
                    Dictionary<string, string> attrDict = new Dictionary<string, string>();
                    attrDict.Add("吸入麻药", "1");
                    attrDict.Add("局部麻药", "2");
                    attrDict.Add("静脉麻药", "3");
                    if (attrDict.ContainsKey(event_item_Class))
                    {
                        result = attrDict[event_item_Class];
                    }
                }
                event_item_Class = "2";
            }
            else if (event_item_Class.Equals("用药"))
                event_item_Class = "C";
            else if (event_item_Class.Equals("镇痛药"))
                event_item_Class = "K";
            else if (event_item_Class.Equals("术后镇痛"))
                event_item_Class = "P";
            else if (event_item_Class.Equals("输液"))
                event_item_Class = "3";
            else if (event_item_Class.Equals("输氧"))
                event_item_Class = "4";
            else if (event_item_Class.Equals("岀液"))
                event_item_Class = "D";
            else if (event_item_Class.Equals("手术"))
                event_item_Class = "5";
            else if (event_item_Class.Equals("麻醉"))
                event_item_Class = "6";
            else if (event_item_Class.Equals("插管"))
                event_item_Class = "7";
            else if (event_item_Class.Equals("置管"))
                event_item_Class = "~";
            else if (event_item_Class.Equals("拔管"))
                event_item_Class = "8";
            else if (event_item_Class.Equals("辅助呼吸"))
                event_item_Class = "9";
            else if (event_item_Class.Equals("呼吸"))
            {
                event_item_Class = "9";
                result = "4";
            }
            else if (event_item_Class.Equals("控制呼吸"))
                event_item_Class = "A";
            else if (event_item_Class.Equals("输血"))
                event_item_Class = "B";
            else if (event_item_Class.Equals("数据修改"))
                event_item_Class = "0";
            else if (event_item_Class.Equals("排出"))
                event_item_Class = "D";
            else if (event_item_Class.Equals("护理"))
                event_item_Class = "E";
            else if (event_item_Class.Equals("体位"))
                event_item_Class = "F";
            else if (event_item_Class.Equals("检查"))
                event_item_Class = "G";
            else if (event_item_Class.Equals("麻醉平面"))
                event_item_Class = "L";
            else if (event_item_Class.Equals("EKG"))
                event_item_Class = "M";
            else if (event_item_Class.Equals("ECG"))
                event_item_Class = "O";
            else if (event_item_Class.Equals("附记项目"))
                event_item_Class = "O";
            else if (event_item_Class.Equals("血气分析"))
                event_item_Class = "N";
            else if (event_item_Class.Equals("其他"))
                event_item_Class = "Z";
            else if (event_item_Class.Equals("混合液"))
                event_item_Class = "X";
            else if (event_item_Class.Equals("自主呼吸"))
                event_item_Class = "Y";
            else if (event_item_Class.Equals("出血"))
                event_item_Class = "H";
            else if (event_item_Class.Equals("尿液"))
                event_item_Class = "I";
            //else if (event_item_Class.Equals("特殊材料"))
            //    event_item_Class = "J";
            else if (event_item_Class.Equals("备药"))
                event_item_Class = "Q";
            else if (event_item_Class.Equals("诱导"))
                event_item_Class = "!";
            else if (event_item_Class.Equals("镇痛"))
                event_item_Class = "@";
            else if (event_item_Class.Equals("抗生素"))
                event_item_Class = "#";
            else if (event_item_Class.Equals("特殊材料"))
                event_item_Class = "$";
            return event_item_Class;
        }
    }
}
