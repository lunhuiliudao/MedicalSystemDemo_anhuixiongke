using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Model
{
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

        /// <summary>
        /// 准备手术，未排班
        /// </summary>
        [Description("准备手术，未排班")]
        IsReady = 0,
        /// <summary>
        /// 已排班
        /// </summary>
        [Description("已排班")]
        OperScheduled = 2,
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
        /// 转入ICU
        /// </summary>
        [Description("转入ICU")]
        TurnToICU = 65,
        /// <summary>
        /// 急诊
        /// </summary>
        [Description("急诊")]
        TurnToEmergency = 66,
        /// <summary>
        /// 离院
        /// </summary>
        [Description("离院")]
        LeftHospital = 67,
        /// <summary>
        /// 死亡
        /// </summary>
        [Description("死亡")]
        TurnToMortuary = 68,
        /// <summary>
        /// 病案归档
        /// </summary>
        [Description("病案归档")]
        Done = 80,
    }
}
