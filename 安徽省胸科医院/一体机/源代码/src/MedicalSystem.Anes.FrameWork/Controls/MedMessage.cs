using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
namespace MedicalSystem.Anes.FrameWork
{
    public partial class MedMessage : UserControl
    {
        public MedMessage()
        {
            InitializeComponent();
        }
        private string defaultMsg = "您好，欢迎使用DoCare麻醉临床信息系统";

        private void timerMsg_Tick(object sender, EventArgs e)
        {
            if (MessageQueue.MessageList != null && MessageQueue.MessageList.Count > 0)
            {
                labelMsg.ForeColor = MessageQueue.MessageList[0].TxtColor;
                labelMsg.Text = MessageQueue.MessageList[0].Message;
                MessageQueue.MessageList.RemoveAt(0);
            }
            else
            {
                labelMsg.ForeColor = System.Drawing.Color.DimGray;
                labelMsg.Text = defaultMsg;
            }
        }
    }
}
