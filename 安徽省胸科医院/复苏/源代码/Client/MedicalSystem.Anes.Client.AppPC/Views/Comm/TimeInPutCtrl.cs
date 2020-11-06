using System;
using System.Drawing;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using System.Drawing.Drawing2D;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC.Views
{
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

    public partial class TimeInPutCtrl : BaseControl
    {
        AccountRepository accountRepository = new AccountRepository();


        public TimeInPutCtrl()
        {
            InitializeComponent();
        }

        private bool _UserSetMode = false;
        private DateTime _SelectedDateTime = DateTime.MinValue;

        public DateTime SelectedDateTime
        {
            get { return _SelectedDateTime; }
            set
            {
                //初始化时，系统会设置最小值，屏蔽
                if (value == DateTime.MinValue)
                {
                    _UserSetMode = false;
                }
                else
                {
                    _UserSetMode = true;

                }
                _SelectedDateTime = value;

            }
        }

        private TimeInputType _timeInputType = TimeInputType.DateTime;
        public TimeInputType TimeInputType
        {
            get { return _timeInputType; }
            set
            {
                _timeInputType = value;
                switch (value)
                {
                    case TimeInputType.DateTime:
                        dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
                        break;
                    case TimeInputType.Date:
                        dtpDate.CustomFormat = "yyyy-MM-dd";
                        break;
                    case TimeInputType.Time:
                        dtpDate.CustomFormat = "HH:mm";
                        break;
                    default:
                        break;
                }
            }
        }

        public string Description { get { return this.label2.Text; } set { this.label2.Text = value; } }

        #region"键盘事件"

        public override bool RegisterControlByHotKey(string keyCode)
        {
            //if (this.Parent is BaseForm)
            //{
            //    //((BaseForm)this.Parent).InputMethods.InputType = InputMethodType.InputType.NO;
            //}
            switch (keyCode)
            {

                //case KeyCode.AppCode.Enter:
                //    UserEnter();
                //    return true;
                //case KeyCode.AppCode.OK:
                //    UserEnter();
                //    return true;
                case KeyCode.AppCode.Back:
                    UserCancel();
                    return true;
                default:
                    return base.RegisterControlByHotKey(keyCode);
            }


        }


        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                UserEnter();
            }
        }


        #endregion
        private void btnEnter_Click(object sender, EventArgs e)
        {
            UserEnter();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UserCancel();
        }


        /// <summary>
        /// 用户取消，关闭窗体
        /// </summary>
        private void UserCancel()
        {
            CloseWindow(DialogResult.Cancel);
        }

        /// <summary>
        /// 用户确认，选中当前日期
        /// </summary>
        public void UserEnter()
        {
            DateTime date = dtpDate.Value;

            _SelectedDateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);

            ExtendApplicationContext.Current.LastSelectedDateTime = _SelectedDateTime;
            CloseWindow(DialogResult.OK);
            if (this.ConfirmTime != null)
            {
                this.ConfirmTime(new TimeInPutEvent()
                {
                    DateText = _SelectedDateTime.ToString(dtpDate.CustomFormat),
                    DateValue = _SelectedDateTime
                });
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void CloseWindow(DialogResult diagResult)
        {
            if (this.Parent != null)
            {
                Form frm = (Form)this.Parent;
                frm.DialogResult = diagResult;
                frm.Close();
            }
        }

        private void SetDefaultDate()
        {
            if (ExtendApplicationContext.Current.LastSelectedDateTime != DateTime.MinValue)
            {
                if (!_UserSetMode)
                {
                    _SelectedDateTime = ExtendApplicationContext.Current.LastSelectedDateTime;
                }

                if (_SelectedDateTime != DateTime.MinValue)
                {
                    dtpDate.Value = _SelectedDateTime;
                }


            }
            else
            {
                dtpDate.Value = accountRepository.GetServerTime().Data;

            }

            // Application.DoEvents();
            dtpDate.Select();
            //默认选中时间点
            SendKeys.Send("{left}");

        }

        private void TimeInPutCtrl_Load(object sender, EventArgs e)
        {
            SetDefaultDate();

            dtpDate.AutoTurnRight = true;
        }

        public event TimeInPutHandler ConfirmTime;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(132, 135, 137), 1))
            {
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 3f, 1f };
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }

    public delegate void TimeInPutHandler(TimeInPutEvent e);

    public class TimeInPutEvent : EventArgs
    {
        public string DateText { get; set; }
        public DateTime DateValue { get; set; }
    }
}
