using MedicalSystem.Anes.Client.FrameWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class MessageBoxForm : BaseFormWithTitle
    {
        public MessageBoxForm()
        {
            InitializeComponent();
        }

        #region InitializeComponent

        private Panel panel1;
        private Panel panel2;
        private LableBorder lableBorder1;
        private ButtonBorder button1;
        private ButtonBorder button3;
        private ButtonBorder button2;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new MedicalSystem.Anes.Client.FrameWork.ButtonBorder();
            this.button2 = new MedicalSystem.Anes.Client.FrameWork.ButtonBorder();
            this.button1 = new MedicalSystem.Anes.Client.FrameWork.ButtonBorder();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lableBorder1 = new MedicalSystem.Anes.Client.FrameWork.LableBorder();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 50);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(237)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(418, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 27);
            this.button3.TabIndex = 5;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(237)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(332, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 27);
            this.button2.TabIndex = 4;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(237)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(246, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lableBorder1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 52);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panel2.Size = new System.Drawing.Size(518, 197);
            this.panel2.TabIndex = 15;
            // 
            // lableBorder1
            // 
            this.lableBorder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.lableBorder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lableBorder1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lableBorder1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.lableBorder1.Location = new System.Drawing.Point(20, 10);
            this.lableBorder1.Name = "lableBorder1";
            this.lableBorder1.Padding = new System.Windows.Forms.Padding(10);
            this.lableBorder1.Size = new System.Drawing.Size(478, 177);
            this.lableBorder1.TabIndex = 0;
            this.lableBorder1.Text = "消息";
            // 
            // MessageBoxForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 300);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MessageBoxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MessageBoxForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBoxForm_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region private

        // 参数为空时的默认值
        private static string defaultCaption = "系统提示";
        private static MessageBoxButtons defaultButtons = MessageBoxButtons.OK;
        private static MessageBoxIcon defaultIcon = MessageBoxIcon.None;

        #endregion

        Timer t = null;
        protected override void OnLoad(EventArgs e)
        {
            SetButton();
            SetIcon();
            base.OnLoad(e);

            if (Duration > 0 && BoxButtons == MessageBoxButtons.OK)
            {
                t = new Timer() { Interval = 1000 };
                int duration = this.Duration;
                string caption = this.Caption;
                t.Tick += (s, d) =>
                {
                    if (duration >= 0)
                    {
                        this.Caption = caption + "[" + duration + "秒后关闭...]";
                        duration--;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                        this.Dispose(true);
                    }
                };
                t.Start();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (t != null)
            {
                t.Dispose();
                t = null;
            }
            base.OnClosed(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (BoxButtons)
                {
                    case MessageBoxButtons.OK:
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                            this.Dispose(true);
                        }
                        break;
                    case MessageBoxButtons.OKCancel:
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                            this.Dispose(true);
                        }
                        break;
                    case MessageBoxButtons.YesNo:
                        {
                            DialogResult = DialogResult.Yes;
                            this.Close();
                            this.Dispose(true);
                        }
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        {
                            DialogResult = DialogResult.Yes;
                            this.Close();
                            this.Dispose(true);
                        }
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:
                        {
                            DialogResult = DialogResult.Abort;
                            this.Close();
                            this.Dispose(true);
                        }
                        break;
                    case MessageBoxButtons.RetryCancel:
                        {
                            DialogResult = DialogResult.Retry;
                            this.Close();
                            this.Dispose(true);
                        }
                        break;
                    default:
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                            this.Dispose(true);
                        }
                        break;
                }
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// 消息对话的结果
        /// </summary>
        internal static DialogResult result = DialogResult.None;

        public static Dictionary<string, int> TaskbarList = new Dictionary<string, int>();

        public static void ShowWithoutDialog(string text, int duration = 3)
        {
            TaskbarList.Clear();
            TaskbarList[text] = duration;
            return;
        }

        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="duration">消息确认框,持续显示几秒</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text, int duration = 3)
        {
            return Show(text, defaultCaption, defaultButtons, defaultIcon, duration);
        }
        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        /// <param name="duration">消息确认框,持续显示几秒</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text, string caption, int duration = 3)
        {
            return Show(text, caption, defaultButtons, defaultIcon, duration);
        }

        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="duration">消息确认框,持续显示几秒</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, int duration = 3)
        {
            return Show(text, caption, buttons, defaultIcon, duration);
        }

        /// <summary>
        /// 显示可包括文本，符号和按钮的消息框
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">图标</param>
        /// <param name="duration">消息确认框,持续显示几秒</param>
        /// <returns>结果</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, int duration = 3)
        {
            //初始化消息框
            MessageBoxForm dialogForm = new MessageBoxForm()
            {
                Caption = caption,
                Message = text,
                BoxButtons = buttons,
                BoxIcon = icon,
                Duration = duration
            };
            //弹出消息框
            dialogForm.ShowDialog();
            result = dialogForm.DialogResult;
            //返回结果
            return result;
        }

        public string Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public string Message
        {
            get { return this.lableBorder1.Text; }
            set { this.lableBorder1.Text = value; }
        }

        public MessageBoxButtons BoxButtons { get; set; }

        public MessageBoxIcon BoxIcon { get; set; }

        public int Duration { get; set; }

        #region 设置按钮

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
                        this.button1.Visible = false;
                        this.button2.Visible = false;
                        this.button3.Text = "确认";
                        this.button3.Click += btn3_Click;
                    }
                    break;
                case MessageBoxButtons.OKCancel:
                    {
                        this.button1.Visible = false;
                        //“确认”按钮
                        this.button2.Text = "确认";
                        this.button2.Click += btn2_Click;

                        //“取消”按钮
                        this.button3.Text = "取消";
                        this.button3.Click += btn3_Click;
                    }
                    break;
                case MessageBoxButtons.YesNo:
                    {
                        this.button1.Visible = false;
                        //“是”按钮
                        this.button2.Text = "是";
                        this.button2.Click += btn2_Click;

                        //“否”按钮
                        this.button3.Text = "否";
                        this.button3.Click += btn3_Click;
                    }
                    break;
                case MessageBoxButtons.YesNoCancel:
                    {
                        //“是”按钮
                        this.button1.Text = "是";
                        this.button1.Click += btn1_Click;

                        //“否”按钮
                        this.button2.Text = "否";
                        this.button2.Click += btn2_Click;

                        //“取消”按钮
                        this.button3.Text = "取消";
                        this.button3.Click += btn3_Click;
                    }
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        //“终止”按钮
                        this.button1.Text = "终止";
                        this.button1.Click += btn1_Click;

                        //“重试”按钮
                        this.button2.Text = "重试";
                        this.button2.Click += btn2_Click;

                        //“忽略”按钮
                        this.button3.Text = "忽略";
                        this.button3.Click += btn3_Click;
                    }
                    break;
                case MessageBoxButtons.RetryCancel:
                    {
                        this.button1.Visible = false;

                        //“重试”按钮
                        this.button2.Text = "重试";
                        this.button2.Click += btn2_Click;

                        //“取消”按钮
                        this.button3.Text = "取消";
                        this.button3.Click += btn3_Click;

                    }
                    break;
                default:
                    {
                        //“确认”按钮
                        this.button1.Visible = false;
                        this.button2.Visible = false;
                        this.button3.Text = "确认";
                        this.button3.Click += btn3_Click;
                    }
                    break;
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            switch (BoxButtons)
            {
                case MessageBoxButtons.OK:
                    break;
                case MessageBoxButtons.OKCancel:
                    break;
                case MessageBoxButtons.YesNo:
                    break;
                case MessageBoxButtons.YesNoCancel:
                    {
                        //“是”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Yes;
                    }
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        //“终止”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                    break;
                case MessageBoxButtons.RetryCancel:
                    break;
                default:
                    break;
            }
            this.Close();
            this.Dispose(true);
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            switch (BoxButtons)
            {
                case MessageBoxButtons.OK:
                    break;
                case MessageBoxButtons.OKCancel:
                    {
                        //“确认”按钮
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    break;
                case MessageBoxButtons.YesNo:
                    {
                        //“是”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Yes;
                    }
                    break;
                case MessageBoxButtons.YesNoCancel:
                    {
                        //“否”按钮
                        DialogResult = System.Windows.Forms.DialogResult.No;
                    }
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        //“重试”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Retry;
                    }
                    break;
                case MessageBoxButtons.RetryCancel:
                    {
                        //“重试”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Retry;
                    }
                    break;
                default:
                    break;
            }
            this.Close();
            this.Dispose(true);
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            switch (BoxButtons)
            {
                case MessageBoxButtons.OK:
                    {
                        //“确认”按钮
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    break;
                case MessageBoxButtons.OKCancel:
                    {
                        //“取消”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    }
                    break;
                case MessageBoxButtons.YesNo:
                    {
                        //“否”按钮
                        DialogResult = System.Windows.Forms.DialogResult.No;
                    }
                    break;
                case MessageBoxButtons.YesNoCancel:
                    {
                        //“取消”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    }
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        //“忽略”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Ignore;
                    }
                    break;
                case MessageBoxButtons.RetryCancel:
                    {
                        //“取消”按钮
                        DialogResult = System.Windows.Forms.DialogResult.Cancel;

                    }
                    break;
                default:
                    {
                        //“确认”按钮
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    break;
            }
            this.Close();
            this.Dispose(true);
        }

        private void SetIcon()
        {
            switch (BoxIcon)
            {
                case MessageBoxIcon.Error:
                    HeaderIcon = HeaderIconEnum.Error;
                    break;
                case MessageBoxIcon.Warning:
                    HeaderIcon = HeaderIconEnum.Warn;
                    break;
                case MessageBoxIcon.Question:
                    HeaderIcon = HeaderIconEnum.Question;
                    break;
                case MessageBoxIcon.Information:
                    HeaderIcon = HeaderIconEnum.Info;
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void panelExit_Click(object sender, EventArgs e)
        {
            DialogResult = result;
            this.Close();
            this.Dispose(true);
        }

        private void MessageBoxForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose(true);
            }
        }

    }

}
