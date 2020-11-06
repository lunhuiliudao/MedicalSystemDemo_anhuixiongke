
using MedicalSystem.AnesIcuQuery.Models;
using MedicalSystem.AnesIcuQuery.Network;
using MedicalSystem.AnesWorkStationCoordination.Model;
using MedicalSystem.MedScreen.Common;
using MedicalSystem.Message.Common;
using MedicalSystem.Message.Lib;
using MedicalSystem.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientScreens
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
        private bool childHasLogin = false;                                                        // 判断一体机的小麦助手是否登录
        private List<ClientModel> allClientModelList = new List<ClientModel>();                        // 所有在线用户列表
        private List<TransMessageModel> allMsgList = new List<TransMessageModel>();                    // 所有的消息列表
        private string MedicalSystemMessageServerURL = MedicalSystem.AnesIcuQuery.Common.AppConfiguration.MedicalSystemMessageServerURL;            //消息平台ip地址

        public delegate void DelegateClientSendMessage(string message);

        public DelegateClientSendMessage SendClientMessage;

        public TransMessageManager()
        {
            curLoginModel = GetCurLoginModel();
            string name = this.SetClientName();
            this.connection = new Connection(name, curLoginModel.MessageServerURL);
            this.connection.DelegateSendMessage += this.DelegateSendMessage;
            this.connection.DelegateConnectionClosed += this.DelegateConnectionClosed;
        
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
                transMsgModel.SourceClientName = JsonConvert.SerializeObject(this.curLoginModel);

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
                if (transMsgModel.ReceiveDateTime == DateTime.MinValue)
                {
                    transMsgModel.ReceiveDateTime = DateTime.Now;
                }
                this.connection.SendMessage(targetName, JsonConvert.SerializeObject(transMsgModel));
            }
        }

        /// <summary>
        /// 获取客户端名称
        /// </summary>
        private string SetClientName()
        {
            LoginModel tempModel = this.curLoginModel;
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
                if (null == tar || (tar.SessionID.Equals(this.curLoginModel.SessionID)))
                {
                    return;
                }

                // 反序列化消息体
                TransMessageModel curTransMsgModel = JsonConvert.DeserializeObject<TransMessageModel>(message);
                if (null != curTransMsgModel)
                {
                    switch (curTransMsgModel.CurEnumFunctionType)
                    {
                        // 聊天记录
                        case EnumFunctionType.OperationScreen:
                            this.SendClientMessage(curTransMsgModel.MessageContent);
                            break;

                     
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("接收消息异常", ex);
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
            catch (Exception ex)
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
        /// 主动获取用户列表
        /// </summary>
        public void GetUserDict()
        {
            while (!this.connection.ConnectionStatus)
            {
                System.Threading.Thread.Sleep(100);
            }

            // 获取所有在线用户
            this.connection.GetUserList();
        }





        /// <summary>
        /// 登录消息平台实体类
        /// </summary>
        private LoginModel GetCurLoginModel()
        {
            // 自身的ID
            string sessionID = Guid.NewGuid().ToString();
            // 对应的小麦助手的ID
            string childSessionID = Guid.NewGuid().ToString();
            // 一体机的信息
            string information = "大屏";
            return new LoginModel(sessionID,
                "Ane",
                EnumAppType.Screen,
                "大屏",
                "大屏",
                information,
                MedicalSystemMessageServerURL,
                childSessionID);
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
                    this.childLoginModel = new LoginModel(curLoginModel.ChildSessionID, "Ane",
                                                          EnumAppType.AnesWorkStationAssistant,
                                                          curLoginModel.UserID,
                                                          curLoginModel.UserName,
                                                          curLoginModel.Information,
                                                          MedicalSystemMessageServerURL);
                }

                return this.childLoginModel;
            }
        }

        /// <summary>
        /// 获取是否存在未读消息
        /// </summary>
        /// <returns></returns>
        public Boolean GetHasReadMsg()
        {
            return allMsgList.Count(x => x.HasRead == false) > 0 ? true : false;
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
    }
}
