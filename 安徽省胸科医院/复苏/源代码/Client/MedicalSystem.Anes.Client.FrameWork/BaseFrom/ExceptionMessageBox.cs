//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      	frmMessageBox.cs
//功能描述(Description)：    信息框
//数据表(Tables)：		    
//作者(Author)：             吴文蛟
//日期(Create Date)：        2015/09/18
//R1:
//    修改作者:
//    修改日期：
//    修改理由:
//R2:
//    修改作者:
//    修改日期：
//    修改理由:

//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork.Properties;
using System.Drawing.Drawing2D;


namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class ExceptionMessageBox : BaseFormWithTitle
    {
        public ExceptionMessageBox()
        {
            InitializeComponent();
        }

        public Exception ExMessage { get; set; }

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="buttons">可见按钮</param>
        /// <param name="icon">提示图标</param>
        /// <param name="timeout">自动关闭所等待时间，如果不大于0则不自动关闭</param>
        /// <returns></returns>
        public static void Show(Exception ex)
        {
            new ExceptionMessageBox() { ExMessage = ex }.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (ExMessage != null)
            {
                txtMessage.Text = ExMessage.Message + "\r\n"+ ExMessage.StackTrace;
                var innerEX = ExMessage.InnerException;
                while (innerEX != null)
                {
                    txtMessage.Text +=
                        "\r\n\r\n" + innerEX.Message + "\r\n" + innerEX.StackTrace;
                    innerEX = innerEX.InnerException;
                }
            }
        }

        private void ExceptionMessageBox_Load(object sender, EventArgs e)
        {
            if (ExMessage != null)
            {
                txtMessage.Text = ExMessage.Message;
            }
        }
    }
}