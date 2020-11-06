using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// 应用程序类型
    /// </summary>
    public enum ApplicationType
    {
        /// 麻醉
        /// </summary>
        Anesthesia,
        /// <summary>
        /// 复苏
        /// </summary>
        PACU,
        /// <summary>
        /// 手术排班
        /// </summary>
        OperationSchedule,
        /// <summary>
        /// 体外循环（灌注）
        /// </summary>
        CardiopulmonaryBypass,
        /// <summary>
        /// 诱导（准备间）
        /// </summary>
        YouDao,
        /// <summary>
        /// 护理
        /// </summary>
        Nurse,
        /// <summary>
        /// 主任工作站
        /// </summary>
        Director,
        /// <summary>
        /// 无效的
        /// </summary>
        InValid,
    }

    /// <summary>
    /// 手术状态枚举
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// 未定义
        /// </summary>
        [Description("未定义")]
        None = -99,

        /// <summary>
        /// 取消手术
        /// </summary>
        [Description("取消手术")]
        CancelOperation = -80,

        [Description("准备手术")]
        IsReady = 0,
        //[Description("入准备间")]
        //InPreRoom = 1,
        //[Description("出准备间")]
        //OutPreRoom = 2,
        [Description("入诱导室")]
        InYouDao = 3,
        [Description("出诱导室")]
        OutYouDao = 4,

        /// <summary>
        /// 入手术室
        /// </summary>
        [Description("入手术室")]
        InOperationRoom = 5,
        /// <summary>
        /// 麻醉开始
        /// </summary>
        [Description("麻醉开始")]
        AnesthesiaStart = 10,
        /// <summary>
        /// 手术开始
        /// </summary>
        [Description("手术开始")]
        OperationStart = 15,
        /// <summary>
        /// 手术结束
        /// </summary>
        [Description("手术结束")]
        OperationEnd = 25,
        /// <summary>
        /// 麻醉结束
        /// </summary>
        [Description("麻醉结束")]
        AnesthesiaEnd = 30,
        /// <summary>
        /// 出手术室
        /// </summary>
        [Description("出手术室")]
        OutOperationRoom = 35,
        /// <summary>
        /// 转入ICU
        /// </summary>
        [Description("转入ICU")]
        TurnToICU = 50,
        /// <summary>
        /// 准备复苏
        /// </summary>
        [Description("准备复苏")]
        TurnToPACU = 40,
        /// <summary>
        /// 入复苏室
        /// </summary>
        [Description("入复苏室")]
        InPACU = 45,
        /// <summary>
        /// 出复苏室
        /// </summary>
        [Description("出复苏室")]
        OutPACU = 55,


        /// <summary>
        /// 转入病房
        /// </summary>
        [Description("转入病房")]
        TurnToSickRoom = 60,

        /// <summary>
        /// 病案归档
        /// </summary>
        [Description("病案归档")]
        Done = 80,
    }
}
