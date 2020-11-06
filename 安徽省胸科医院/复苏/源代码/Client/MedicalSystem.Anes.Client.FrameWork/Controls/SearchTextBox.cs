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
    public partial class SearchTextBox : UserControl
    {

        //定义委托
        public delegate void BtnClickHandle(object sender, string var);
        //定义事件
        public event BtnClickHandle BtnClicked;
        public delegate void EditValueChangedHandle(object sender, string var);
        public event EditValueChangedHandle EditValueChanged;

        private string defaultTexe = "请输入内容";

        /// <summary>
        /// 默认文本
        /// </summary>
        public string DefaultText
        {
            get { return defaultTexe; }
            set { defaultTexe = value; }
        }
        private string currentText = string.Empty;
        public string CurrentText
        {
            get { return currentText; }
            set { currentText = value; }
        }
        public SearchTextBox()
        {
            InitializeComponent();
            ControlAddEvent addevent = new ControlAddEvent(Resources.搜索1, Resources.搜索2, Resources.搜索3);
            addevent.AddMouseMove(btnSearch);
        }
        public void ClearTextBox()
        {
            this.textBoxValue.Text = defaultTexe;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (BtnClicked != null)
                BtnClicked(this, textBoxValue.Text);
        }


        private void textBoxValue_Enter(object sender, EventArgs e)
        {
            //  进入时，清空
            if (textBoxValue.Text == defaultTexe)
                this.textBoxValue.Text = "";
            else
                textBoxValue.SelectAll();
        }

        private void textBoxValue_Leave(object sender, EventArgs e)
        {
            //  退出时，重新显示
            if (string.IsNullOrEmpty(textBoxValue.Text))
                this.textBoxValue.Text = defaultTexe;
        }

        private void SearchTextBox_Load(object sender, EventArgs e)
        {
            textBoxValue.Text = defaultTexe;
        }

        private void textBoxValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BtnClicked != null && !string.IsNullOrEmpty(textBoxValue.Text) && defaultTexe != textBoxValue.Text)
                    BtnClicked(this, textBoxValue.Text);
            }
        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            textBoxValue.Text = textBoxValue.Text.Replace("\r\n", "");
            textBoxValue.SelectionStart = textBoxValue.Text.Length;
            if (EditValueChanged != null && defaultTexe != textBoxValue.Text)
            {
                CurrentText = textBoxValue.Text;
                EditValueChanged(this, textBoxValue.Text);
            }
            else
            {
                CurrentText = "";
            }
        }
        private void SearchTextBox_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(129, 186, 230));
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }
}
