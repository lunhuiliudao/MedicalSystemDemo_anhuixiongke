using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Common
{

    /// <summary>
    /// 软件系统类型枚举
    /// </summary>
    public enum EnumAppType
    {
        /// <summary>
        /// 一体机
        /// </summary>
        [Description("一体机")]
        AnesWorkStation,

        /// <summary>
        /// 平台
        /// </summary>
        [Description("平台")]
        Platform,

        /// <summary>
        /// PACU
        /// </summary>
        [Description("PACU")]
        PACU,

        /// <summary>
        /// 大屏
        /// </summary>
        [Description("大屏")]
        Screen,
    }

    /// <summary>
    /// 消息类型：公告广播OR单一消息
    /// </summary>
    public enum EnumMessageType
    {
        /// <summary>
        /// 公告广播
        /// </summary>
        [Description("公告广播")]
        Broadcase,

        /// <summary>
        /// 单一消息
        /// </summary>
        [Description("单一消息")]
        Single,
    }

    /// <summary>
    /// 消息功能类型：展示消息OR驱动功能
    /// </summary>
    public enum EnumFunctionType
    {
        /// <summary>
        /// 展示消息
        /// </summary>
        [Description("展示消息")]
        ShowMessage,

        /// <summary>
        /// 驱动功能
        /// </summary>
        [Description("驱动功能")]
        Function,
    }

    /// <summary>
    /// 消息功能类型的明细类型，指针对驱动功能:根据消息类型执行响应的功能
    /// </summary>
    public enum EnumDetailFunctiom
    {
        /// <summary>
        /// 更换手术间
        /// </summary>
        [Description("更换手术间")]
        ChangeOperRoomNo,

        /// <summary>
        /// 取消手术
        /// </summary>
        [Description("取消手术")]
        OperationCanceled,

        /// <summary>
        /// 手术跳转
        /// </summary>
        [Description("手术跳转")]
        OperationJump,

        /// <summary>
        /// 大屏交互
        /// </summary>
        [Description("大屏交互")]
        OperationScreen
    }

    ///// <summary>
    ///// 跨平台功能的消息体
    ///// </summary>
    //[Serializable]
    //public class TransMessageModel
    //{
    //    /// <summary>
    //    /// 发送消息客户端的软件类型软件系统类型枚举
    //    /// </summary>
    //    public EnumAppType SourceClientEnumAppType;

    //    /// <summary>
    //    /// 发送消息客户端名称
    //    /// </summary>
    //    public string SourceClientName = string.Empty;

    //    /// <summary>
    //    /// 接收消息客户端的软件类型软件系统类型枚举
    //    /// </summary>
    //    public EnumAppType TargetClientEnumAppType;

    //    /// <summary>
    //    /// 接收消息客户端名称
    //    /// </summary>
    //    public string TargetClientName = string.Empty;

    //    /// <summary>
    //    /// 接收消息客户端所在的手术间
    //    /// </summary>
    //    public string TargetClientOperRoomNo = string.Empty;

    //    /// <summary>
    //    /// 接收消息客户端软件的登录者工号
    //    /// </summary>
    //    public string TargetClientUserID = string.Empty;

    //    /// <summary>
    //    /// 消息类型：公告广播OR单一消息
    //    /// </summary>
    //    public EnumMessageType CurEnumMessageType;

    //    /// <summary>
    //    /// 消息功能类型：展示消息OR驱动功能
    //    /// </summary>
    //    public EnumFunctionType CurEnumFunctionType;

    //    /// <summary>
    //    /// 消息功能类型的明细类型，指针对驱动功能:根据消息类型执行响应的功能
    //    /// </summary>
    //    public EnumDetailFunctiom CurEnumDetailFunctiom;

    //    /// <summary>
    //    /// 具体消息信息
    //    /// </summary>
    //    public string MessageContent = string.Empty;

    //    /// <summary>
    //    /// 是否显示具体消息信息。可能存在消息体是驱动功能，同时还需要展示具体信息的情况
    //    /// </summary>
    //    public bool IsShowMessageContent = false;

    //    /// <summary>
    //    /// 跨平台传递消息的消息体：有参构造
    //    /// 说明：当前软件类型和发送消息客户端名称统一设置
    //    /// </summary>
    //    /// <param name="targetClientEnumAppType">接收消息客户端的软件类型</param>
    //    /// <param name="curEnumMessageType">消息类型：公告广播OR单一消息</param>
    //    /// <param name="targetClientOperRoomNo">手术间号</param>
    //    /// <param name="targetClientUserID">医生或者护士的工号</param>
    //    /// <param name="curEnumFunctionType">消息功能类型：展示消息OR驱动功能</param>
    //    /// <param name="curEnumDetailFunctiom">消息功能类型的明细类型，指针对驱动功能:根据消息类型执行响应的功能</param>
    //    /// <param name="messageContent">具体消息信息</param>
    //    /// <param name="isShowMessageContent">是否显示具体消息信息。可能存在消息体是驱动功能，同时还需要展示具体信息的情况</param>
    //    public TransMessageModel(EnumAppType targetClientEnumAppType, EnumMessageType curEnumMessageType,
    //                             string targetClientOperRoomNo, string targetClientUserID, EnumFunctionType curEnumFunctionType,
    //                             EnumDetailFunctiom curEnumDetailFunctiom, string messageContent, bool isShowMessageContent)
    //    {
    //        this.TargetClientEnumAppType = targetClientEnumAppType;
    //        this.CurEnumMessageType = curEnumMessageType;
    //        this.CurEnumFunctionType = curEnumFunctionType;
    //        this.CurEnumDetailFunctiom = curEnumDetailFunctiom;
    //        this.MessageContent = messageContent;
    //        this.IsShowMessageContent = isShowMessageContent;
    //        this.TargetClientOperRoomNo = targetClientOperRoomNo;
    //        this.TargetClientUserID = targetClientUserID;
    //    }
    //}
}
