//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AppCode.cs
//功能描述(Description)：    键盘KeyCode对照
//数据表(Tables)：		    无 
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
namespace MedicalSystem.UsbKeyBoard
{
    public class AppCode
    {
        #region 功能区

        /// <summary>
        /// 抢救
        /// </summary>
        public const string Rescue = "F001";
        /// <summary>
        /// PACU
        /// </summary>
        public const string PACU = "F002";
        /// <summary>
        /// 协同
        /// </summary>
        public const string Coordination = "F003";
        /// <summary>
        /// 质控上报
        /// </summary>
        public const string QC = "F004";



        #endregion

        #region 状态区
        /// <summary>
        /// 入手术室
        /// </summary>
        public const string InOperRoom = "S001";
        /// <summary>
        /// 麻醉开始
        /// </summary>
        public const string AnesStart = "S002";
        /// <summary>
        /// 手术开始
        /// </summary>
        public const string OperationStart = "S003";
        /// <summary>
        /// 手术结束
        /// </summary>
        public const string OperationEnd = "S004";
        /// <summary>
        /// 麻醉结束
        /// </summary>
        public const string AnesEnd = "S005";
        /// <summary>
        /// 出手术室
        /// </summary>
        public const string OutOperRoom = "S006";
        #endregion

        #region 操作区
        /// <summary>
        /// 返回
        /// </summary>
        public const string Back = "A006"; //将B005修改为A003
        /// <summary>
        /// ENTER
        /// </summary>
        public const string ENTER = "A004";
        /// <summary>
        /// 保存
        /// </summary>
        public const string Save = "B005";
        /// <summary>
        /// 打印
        /// </summary>
        public const string Print = "C008";//将A006修改为A005

        /// <summary>
        /// HOME
        /// </summary>
        public const string HOME = "A005"; //将A005修改为A006

        #endregion

        #region 事件区

        /// <summary>
        /// 麻药
        /// </summary>
        public const string AnesDrug = "E001";
        /// <summary>
        /// 用药
        /// </summary>
        public const string Drug = "E002";
        /// <summary>
        /// 输液
        /// </summary>
        public const string InLiquid = "E003";

        /// <summary>
        /// 事件
        /// </summary>
        public const string Event = "E004";
        /// <summary>
        /// 呼吸
        /// </summary>
        public const string Breath = "E005";

        /// <summary>
        /// 输氧
        /// </summary>
        public const string Oxygen = "E006";
        /// <summary>
        /// 输血
        /// </summary>
        public const string Blood = "E007";
        /// <summary>
        /// 插管
        /// </summary>
        public const string Intubatton = "E008";
        /// <summary>
        /// 拔管
        /// </summary>
        public const string Extubation = "E009";
        /// <summary>
        /// 出液
        /// </summary>
        public const string OutLiquid = "E010";
        /// <summary>
        /// 体征
        /// </summary>
        public const string VitalSigns = "E011";
        /// <summary>
        /// 麻醉路径
        /// </summary>
        public const string AnesPath = "E012";
        /// <summary>
        /// 新增事件
        /// </summary>
        public const string Insert = "E013";
        /// <summary>
        /// 删除事件
        /// </summary>
        public const string Delete = "E014";

        #endregion

        #region 模块区
        /// <summary>
        /// 急诊登记
        /// </summary>
        public const string Emergency = "M001";
        /// <summary>
        /// 信息接口
        /// </summary>
        public const string Interface = "M002";
        /// <summary>
        /// 家属公告
        /// </summary>
        public const string OperationScreen = "M003";
        /// <summary>
        /// 手术换台
        /// </summary>
        public const string OperationChange = "M004";

        /// <summary>
        /// 明日手术
        /// </summary>
        public const string TomorrowOperation = "M005";
        /// <summary>
        /// 功能菜单
        /// </summary>
        public const string FunctionMenu = "M006";
        /// <summary>
        /// 手术信息
        /// </summary>
        public const string OperInfo = "M007";
        /// <summary>
        /// 知情同意
        /// </summary>
        public const string InformedConsent = "M008";
        /// <summary>
        /// 术前访视
        /// </summary>
        public const string PreoperativeInterview = "M009";
        /// <summary>
        /// 麻醉记录单
        /// </summary>
        public const string AnesRecord = "M010";
        /// <summary>
        /// 术后随访
        /// </summary>
        public const string PostoperativeFollowUp = "M011";
        /// <summary>
        /// 其他文书
        /// </summary>
        public const string OtherReport = "M012";

        #endregion

        #region 切换区
        /// <summary>
        /// 大写
        /// </summary>
        public const string Upper = "B001";
        /// <summary>
        /// 切换语言
        /// </summary>
        public const string Language = "B002";
        /// <summary>
        /// 符号
        /// </summary>
        public const string Symbol = "B003";
        /// <summary>
        /// Fn
        /// </summary>
        public const string Function = "B004";

        /// <summary>
        ///  TAB
        /// </summary>
        public const string TAB = "A003";  //将A003 修改为B005  
        #endregion

        #region 备用区
        /// <summary>
        /// M1
        /// </summary>
        public const string M1 = "C001";
        /// <summary>
        /// M2
        /// </summary>
        public const string M2 = "C002";
        /// <summary>
        /// M3
        /// </summary>
        public const string M3 = "C003";
        /// <summary>
        /// M4
        /// </summary>
        public const string M4 = "C004";
        /// <summary>
        /// M5
        /// </summary>
        public const string M5 = "C005";
        /// <summary>
        /// M6
        /// </summary>
        public const string M6 = "C006";
        /// <summary>
        /// M7
        /// </summary>
        public const string M7 = "C007";
        /// <summary>
        /// M8
        /// </summary>
        //public const string M8 = "C008";
        #endregion
    }
}
