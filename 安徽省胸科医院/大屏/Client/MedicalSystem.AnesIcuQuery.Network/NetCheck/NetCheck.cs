using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using DevExpress.XtraEditors;
using MedicalSystem.AnesIcuQuery.Network;

namespace MedicalSystem.MedScreen.Network
{
    [Serializable(), ToolboxItem(false)]
    public partial class NetCheck : DevExpress.XtraEditors.XtraForm
    {
        public NetCheck()
        {
            InitializeComponent();
        }
        //网络连接中断
        private bool NetworkInterruption = false;

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (timerCheck.Tag != null && timerCheck.Tag.ToString() == "ReadyToShutDown")
            {
                timerCheck.Stop();
                this.Close();
            }
            try
            {
                if (DataOperator.HttpWebApi<bool>(ApiUrlEnum.TestNet, null))
                {
                    listBoxMsg.Items.Add("数据库服务器已连降，网络已恢复...");
                    listBoxMsg.Items.Add("检查服务将自动关闭");

                    listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1;
                    timerCheck.Tag = "ReadyToShutDown";
                    NetworkInterruption = false;
                }
            }
            catch(Exception ex)
            {
                NetworkInterruption = true ;
                timerCheck.Tag = "ContinueToTest";

                listBoxMsg.Items.Add("无法连接数据库服务器，请先检查网络...");
                if (ex.Message.Contains("ORA-12560") || ex.Message.Contains("ORA-03113") || ex.Message.Contains("ORA-12170"))
                {
                    listBoxMsg.Items.Add("请检查数据库服务库实例是否启动...");
                    listBoxMsg.Items.Add("请检查数据库服务库监听服务是否启动...");
                    listBoxMsg.Items.Add("5秒钟之后进行重新连接...");
                    listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1;
                }
                else if (ex.Message.Contains("指定的网络名不再可用"))
                {
                    listBoxMsg.Items.Add("请检查远程数据库链路是否通畅，如网线，网卡等...");
                    listBoxMsg.Items.Add("5秒钟之后进行重新连接...");
                    listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1;
                }
                else
                {
                    listBoxMsg.Items.Add("5秒钟之后进行重新连接...");
                    listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1;
                }
            }
        }

        private void NetCheck_Load(object sender, EventArgs e)
        {
            NetworkInterruption = true;
            listBoxMsg.Items.Clear();
            listBoxMsg.Items.Add("请先检查网线是否松动...");
            listBoxMsg.Items.Add("请先数据库服务是否已经启动...");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "网络连接中断，正在检查，请稍后...";
            marqueeProgressBarControl1.Visible = true;
            timerCheck.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NetCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NetworkInterruption)
            {
                DialogResult dialogResult = MessageBox.Show("网络连接中断，系统处于保护状态，无法操作，请稍等。是否强制退出系统？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.DoEvents();
                    System.Environment.Exit(System.Environment.ExitCode);
                }
                else
                {
                    MessageLabel.Text = "网络连接中断，系统处于保护状态，无法操作，请稍等...";
                    e.Cancel = true;
                }
            }
            else
            {
                this.Hide();
            }
        }
    }
}
