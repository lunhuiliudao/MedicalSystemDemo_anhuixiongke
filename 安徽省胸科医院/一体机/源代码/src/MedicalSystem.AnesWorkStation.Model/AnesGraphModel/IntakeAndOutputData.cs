// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      IntakeAndOutputData.cs
// 功能描述(Description)：    术中界面，出入量数据信息的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.Model.AnesGraphModel
{
    public class IntakeAndOutputData
    {
        /// <summary>
        /// 出入量类型
        /// </summary>
        public IntakeAndOutputType InAndOutType { get; set; }        

        /// <summary>
        /// 名称（出入量名称）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public double Val { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 是否是一次性（一次性用药或出入量）
        /// </summary>
        public bool IsOneTime
        {
            get
            {
                return OnetimeData != null;
            }
        }

        /// <summary>
        /// 鼠标提示信息
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// 一次性出入量数据
        /// </summary>
        public OneTimeIntakeAndOut OnetimeData { get; set; }

        /// <summary>
        /// 一次性出入量
        /// </summary>
        public class OneTimeIntakeAndOut
        {
            /// <summary>
            /// 执行时间（一次性用药）
            /// </summary>
            public DateTime? ExcuteTime { get; set; }

            /// <summary>
            /// 是否按图标显示
            /// </summary>
            public bool IsShowIcon
            {
                get
                {
                    return !string.IsNullOrWhiteSpace(IconText);
                }
            }

            /// <summary>
            /// 图标文字 如：“尿”“血”“引”
            /// </summary>
            public string IconText { get; set; }

            /// <summary>
            /// 图标背景色
            /// </summary>
            public Color IconBackground { get; set; }

            public OneTimeIntakeAndOut(DateTime ExcuteTime)
            {
                this.ExcuteTime = ExcuteTime;
            }
            /// <summary>
            /// 一次性出入量
            /// </summary>
            /// <param name="ExcuteTime">执行时间</param>
            /// <param name="IconText">图标文本</param>
            /// <param name="IconBackground">绿色：Color.FromRgb(0x66,0xFF,0xCC) 深黄：Color.FromRgb(0xCC,0xCC,0x00)</param>
            public OneTimeIntakeAndOut(DateTime ExcuteTime, string IconText, Color IconBackground)
            {
                this.ExcuteTime = ExcuteTime;
                this.IconText = IconText;
                this.IconBackground = IconBackground;
            }
        }        

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label
        {
            get
            {
                return Val + Unit;
            }
        }
        public IntakeAndOutputData()
        {
            InAndOutType = IntakeAndOutputType.Medicine;
        }
        public IntakeAndOutputData(string Name, double val, string unit, IntakeAndOutputType InAndOutType = IntakeAndOutputType.Medicine)
        {
            this.Name = Name;
            this.Val = val;
            this.Unit = unit;
            this.InAndOutType = InAndOutType;
        }
    }

    /// <summary>
    /// 出入量类型
    /// </summary>
    public enum IntakeAndOutputType
    {
        /// <summary>
        /// 普通用药
        /// </summary>
        [Description("")]
        Medicine,
        /// <summary>
        /// 输液
        /// </summary>
        [Description("输液")]
        Infusion,
        /// <summary>
        /// 普通出量
        /// </summary>
        [Description("出量")]
        Output
    } 
}
