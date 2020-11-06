using MedicalSystem.Anes.FrameWork.Properties;
using MedicalSystem.Anes.Document.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    public partial class MessageBoxFormPC : DialogHostFormPC
    {
        public MessageBoxFormPC()
        {
            InitializeComponent();
        }

        private void MessageBoxFormPC_Load(object sender, EventArgs e)
        {
            ControlAddEvent cotrol = new ControlAddEvent(Resources.x2_1, Resources.x2_2, Resources.x2_3);
            cotrol.AddMouseMove(picClose);

            SetIcon();
            SetButton();
        }

        public string Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public string Message
        {
            get { return this.textBoxMsg.Text; }
            set { this.textBoxMsg.Text = value; }
        }

        public MessageBoxButtons BoxButtons { get; set; }

        public MessageBoxIcon BoxIcon { get; set; }


        private void SetIcon()
        {
            switch (BoxIcon)
            {
                case MessageBoxIcon.Error:
                    pictureBoxMsgIco.Image = Resources.错误;
                    break;
                case MessageBoxIcon.Warning:
                    pictureBoxMsgIco.Image = Resources.警告;

                    break;
                case MessageBoxIcon.Question:
                    pictureBoxMsgIco.Image = Resources.询问;

                    break;
                case MessageBoxIcon.Information:
                    pictureBoxMsgIco.Image = Resources.信息;
                    break;
                default:
                    pictureBoxMsgIco.Image = Resources.信息;
                    break;
            }
        }


        /// <summary>
        /// 设置按钮
        /// </summary>
        /// <param name="button">需产生的按钮组</param>
        private void SetButton()
        {
            switch (BoxButtons)
            {
                case MessageBoxButtons.OK:
                    {
                        //“确认”按钮
                        this.buttonColorExit.Visible = false;
                        this.buttonColorOK.Title = "确定";
                    }
                    break;
                case MessageBoxButtons.OKCancel:
                    {
                        //“确认”按钮
                        this.buttonColorOK.Title = "确定";
                        //“取消”按钮
                        this.buttonColorExit.Title = "取消";
                    }
                    break;
                case MessageBoxButtons.YesNo:
                    {
                        //“是”按钮
                        this.buttonColorOK.Title = "是";

                        //“否”按钮
                        this.buttonColorExit.Title = "否";
                    }
                    break;
                //case MessageBoxButtons.YesNoCancel:
                //    {
                //        //“是”按钮
                //        this.button1.Text = "是";
                //        this.button1.Click += btn1_Click;

                //        //“否”按钮
                //        this.button2.Text = "否";
                //        this.button2.Click += btn2_Click;

                //        //“取消”按钮
                //        this.button3.Text = "取消";
                //        this.button3.Click += btn3_Click;
                //    }
                //    break;
                //case MessageBoxButtons.AbortRetryIgnore:
                //    {
                //        //“终止”按钮
                //        this.button1.Text = "终止";
                //        this.button1.Click += btn1_Click;

                //        //“重试”按钮
                //        this.button2.Text = "重试";
                //        this.button2.Click += btn2_Click;

                //        //“忽略”按钮
                //        this.button3.Text = "忽略";
                //        this.button3.Click += btn3_Click;
                //    }
                //    break;
                //case MessageBoxButtons.RetryCancel:
                //    {
                //        this.button1.Visible = false;

                //        //“重试”按钮
                //        this.button2.Text = "重试";
                //        this.button2.Click += btn2_Click;

                //        //“取消”按钮
                //        this.button3.Text = "取消";
                //        this.button3.Click += btn3_Click;

                //    }
                //    break;
                default:
                    {
                        //“确认”按钮
                        this.buttonColorExit.Visible = false;
                        this.buttonColorOK.Title = "确定";
                    }
                    break;
            }
        }
        /// <summary>
        /// 消息对话的结果
        /// </summary>
        internal static DialogResult result = DialogResult.None;

        // 参数为空时的默认值
        private static string defaultCaption = "系统提示";
        private static MessageBoxButtons defaultButtons = MessageBoxButtons.OK;
        private static MessageBoxIcon defaultIcon = MessageBoxIcon.None;

        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text)
        {
            return Show(text, defaultCaption, defaultButtons, defaultIcon);
        }
        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text, string caption)
        {
            return Show(text, caption, defaultButtons, defaultIcon);
        }
        public static DialogResult Show(string text, MessageBoxIcon defaultIcon)
        {
            return Show(text, defaultCaption, defaultButtons, defaultIcon);
        }

        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(text, caption, buttons, defaultIcon);
        }

        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">图标</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            //初始化消息框
            MessageBoxFormPC dialogForm = new MessageBoxFormPC()
            {
                Caption = caption,
                Message = text,
                BoxButtons = buttons,
                BoxIcon = icon,
            };

            dialogForm.TopMost = true;
            //弹出消息框
            dialogForm.ShowDialog();
            result = dialogForm.DialogResult;
            //返回结果
            return result;
        }

        private void buttonColorOK_BtnClicked(object sender, EventArgs e)
        {
            switch (((ButtonColor)sender).Title)
            {
                case "是":
                    this.DialogResult = DialogResult.Yes;
                    break;
                case "确定":
                    this.DialogResult = DialogResult.OK;
                    break;
                default:
                    this.DialogResult = DialogResult.None;
                    break;
            }
            this.Close();
        }

        private void buttonColorExit_BtnClicked(object sender, EventArgs e)
        {
            switch (((ButtonColor)sender).Title)
            {
                case "取消":
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case "否":
                    this.DialogResult = DialogResult.No;
                    break;
                default:
                    this.DialogResult = DialogResult.None;
                    break;
            }
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            switch (buttonColorExit.Title)
            {
                case "取消":
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case "否":
                    this.DialogResult = DialogResult.No;
                    break;
                default:
                    this.DialogResult = DialogResult.None;
                    break;
            }
            this.Close();
        }
    }
}
