using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Domain;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Drawing.Design;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.AppPC.Views;

namespace MedicalSystem.Anes.Client.AppPC
{
    /// <summary>
    /// 文本弹出时间下拉框控件
    /// </summary>
    public class TimeTextBox : MTextBoxBorder
    {
        private TimeInPutCtrl Time
        {
            get
            {
                TimeInPutCtrl time = new TimeInPutCtrl();
                var text = !string.IsNullOrEmpty(this.Text) ? this.Text : this.Data != null ? Data.ToString() : "";
                DateTime t;
                if (DateTime.TryParse(text, out t))
                {
                    time.SelectedDateTime = t;
                }
                time.TimeInputType = this._timeInputType;
                time.ConfirmTime += time_ConfirmTime;
                return time;
            }
        }

        private TimeInputType _timeInputType = TimeInputType.DateTime;
        /// <summary>
        /// 时间控件输入类型
        /// </summary>
        [DefaultValue(TimeInputType.DateTime)]
        public TimeInputType TimeInputType
        {
            get { return _timeInputType; }
            set { _timeInputType = value; }
        }

        void time_ConfirmTime(TimeInPutEvent e)
        {
            this.Text = e.DateText;
            this.Data = e.DateValue;
            FocusHelper.FocusNext(this, false);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.Focused && string.IsNullOrEmpty(Convert.ToString(this.Value)))
            {
                var popup = Time;
                PopupForm.Show(this, popup, popup.Width, popup.Height);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                var popup = Time;
                PopupForm.Show(this, popup, popup.Width, popup.Height);
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

    }

}
