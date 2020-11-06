// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TransMessageManager.cs
// 功能描述(Description)：    跨平台通信的管理类
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStationCoordination.Model;
using MedicalSystem.Coordination.Interface;
using MedicalSystem.Message.Common;
using MedicalSystem.Message.Lib;
using MedicalSystem.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.ViewModel
{
    /// <summary>
    /// 跨平台通信的管理类
    /// </summary>
    public class TransMessageManager
    {
        private static TransMessageManager instance = null;                                            // 单例
        private Connection connection = null;                                                          // 和服务端连接的对象
        private object locker = new object();                                                          // 数据锁
        private LoginModel curLoginModel = null;                                                       // 登陆者客户端
        private LoginModel childLoginModel = null;                                                     // 一体机的小麦助手
        private bool childHasLogin = false;                                                            // 判断一体机的小麦助手是否登录
        private List<ClientModel> allClientModelList = new List<ClientModel>();                        // 所有在线用户列表
        private List<TransMessageModel> allMsgList = new List<TransMessageModel>();                    // 所有的消息列表

        /// <summary>
        /// 登录消息平台实体类
        /// </summary>
        public LoginModel CurLoginModel
        {
            get
            {
                if (null == this.curLoginModel)
                {
                    // 自身的ID
                    string sessionID = Guid.NewGuid().ToString();
                    // 对应的小麦助手的ID
                    string childSessionID = Guid.NewGuid().ToString();
                    // 一体机的信息
                    string information = "手术间-" + ExtendAppContext.Current.OperRoomNo;
                    this.curLoginModel = new LoginModel(sessionID, "Ane", EnumAppType.AnesWorkStation,
                                                        ExtendAppContext.Current.LoginUser.USER_JOB_ID,
                                                        ExtendAppContext.Current.LoginUser.USER_NAME, information,
                                                       ApplicationConfiguration.MedicalSystemMessageServerURL, childSessionID);
                }

                return this.curLoginModel;
            }
        }

        /// <summary>
        /// 小麦助手的登录实体
        /// </summary>
        public LoginModel ChildLoginModel
        {
            get
            {
                if (null == this.childLoginModel)
                {
                    this.childLoginModel = new LoginModel(this.CurLoginModel.ChildSessionID, "Ane",
                                                          EnumAppType.AnesWorkStationAssistant,
                                                          ExtendAppContext.Current.LoginUser.USER_JOB_ID,
                                                          ExtendAppContext.Current.LoginUser.USER_NAME,
                                                          this.CurLoginModel.Information,
                                                          ApplicationConfiguration.MedicalSystemMessageServerURL);
                }

                return this.childLoginModel;
            }
        }

        /// <summary>
        /// 对象单例
        /// </summary>
        public static TransMessageManager Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new TransMessageManager();
                }

                return instance;
            }
        }

        /// <summary>
        /// 私有构造方法，使用单例访问
        /// </summary>
        private TransMessageManager()
        {
            string name = this.SetClientName();
            this.connection = new Connection(name, this.CurLoginModel.MessageServerURL);
            this.connection.DelegateSendMessage += this.DelegateSendMessage;
            this.connection.DelegateConnectionClosed += this.DelegateConnectionClosed;
            this.connection.DelegateOnLine += this.DelegateOnLine;
            this.connection.DelegateUnLine += this.DelegateUnLine;
            this.connection.DelegateGetUserList += this.DelegateGetUserDict;
        }

        /// <summary>
        /// 手动连接服务端
        /// </summary>
        public bool OpenConnection()
        {
            bool result = true;
            lock (this.locker)
            {
                try
                {
                    if (null != this.connection && !this.connection.ConnectionStatus)
                    {
                        this.connection.Connect();
                    }
                }
                catch
                {
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public void SendMsg(TransMessageModel transMsgModel)
        {
            if (null != this.connection && this.connection.ConnectionStatus && null != transMsgModel)
            {
                transMsgModel.SendDateTime = DateTime.Now;
                transMsgModel.SourceClientName = JsonConvert.SerializeObject(this.CurLoginModel);

                if (transMsgModel.CurEnumMessageType == EnumMessageType.Single)
                {
                    this.connection.SendMessage(transMsgModel.TargetClientName, JsonConvert.SerializeObject(transMsgModel));
                }
                else
                {
                    this.connection.SendALLMessage(JsonConvert.SerializeObject(transMsgModel));
                }
            }
        }

        /// <summary>
        /// 转发消息
        /// </summary>
        /// <param name="transMsgModel">消息体</param>
        /// <param name="targetName">转发消息的接收者</param>
        public void ForwardMsg(TransMessageModel transMsgModel, string targetName)
        {
            if (null != this.connection && this.connection.ConnectionStatus && null != transMsgModel)
            {
                if (DateTime.MinValue == transMsgModel.ReceiveDateTime)
                {
                    transMsgModel.ReceiveDateTime = CommonService.ClientInstance.GetServerTime();
                }

                this.connection.SendMessage(targetName, JsonConvert.SerializeObject(transMsgModel));
            }
        }

        /// <summary>
        /// 获取客户端名称
        /// </summary>
        private string SetClientName()
        {
            LoginModel tempModel = this.CurLoginModel;
            string result = string.Empty;
            result = JsonConvert.SerializeObject(tempModel);
            return result;
        }

        /// <summary>
        /// 获取服务端主动推送消息，同时弹出消息对话框
        /// </summary>
        public void DelegateSendMessage(string sendConnectionId, string sendName, string message)
        {
            try
            {
                LoginModel tar = JsonConvert.DeserializeObject<LoginModel>(sendName);
                if(null == tar || (tar.SessionID.Equals(this.CurLoginModel.SessionID)))
                {
                    return;
                }

                // 反序列化消息体
                TransMessageModel curTransMsgModel = JsonConvert.DeserializeObject<TransMessageModel>(message);
                if (null != curTransMsgModel)
                {
                    switch(curTransMsgModel.CurEnumFunctionType)
                    {
                        // 聊天记录
                        case EnumFunctionType.MessageCommunication:
                            this.MessageCommunicatioin(curTransMsgModel);
                            break;

                        // 请求视频通讯
                        case EnumFunctionType.VideoRequest:
                            Messenger.Default.Send<object>(this, EnumMessageKey.ResponseVideoComm);
                            break;

                        case EnumFunctionType.HasNewVersion:
                            if (!string.IsNullOrEmpty(curTransMsgModel.MessageContent) && curTransMsgModel.MessageContent.Equals("ANES"))
                            {
                                Messenger.Default.Send<object>(this, EnumMessageKey.HasNewVersion);
                            }
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error("接收消息异常", ex);
            }
        }

        /// <summary>
        /// 聊天记录处理
        /// </summary>
        private void MessageCommunicatioin(TransMessageModel curTransMsgModel)
        {
            try
            {
                if (DateTime.MinValue == curTransMsgModel.ReceiveDateTime)
                {
                    curTransMsgModel.ReceiveDateTime = CommonService.ClientInstance.GetServerTime();
                }

                // 把消息记录分派到对应的客户
                LoginModel source = JsonConvert.DeserializeObject<LoginModel>(curTransMsgModel.SourceClientName);
                LoginModel target = JsonConvert.DeserializeObject<LoginModel>(curTransMsgModel.TargetClientName);
                // 自身是发送方，则接收方为主
                if (source.SessionID.Equals(this.CurLoginModel.SessionID))
                {
                    foreach (ClientModel client in this.allClientModelList)
                    {
                        if (client.CurCoordinationLoginModel.SessionID.Equals(target.SessionID))
                        {
                            curTransMsgModel.CurFlowDirection = FlowDirection.RightToLeft;//聊天图形方向
                            curTransMsgModel.HasRead = true;
                            client.CurMsgRecordList.Add(curTransMsgModel);
                            break;
                        }
                    }
                }
                else
                {
                    if (this.childHasLogin)
                    {
                        // 接收到其他客户端消息
                        foreach (ClientModel client in this.allClientModelList)
                        {
                            if (client.CurCoordinationLoginModel.SessionID.Equals(source.SessionID))
                            {
                                curTransMsgModel.CurFlowDirection = FlowDirection.LeftToRight;//聊天图形方向
                                client.CurMsgRecordList.Add(curTransMsgModel);
                                // 转发给子一体机
                                // curTransMsgModel.HasRead = true;
                                this.ForwardMsg(curTransMsgModel, JsonConvert.SerializeObject(this.ChildLoginModel));
                                break;
                            }
                        }
                    }

                    Messenger.Default.Send<bool>(true, EnumMessageKey.NewUnreadMessage);
                }

                curTransMsgModel.HasRead = this.childHasLogin;
                this.allMsgList.Add(curTransMsgModel);
            }
            catch(Exception ex)
            {
                Logger.Error("聊天记录处理异常", ex);
            }
        }

        /// <summary>
        /// 手动关闭跨平台的消息连接
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (null != this.connection && this.connection.ConnectionStatus)
                {
                    this.connection.Close();
                }
            }
            catch(Exception ex)
            {
                Logger.Error("关闭跨平台消息失败！", ex);
            }
        }

        /// <summary>
        /// 连接失败OR和服务器断开连接
        /// </summary>
        private void DelegateConnectionClosed()
        {
        }

        /// <summary>
        /// 成功连接服务器
        /// </summary>
        private void DelegateOnLine(string connectionId, string name)
        {
            this.connection.GetUserList();
        }

        /// <summary>
        /// 和服务器断开连接
        /// </summary>
        private void DelegateUnLine(string connectionId, string name)
        {
            // 更新列表
            try
            {
                LoginModel unLineModel = JsonConvert.DeserializeObject<LoginModel>(name);
                if (null != unLineModel)
                {
                    ClientModel unLineClient = this.allClientModelList.FirstOrDefault(x => x.CurCoordinationLoginModel.SessionID.Equals(unLineModel.SessionID));
                    if (null != unLineClient)
                    {
                        this.allClientModelList.Remove(unLineClient);
                        // unLineClient.IsOnLine = false;
                    }

                    if (unLineModel.SessionID.Equals(this.ChildLoginModel.SessionID))
                    {
                        this.childHasLogin = false;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error("消息平台断开服务器异常", ex);
            }
        }

        /// <summary>
        /// 服务端主动推送所有在线的用户列表
        /// </summary>
        public void DelegateGetUserDict(List<MessageUser> curMessageUserList)
        {
            if (null != curMessageUserList)
            {
                int tag = 0;

                foreach (MessageUser item in curMessageUserList)
                {
                    LoginModel tempLoginModel = null;
                    try
                    {
                        tempLoginModel = JsonConvert.DeserializeObject<LoginModel>(item.UserName);
                        if (null == tempLoginModel)
                        {
                            continue;
                        }
                        
                        ClientModel findLogin = this.allClientModelList.FirstOrDefault(x => x.CurCoordinationLoginModel.SessionID.Equals(tempLoginModel.SessionID));
                        if (null == findLogin)
                        {
                            ClientModel cm = new ClientModel()
                            {
                                CurMessageUser = item,
                                CurCoordinationLoginModel = tempLoginModel,
                                CurCallListData = new CallListData(CallStatus.Free,
                                                                   tempLoginModel.Information,
                                                                   tempLoginModel.UserName,
                                                                   tempLoginModel.UserID)
                            };

                            // 标记登陆者
                            if (tempLoginModel.SessionID.Equals(this.CurLoginModel.SessionID))
                            {
                                cm.IsLoginClient = true;
                            }
                            else if (!this.childHasLogin && tempLoginModel.SessionID.Equals(this.ChildLoginModel.SessionID))
                            {
                                tag = 1;
                            }

                            this.allClientModelList.Add(cm);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("获取在线用户列表出错!", ex);
                    }
                }

                // 当小麦助手首次登录时将消息记录转发给小麦
                if(tag > 0)
                {
                    // 必须等待小麦助手初始化完成后才能转发消息，不然可能会导致转发的消息丢失
                    for (int i = 0; i < 50; i ++ )
                    {
                        System.Threading.Thread.Sleep(100);
                        ExtendAppContext.Current.DoEvents();
                    }

                    this.childHasLogin = true;
                    foreach(TransMessageModel msg in this.allMsgList)
                    {
                        this.ForwardMsg(msg, JsonConvert.SerializeObject(this.ChildLoginModel));
                        msg.HasRead = true;
                    }
                }
            }
        }

        /// <summary>
        /// API：根据窗口名称查找窗口
        /// </summary>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string cls, string win);

        /// <summary>
        /// 主动获取用户列表
        /// </summary>
        public void GetUserDict()
        {
            while(!this.connection.ConnectionStatus)
            {
                System.Threading.Thread.Sleep(100);
            }

            // 获取所有在线用户
            this.connection.GetUserList();
        }
    }

}
