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
    public partial class ButtonColor : UserControl
    {
        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle BtnClicked;


        public enum ButtonType
        {
            蓝色,
            绿色,
            灰色
        }

        private string _title = "标题";
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private ButtonType buttonType = ButtonType.蓝色;

        /// <summary>
        /// 按钮样式颜色
        /// </summary>
        public ButtonType ButtonColorType
        {
            get { return buttonType; }
            set { buttonType = value; }
        }


        public ButtonColor()
        {
            InitializeComponent();
        }

        private void panelBtn_Paint(object sender, PaintEventArgs e)
        {
            Graphics gac = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            if (buttonType == ButtonType.灰色)
            {
                gac.DrawString(this._title, new Font("Tahoma", 12), new SolidBrush(Color.Gray), this.ClientRectangle, sf);
            }
            else
            {
                gac.DrawString(this._title, new Font("Tahoma", 12), new SolidBrush(Color.Black), this.ClientRectangle, sf);
            }
        }
        private void panelBtn_Click(object sender, EventArgs e)
        {
            if (BtnClicked != null)
            {
                this.BtnClicked(this, e);
            }
        }

        private void ButtonColor_Load(object sender, EventArgs e)
        {
            ControlAddEvent cotrol = null;
            switch (buttonType)
            {
                case ButtonType.蓝色:
                    cotrol = new ControlAddEvent(Resources.蓝1, Resources.蓝2, Resources.蓝3);
                    panelBtn.BackgroundImage = Resources.蓝1;

                    break;
                case ButtonType.绿色:
                    cotrol = new ControlAddEvent(Resources.绿1, Resources.绿2, Resources.绿3);
                    panelBtn.BackgroundImage = Resources.绿1;
                    break;
                case ButtonType.灰色:
                    cotrol = new ControlAddEvent(Resources.灰1, Resources.灰2, Resources.灰3);
                    panelBtn.BackgroundImage = Resources.灰1;
                    break;
            }
            cotrol.AddMouseMove(panelBtn);
        }
    }
}
