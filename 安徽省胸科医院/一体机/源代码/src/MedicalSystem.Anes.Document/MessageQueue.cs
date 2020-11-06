using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    /// <summary>
    /// 消息级别
    /// </summary>
    public enum MsgGrade
    {
        /// <summary>
        ///  实时显示的内容
        ///  例如，保存成功
        /// </summary>
        First,
        /// <summary>
        /// 一级
        /// </summary>
        One,
        /// <summary>
        /// 二级
        /// </summary>
        Two,
    }

    /// <summary>
    /// 消息类
    /// </summary>
    public class MessageInfo
    {
        private MsgGrade msgGrade = MsgGrade.First;

        /// <summary>
        /// 消息级别
        /// </summary>
        public MsgGrade MessageGrade
        {
            get { return msgGrade; }
            set { msgGrade = value; }
        }

        private string _message = "您好，欢迎使用DoCare麻醉临床信息系统";

        /// <summary>
        /// 信息内容
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public Color _txtColor = Color.Black;
        public Color TxtColor
        {
            get { return _txtColor; }
            set { _txtColor = value; }
        }
    }
    /// <summary>
    /// 消息队列
    /// </summary>
    public class MessageQueue
    {
        public static List<MessageInfo> MessageList = new List<MessageInfo>();

        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="msgGrade">消息级别,默认为 MsgGrade.First</param>
        public static void AddMessage(string message, Color txtColor, MsgGrade msgGrade = MsgGrade.First)
        {
            if (msgGrade == MsgGrade.First)
            {
                MessageList.Insert(0, new MessageInfo() { Message = message, MessageGrade = msgGrade, TxtColor = txtColor });//立即显示消息
            }
            else if (MessageList != null && MessageList.Count == 0)//无信息
            {
                MessageList.Add(new MessageInfo() { Message = message, MessageGrade = msgGrade, TxtColor = txtColor });
            }
            else
            {
                int index = -1;
                foreach (MessageInfo item in MessageList)
                {
                    if (msgGrade == MsgGrade.One && item.MessageGrade == msgGrade)//一级消息
                    {
                        index++;
                    }
                    else
                    {
                        if (index >= 0)
                        {
                            MessageList.Insert(index, new MessageInfo() { Message = message, MessageGrade = msgGrade });//要消息直插入到同等级消息下面
                        }
                        else
                        {
                            MessageList.Add(new MessageInfo() { Message = message, MessageGrade = msgGrade });//不重要消息直接加到最后
                        }
                        break;
                    }
                }
            }
        }
    }
}
