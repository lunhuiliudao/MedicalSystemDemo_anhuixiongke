using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class CurrentTimeControl : BaseControl, ITimeTick
    {
        AccountRepository accountRepository = new AccountRepository();

        [ToolboxItem(true)]
        public CurrentTimeControl()
        {
            InitializeComponent();
        }

        public delegate void TickRequest(object sender, EventArgs e);
        /// <summary>
        /// 每秒请求响应
        /// </summary>
        public event TickRequest OnTickRequest;

        public delegate void RefreshTimeSpanRequest(object sender, EventArgs e);
        public event RefreshTimeSpanRequest OnRefreshTimeSpanRequest;
        int _RefreshTimeSpan = 120;
        /// <summary>
        /// 文书刷新时间间隔（秒）
        /// </summary>
        public int RefreshTimeSpan
        {
            get { return _RefreshTimeSpan; }
            set { _RefreshTimeSpan = value; }
        }

        private string GetWeek(string week)
        {
            switch (week)
            {
                case "Monday": week = "星期一"; break;
                case "Tuesday": week = "星期二"; break;
                case "Wednesday": week = "星期三"; break;
                case "Thursday": week = "星期四"; break;
                case "Friday": week = "星期五"; break;
                case "Saturday": week = "星期六"; break;
                case "Sunday": week = "星期日"; break;
            }

            return week;
        }

        string weekstr = DateTime.Now.DayOfWeek.ToString();// AccountService.GetServerTime().DayOfWeek.ToString();
        public void OnTicked()
        {
            lbDate.Text = accountRepository.GetServerTime().Data.ToString("yyyy-MM-dd");
            lbTime.Text = accountRepository.GetServerTime().Data.ToString("HH:mm");
            weekstr = accountRepository.GetServerTime().Data.DayOfWeek.ToString();
            lbWeek.Text = GetWeek(weekstr);
        }

        private void CurrentTimeControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode && MainFrm.MainTickFrm != null)
                MainFrm.MainTickFrm.Register(this);
        }
    }

}
