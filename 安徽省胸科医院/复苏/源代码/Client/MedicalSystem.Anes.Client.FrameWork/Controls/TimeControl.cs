using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class TimeControl : UserControl
    {

        //定义委托
        public delegate void KeyDownHandle(object sender, KeyEventArgs e);
        //定义事件
        public event KeyDownHandle MyKeyDown;


        public TimeControl()
        {
            InitializeComponent();
        }

        public enum TimeInputType
        {
            /// <summary>
            /// 日期时间
            /// </summary>
            DateTime,
            /// <summary>
            /// 日期
            /// </summary>
            Date,
            /// <summary>
            /// 时间
            /// </summary>
            Time
        }

        private DateTime dtime = DateTime.Now;

        public DateTime DateTimes
        {
            get
            {
                return GetDateTime();
            }
            set
            {
                dtime = value;
                InitDateTime();
            }
        }


        private string strMemo = "请输入时间：";

        public string StrMemo
        {
            get { return strMemo; }
            set
            {
                strMemo = value;
                labelMemo.Text = strMemo;
            }
        }

        private TimeInputType timeType = TimeInputType.Time;

        public TimeInputType TimeType
        {
            get { return timeType; }
            set { timeType = value; }
        }

        private void TimeControl_Load(object sender, EventArgs e)
        {
            switch (timeType)
            {
                case TimeInputType.Date:
                    textBoxYear.TabIndex = 0;
                    panelTime.Visible = false;
                    break;
                case TimeInputType.Time:
                    textBoxHour.TabIndex = 0;
                    panelYear.Visible = false;
                    panelmonth.Visible = false;
                    panelDay.Visible = false;
                    break;
            }
            InitDateTime();
        }

        public void SetFocus()
        {
            //if (timeType == TimeInputType.Time)
            {
                textBoxHour.Select();
                textBoxHour.Focus();
                textBoxHour.SelectAll();
            }
            //else
            //{
            //    textBoxYear.Select();
            //    textBoxYear.Focus();
            //    textBoxYear.SelectAll();
            //}
        }

        private void InitDateTime()
        {
            textBoxYear.Text = dtime.ToString("yyyy");
            textBoxMonth.Text = dtime.ToString("MM");
            textBoxDay.Text = dtime.ToString("dd"); ;
            textBoxHour.Text = dtime.ToString("HH");
            textBoxMinute.Text = dtime.ToString("mm");
        }

        private DateTime GetDateTime()
        {
            return new DateTime(Convert.ToInt32(textBoxYear.Text), Convert.ToInt32(textBoxMonth.Text),
                Convert.ToInt32(textBoxDay.Text), Convert.ToInt32(textBoxHour.Text),
                Convert.ToInt32(textBoxMinute.Text), 0);
        }


        private void textBoxYear_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxYear.Text.Length > 3)
            {
                if (Convert.ToInt32(textBoxYear.Text) > DateTime.MaxValue.Year || Convert.ToInt32(textBoxYear.Text) < DateTime.MinValue.Year)
                {
                    textBoxYear.Text = string.Empty;
                    textBoxYear.Focus();
                    textBoxYear.SelectAll();
                }
                else
                {
                    textBoxMonth.Focus();
                    textBoxMonth.SelectAll();
                }
            }
        }

        private void textBoxMonth_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMonth.Text.Length > 1)
            {
                if (Convert.ToInt32(textBoxMonth.Text) > 12 || Convert.ToInt32(textBoxMonth.Text) <= 0)
                {
                    textBoxMonth.Text = string.Empty;
                    textBoxMonth.Focus();
                    textBoxMonth.SelectAll();
                }
                else
                {
                    textBoxDay.Focus();
                    textBoxDay.SelectAll();
                }
            }
        }

        private void textBoxDay_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDay.Text.Length > 1)
            {
                int days = DateTime.DaysInMonth(Convert.ToInt32(textBoxYear.Text), Convert.ToInt32(textBoxMonth.Text));
                if (Convert.ToInt32(textBoxDay.Text) > days || Convert.ToInt32(textBoxDay.Text) <= 0)
                {
                    textBoxDay.Text = string.Empty;
                    textBoxDay.Focus();
                    textBoxDay.SelectAll();
                }
                else
                {
                    textBoxHour.Focus();
                    textBoxHour.SelectAll();
                }
            }
        }

        private void textBoxHour_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHour.Text.Length > 1)
            {
                if (Convert.ToInt32(textBoxHour.Text) > 23)
                {
                    textBoxHour.Text = string.Empty;
                    textBoxHour.Focus();
                    textBoxHour.SelectAll();
                }
                else
                {
                    textBoxMinute.Focus();
                    textBoxMinute.SelectAll();
                }
            }
        }
        private void textBoxMinute_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMinute.Text.Length > 1)
            {
                if (Convert.ToInt32(textBoxMinute.Text) > 59)
                {
                    textBoxMinute.Text = string.Empty;
                    textBoxMinute.Focus();
                    textBoxMinute.SelectAll();
                }
            }
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (MyKeyDown != null)
                this.MyKeyDown(this, e);
        }




    }
}
