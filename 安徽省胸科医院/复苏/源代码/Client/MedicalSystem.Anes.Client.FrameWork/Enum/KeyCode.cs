using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MedicalSystem.Anes.Client.FrameWork
{
    public class KeyCode
    {
        /// <summary>
        /// 返回程序编号类，用于程序判断
        /// </summary>
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
            public const string Back = "A003";
            /// <summary>
            /// 保存
            /// </summary>
            public const string Save = "A004";
            /// <summary>
            /// 打印
            /// </summary>
            public const string Print = "A005";

            /// <summary>
            /// HOME
            /// </summary>
            public const string HOME = "A006";

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
            /// 仪器确认
            /// </summary>
            public const string InstrumentValidation = "M002";
            /// <summary>
            /// 信息接口
            /// </summary>
            public const string Interface = "M003";
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
            /// 三方核查
            /// </summary>
            public const string Verification = "M010";
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
            ///  定位
            /// </summary>
            public const string Location = "B005";
            #endregion

            //public const string Choice = "B001";     
        }

    }
}
