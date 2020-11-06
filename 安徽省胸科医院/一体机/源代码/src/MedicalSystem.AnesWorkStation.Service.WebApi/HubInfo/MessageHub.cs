using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MedicalSystem.Message.Common;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.HubInfo
{
    public class Cache
    {
        /// <summary>
        /// 用户组
        /// </summary>
        public static List<string> GroupList = new List<string>();

        /// <summary>
        /// 用户列表
        /// </summary>
        public static ConcurrentDictionary<string, MessageUser> MsgUserDict = new ConcurrentDictionary<string, MessageUser>();
    }

    public class MessageHub : Hub
    {
        /// <summary>
        /// 发送广播消息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="message">信息</param>
        public void SendALLMessage(string name, string message)
        {     
            // Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})群发{2}", Context.ConnectionId, name, message));
            Clients.All.SendALLMessage(Context.ConnectionId, name, message);
        }

        /// <summary>
        /// 点对点发消息
        /// </summary>
        /// <param name="sendName">发送者</param>
        /// <param name="name">接受者</param>
        /// <param name="message">消息</param>
        public void SendMessage(string sendName, string name, string message)
        {
            if (!IsOnline(name))//接受者不在线
            {
                Clients.Client(Context.ConnectionId).UserUnLineMessage(name, message);
                return;
            }

            string connectionId = string.Empty;
            bool isself = false;
            foreach (KeyValuePair<string, MessageUser> item in Cache.MsgUserDict)
            {
                if (item.Value.UserName == name)//允许多重复用户登录多次，循环发送所有重复用户名消息
                {
                    connectionId = item.Key;
                    // Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})发给连接ID:{2}({3}),{4}", Context.ConnectionId, sendName, connectionId, name, message));
                    Clients.Client(connectionId).SendMessage(Context.ConnectionId, sendName, message);

                    if (item.Value.UserName == sendName)
                        isself = true;
                }
            }
            if (!string.IsNullOrEmpty(connectionId) && !isself)
            {
                //自己发给自己用于消息显示
                Clients.Client(Context.ConnectionId).SendMessage(Context.ConnectionId, sendName, message);
            }
        }


        /// <summary>
        /// 判断用户是否在线
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        private bool IsOnline(string name)
        {
            bool result = false;
            foreach (KeyValuePair<string, MessageUser> item in Cache.MsgUserDict)
            {
                if (item.Value.UserName == name)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 分组消息发送
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="groupName">分组名称</param>
        /// <param name="message">信息</param>
        public void SendGroupMessage(string name, string groupName, string message)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                ShowMessage(name, "不在该分组中，无法进行消息发送");
            }
            else
            {
                // Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})分组{2},消息{3}", Context.ConnectionId, name, groupName, message));
                Clients.Group(groupName, new string[0]).SendGroupMessage(Context.ConnectionId, name, groupName, message);
            }
        }

        /// <summary>
        /// 上线通知
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="name"></param>
        public void OnLine(string connectionId, string name)
        {
            Clients.All.OnLine(connectionId, name);
            RefreshUserList(name);
        }

        /// <summary>
        /// 操作消息回显
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="message">消息</param>
        private void ShowMessage(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendMessage(Context.ConnectionId, name, message);
        }
        /// <summary>
        /// 下线通知
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="name"></param>
        public void UnLine(string connectionId, string name)
        {
            Clients.All.UnLine(connectionId, name);
            RefreshUserList(name);
        }

        /// <summary>
        /// 重新上线
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="name"></param>
        public void Reconnected()
        {
            if (Cache.MsgUserDict.ContainsKey(Context.ConnectionId))
            {
                string name = Cache.MsgUserDict[Context.ConnectionId].UserName;
                // Program.MainForm.ShowLog(string.Format("用户:{0}({1})重新上线", Context.ConnectionId, name), 2);
                Clients.Client(Context.ConnectionId).Reconnected(Context.ConnectionId, name);
            }
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户</param>
        /// <param name="groupName">加入分组</param>
        public void Logined(string name, string groupName)
        {

            MessageUser user = new MessageUser() { UserName = name, GroupName = groupName, ConnectionId = Context.ConnectionId };
            user.action += () =>
            {
                //用户20s无心跳包应答，则视为掉线，会抛出事件，这里会接住，然后处理用户掉线动作。
                MessageUser outValue = null;
                if (Cache.MsgUserDict.ContainsKey(user.ConnectionId))
                {
                    user.Dispose();
                    Cache.MsgUserDict.TryRemove(user.ConnectionId, out outValue);
                    //Program.MainForm.ShowLog(string.Format("用户:{0}，下线", user.ConnectionId), 2);
                    //Program.MainForm.RefUserList();
                    UnLine(Context.ConnectionId, outValue.UserName);
                }
            };

            Cache.MsgUserDict.TryAdd(Context.ConnectionId, user);

            if (!string.IsNullOrEmpty(groupName))
            {
                if (!Cache.GroupList.Contains(groupName))//记录分组信息
                {
                    Cache.GroupList.Add(groupName);
                    //Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})创建分组{2}", Context.ConnectionId, name, groupName), 2);
                    ShowMessage(name, string.Format("分组{0}创建成功。", groupName));
                }

                Groups.Add(Context.ConnectionId, groupName);//加入聊天分组 
            }
            // Program.MainForm.RefUserList();
            OnLine(Context.ConnectionId, name);
        }

        /// <summary>
        /// 上下线推送用户列表
        /// </summary>
        /// <param name="name">用户名</param>
        public void RefreshUserList(string name)
        {
            //Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})推送用户列表", Context.ConnectionId, name));
            List<MessageUser> userList = new List<MessageUser>();
            foreach (KeyValuePair<string, MessageUser> item in Cache.MsgUserDict)
            {
                userList.Add(item.Value);
            }
            Clients.All.RefreshUserList(userList);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="name">用户名</param>
        public void GetUserList(string name)
        {
            //Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})获取用户列表", Context.ConnectionId, name));
            //自己发给自己用于消息显示
            List<MessageUser> userList = new List<MessageUser>();
            foreach (KeyValuePair<string, MessageUser> item in Cache.MsgUserDict)
            {
                userList.Add(item.Value);
            }
            Clients.Client(Context.ConnectionId).GetUserList(userList);
        }

        /// <summary>
        /// 获取分组列表
        /// </summary>
        /// <param name="name">用户名</param>
        public void GetGroupList(string name)
        {
            //Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})获取分组列表", Context.ConnectionId, name));
            //自己发给自己用于消息显示
            Clients.Client(Context.ConnectionId).GetGroupList(Cache.GroupList);
        }

        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="groupName">分组信息</param>
        public void CreateGroup(string name, string groupName)
        {
            if (!string.IsNullOrEmpty(groupName) && !Cache.GroupList.Contains(groupName))
            {
                Cache.GroupList.Add(groupName);
                //Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})创建分组{2}", Context.ConnectionId, name, groupName), 2);
                ShowMessage(name, string.Format("分组{0}创建成功。", groupName));
            }
            else
            {
                ShowMessage(name, "分组为空或者已经存在，创建失败。");
            }
        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="groupName">分组信息</param>
        public void DeleteGroup(string name, string groupName)
        {
            if (!string.IsNullOrEmpty(groupName) && Cache.GroupList.Contains(groupName))
            {
                bool isIn = false;
                foreach (KeyValuePair<string, MessageUser> item in Cache.MsgUserDict)
                {
                    if (item.Value.GroupName == groupName)
                    {
                        isIn = true; //该分组下面是否有用户
                        break;
                    }
                }
                if (!isIn)
                {
                    Cache.GroupList.Remove(groupName);
                    //Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})删除分组{2}", Context.ConnectionId, name, groupName), 2);
                    ShowMessage(name, string.Format("分组{0}删除成功。", groupName));
                }
                else
                {
                    ShowMessage(name, string.Format("分组{0}中还存用户，无法删除。", groupName));
                }
            }
            else
            {
                ShowMessage(name, "分组为空或者已经存在，删除失败。");
            }
        }

        /// <summary>
        /// 添加到分组
        /// </summary>
        /// <param name="name"></param>
        /// <param name="groupName"></param>
        public void AddToGroup(string name, string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                ShowMessage(name, "分组不能为空。");
            }
            else if (!Cache.GroupList.Contains(groupName))
            {
                ShowMessage(name, string.Format("用户组{0}，不存在。", groupName));
            }
            else if (Cache.MsgUserDict.ContainsKey(Context.ConnectionId))
            {
                MessageUser user = Cache.MsgUserDict[Context.ConnectionId];
                if (!string.IsNullOrEmpty(user.GroupName))
                {
                    ShowMessage(name, string.Format("已经存在用户组{0}，不能重复添加。", user.GroupName));
                }
                else
                {
                    user.GroupName = groupName;
                    Groups.Add(Context.ConnectionId, groupName);//加入聊天分组  
                    ShowMessage(name, string.Format("用户组{0}，加入成功。", user.GroupName));
                    //Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})加入分组{2}", Context.ConnectionId, name, groupName));
                }
            }
        }
        /// <summary>
        /// 退出分组
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="groupName">分组信息</param>
        public void ExitGroup(string name, string groupName)
        {
            if (!string.IsNullOrEmpty(groupName) && Cache.GroupList.Contains(groupName))
            {
                if (Cache.MsgUserDict.ContainsKey(Context.ConnectionId))
                {
                    MessageUser user = Cache.MsgUserDict[Context.ConnectionId];
                    if (string.IsNullOrEmpty(user.GroupName))
                    {
                        ShowMessage(name, string.Format("当前用户还未加入任何分组。", groupName));
                    }
                    else if (user.GroupName == groupName)//是该组 退出组
                    {
                        Groups.Remove(Context.ConnectionId, groupName);//退出聊天分组 
                        user.GroupName = string.Empty;
                        // Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})退出分组{2}", Context.ConnectionId, name, groupName));
                        ShowMessage(name, string.Format("分组{0}退出成功。", groupName));
                    }
                    else
                    {
                        ShowMessage(name, string.Format("所在分组与{0}不一致，退出失败。", groupName));
                    }
                }
            }
            else
            {
                ShowMessage(name, "分组为空或者不存在。");
            }
        }


        /// <summary>
        /// 设置心跳包
        /// </summary>
        private void SetHeartBeat()
        {
            if (Cache.MsgUserDict.ContainsKey(Context.ConnectionId))
            {
                Cache.MsgUserDict[Context.ConnectionId].count = 0;
            }
        }

        /// <summary>
        /// 内部消息命令
        /// </summary>
        /// <param name="cmd">接收方ID</param>
        /// <param name="message">信息</param>
        /// <param name="groupName">分组信息</param>
        public void SendCommand(string cmd, string message, string groupName)
        {

            switch (cmd)
            {
                case "logined":
                    Logined(message, groupName);
                    break;
                case "getUserList"://获取用户字典
                    GetUserList(message);
                    break;
                case "createGroup"://创建分组
                    CreateGroup(message, groupName);
                    break;
                case "deleteGroup"://删除分组
                    DeleteGroup(message, groupName);
                    break;
                case "getGroupList"://获取分组信息
                    GetGroupList(message);
                    break;
                case "exitGroup"://退出分组
                    ExitGroup(message, groupName);
                    break;
                case "addToGroup"://加入该分组
                    AddToGroup(message, groupName);
                    break;
                case "heartbeat"://心跳包
                    SetHeartBeat();
                    break;
                //case "getServerStatus"://设置服务端状态
                //    GetServerStatus(message);
                //    break;
            }
        }



        /// <summary>
        /// 获取服务端状态
        /// </summary>
        /// <param name="name">用户名</param>
        //public void GetServerStatus(string name)
        //{
        //    Program.MainForm.ShowLog(string.Format("连接ID:{0}({1})获取服务端状态", Context.ConnectionId, name));
        //    ServerStatus status = new ServerStatus() { ServerDateTime = DateTime.Now };
        //    //自己发给自己用于消息显示
        //    Clients.Client(Context.ConnectionId).GetServerStatus(status);
        //}


        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            //Program.MainForm.ShowLog(string.Format("用户:{0}，上线", Context.ConnectionId), 2);
            return base.OnConnected();
        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <returns></returns>
        //public override Task OnDisconnected()
        //{
        //    MessageUser outValue = null;
        //    if (Cache.MsgUserDict.ContainsKey(Context.ConnectionId))
        //    {
        //        Cache.MsgUserDict.TryRemove(Context.ConnectionId, out outValue);
        //        Program.MainForm.ShowLog(string.Format("用户:{0}，下线", Context.ConnectionId), 2);
        //        Program.MainForm.RefUserList();
        //        UnLine(Context.ConnectionId, outValue.UserName);
        //        outValue.Dispose();
        //    }
        //    return base.OnDisconnected();
        //}

        /// <summary>
        /// 重连
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            Reconnected();
            return base.OnReconnected();
        }
    }
}