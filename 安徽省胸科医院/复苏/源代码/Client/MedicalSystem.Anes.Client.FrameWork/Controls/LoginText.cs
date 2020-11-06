using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork.Properties;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class LoginText : UserControl
    {
        public LoginText()
        {
            InitializeComponent();

        }

        public enum LoginTextType
        {
            用户名,
            密码
        }

        //定义委托
        public delegate void ValueChangeHandle(object sender, EventArgs e);
        //定义事件
        public event ValueChangeHandle ValueChange;


        //定义委托
        public delegate void ValueKeyDownHandle(object sender, KeyEventArgs e);
        //定义事件
        public event ValueKeyDownHandle ValueKeyDown;



        private string defaultText = "用户名";

        /// <summary>
        /// 默认文本
        /// </summary>
        public string DefaultText
        {
            get { return defaultText; }
            set { defaultText = value; }
        }

        private bool txtReadOnly = false;
        public bool TxtReadOnly
        {
            get { return txtReadOnly; }
            set { txtReadOnly = value; }
        }

        private string text = string.Empty;
        /// <summary>
        /// 内容
        /// </summary>
        public string Value
        {
            get { return txtbox.Text; }
            set
            {
                text = value;
                txtbox.Text = value;
            }
        }


        private LoginTextType loginType = LoginTextType.用户名;

        /// <summary>
        /// 按钮样式颜色
        /// </summary>
        public LoginTextType LoginType
        {
            get { return loginType; }
            set { loginType = value; }
        }

        private void LoginText_Load(object sender, EventArgs e)
        {
            //ControlAddEvent cotrol = null;
            switch (loginType)
            {
                case LoginTextType.用户名:
                    //cotrol = new ControlAddEvent(Resources.login_用户名1, Resources.login_用户名2, Resources.login_用户名2);
                    panelICO.BackgroundImage = Resources.login_用户名1;
                    break;
                case LoginTextType.密码:
                    //cotrol = new ControlAddEvent(Resources.login_密码_1, Resources.login_密码_2, Resources.login_密码_2);
                    panelICO.BackgroundImage = Resources.login_密码_1;
                    break;

            }
            //cotrol.AddMouseMove(panelICO);
            new ControlAddEvent(Resources.login_删除2, Resources.login_删除2, Resources.login_删除2).AddMouseMove(panelClear);
        }

        private void panelClear_Click(object sender, EventArgs e)
        {
            txtbox.Text = string.Empty;
            txtbox.Focus();
        }

        bool isEdit = false;


        private void txtbox_Enter(object sender, EventArgs e)
        {
            isEdit = true;
            this.BackColor = Color.FromArgb(60, 156, 229);
            switch (loginType)
            {
                case LoginTextType.用户名:
                    panelICO.BackgroundImage = Resources.login_用户名2;
                    break;
                case LoginTextType.密码:
                    panelICO.BackgroundImage = Resources.login_密码_2;
                    break;
            }

            if (txtbox.Text == defaultText)
                this.txtbox.Text = string.Empty;
            this.txtbox.ForeColor = Color.FromArgb(0, 132, 255);
            this.txtbox.BackColor = Color.FromArgb(223, 242, 252);
            this.BackColor = Color.FromArgb(223, 242, 252);
            panelClear.BackgroundImage = Resources.login_删除2;
        }

        private void txtbox_Leave(object sender, EventArgs e)
        {
            isEdit = false;
            this.BackColor = Color.FromArgb(169, 223, 245);
            switch (loginType)
            {
                case LoginTextType.用户名:
                    panelICO.BackgroundImage = Resources.login_用户名1;
                    break;
                case LoginTextType.密码:
                    panelICO.BackgroundImage = Resources.login_密码_1;
                    break;
            }

            //  退出时，重新显示
            if (string.IsNullOrEmpty(txtbox.Text))
            {
                this.txtbox.Text = defaultText;
                if (loginType == LoginTextType.密码)
                    txtbox.UseSystemPasswordChar = false;
            }
            else
            {
                if (loginType == LoginTextType.密码)
                    txtbox.UseSystemPasswordChar = true;
            }
            // this.txtbox.ForeColor = Color.FromArgb(196, 223, 245);
            this.txtbox.BackColor = Color.White;
            this.BackColor = Color.White;
            panelClear.BackgroundImage = Resources.login_删除1;
        }



        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbox.Text))
            {
                if (loginType == LoginTextType.密码)
                    txtbox.UseSystemPasswordChar = true;
            }

            if (ValueChange != null)
                ValueChange(sender, e);
        }
        private void LoginText_Paint(object sender, PaintEventArgs e)
        {
            if (isEdit)
            {
                Pen pen = new Pen(Color.FromArgb(60, 156, 229));
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 2, this.Height - 2));
            }
            else
            {
                Pen pen = new Pen(Color.FromArgb(129, 186, 230));
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 2, this.Height - 2));
            }
        }


        public void SelectAll()
        {
            txtbox.Focus();
            txtbox.SelectAll();
        }

        private void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (ValueKeyDown != null)
                ValueKeyDown(sender, e);
        }
    }
}
