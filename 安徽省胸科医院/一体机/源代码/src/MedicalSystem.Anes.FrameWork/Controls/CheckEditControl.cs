using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.FrameWork.Properties;

namespace MedicalSystem.Anes.FrameWork
{
    public partial class CheckEditControl : BaseControl
    {
        Image _normal;
        Image _checked;
        bool check;
        //定义委托
        public delegate void CheckedHandle(object sender, EventArgs e);
        //定义事件
        public event CheckedHandle CheckedChange;
        [Description("控件是否被选中")]
        public bool IsChecked
        {
            get { return check; }
            set
            {

                if (value == true)
                {
                    panelCheck.BackgroundImage = _checked;
                }
                else
                {
                    panelCheck.BackgroundImage = _normal;
                }
                check = value;
            }
        }
        [Description("显示的文字")]
        public string checkboxtext
        {
            get { return this.checkTxt.Text; }
            set { this.checkTxt.Text = value; }
        }


        public CheckEditControl()
        {
            _normal = Resources.未选中;
            _checked = Resources.选中;
            InitializeComponent();
            panelCheck.Image = _normal;
            panelCheck.Width = 25;
            panelCheck.Height = 25;
        }

        private void panelCheck_MouseDown(object sender, MouseEventArgs e)
        {
            if (check == false)
            {
                panelCheck.Image = _checked;
                check = true;
            }
            else
            {
                panelCheck.Image = _normal;
                check = false;
            }
            if (CheckedChange != null)
            {
                this.CheckedChange(this, e);
            }
        }

        private void checkTxt_TextChanged(object sender, EventArgs e)
        {
            //checkTxt.Width = checkTxt.Text.Length * ((int)this.Font.Size + 5);
            //this.Width = checkTxt.Width + 25;

        }

        public void CheckEditControl_SizeChanged(object sender, EventArgs e)
        {
            panelCheck.Width = 25;
            panelCheck.Height = 25;
        }
    }
}
