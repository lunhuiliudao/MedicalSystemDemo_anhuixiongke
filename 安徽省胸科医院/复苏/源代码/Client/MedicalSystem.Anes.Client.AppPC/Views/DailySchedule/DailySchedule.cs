using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.AppPC.Views.DailySchedule;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class DailySchedule : BaseView
    {
        string _loginName = null;
        DateTime currentDay = DateTime.Now;
        DateTime serverDay = DateTime.Now;
        public List<MED_DAILY_SCHEDULE> dailyScheduleList = null;

        AccountRepository accountRepository = new AccountRepository();

        DailyScheduleRepository dailyScheduleRepository = new DailyScheduleRepository();


        public DailySchedule() : this(ExtendApplicationContext.Current.LoginUser.LOGIN_NAME) { }

        public DailySchedule(string loginName)
        {
            _loginName = loginName;
            InitializeComponent();
        }

        public class Status
        {
            public string NAME { get; set; }
            public int VALUE { get; set; }
        }

        public List<Status> statusList = new List<Status>() {
            new Status(){ NAME = "未完结", VALUE = 0 },
            new Status(){ NAME = "已完结", VALUE = 1 }
        };

        private void DailySchedule_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            this.Column4.DataSource = statusList;
            this.Column4.DisplayMember = "NAME";
            this.Column4.ValueMember = "VALUE";

            weekView.DayClick += weekView_DayClick;

            this.panelNoFlash1.Controls.Add(weekView);
            weekView.Dock = DockStyle.Fill;
            weekView.Visible = false;
            try
            {
                currentDay = accountRepository.GetServerTime().Data;
                serverDay = currentDay;
            }
            catch { }
            monthCalendar1.Visible = false;
            TitleFormat();

        }

        void weekView_DayClick(object sender, DayEventArgs e)
        {
            currentDay = e.CurrentDay;
            this.radioButton2.Checked = true;
        }

        WeekView weekView = new WeekView();

        /// <summary>
        /// 格式化标题
        /// </summary>
        private void TitleFormat()
        {
            weekView.Visible = false;
            dataGridView1.Visible = false;

            if (this.radioButton1.Checked)
            {
                labMonthTitle.Text = currentDay.ToString("yyyy年MM月");

                weekView.Visible = true;
                dailyScheduleList = dailyScheduleRepository.GetMonthList(currentDay, _loginName).Data;
                weekView.SetWeek(currentDay, serverDay, dailyScheduleList);
            }
            else
            {
                labMonthTitle.Text = currentDay.ToString("MM月dd日");

                dataGridView1.Visible = true;
                dailyScheduleList = dailyScheduleRepository.GetDayList(currentDay, _loginName).Data.OrderBy(x => x.DAILY_NO).ToList();
                dataGridView1.DataSource = dailyScheduleList;

            }

            labInfo.Text = string.Format("共{0}条记录", dailyScheduleList == null ? 0 : dailyScheduleList.Count);

            monthCalendar1.Visible = false;
        }

        /// <summary>
        /// 日月切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TitleFormat();
        }

        /// <summary>
        /// 前一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                currentDay = currentDay.AddMonths(-1);
            }
            else
            {
                currentDay = currentDay.AddDays(-1);
            }
            TitleFormat();
        }

        /// <summary>
        /// 后一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                currentDay = currentDay.AddMonths(1);
            }
            else
            {
                currentDay = currentDay.AddDays(1);
            }
            TitleFormat();
        }

        private void labMonthTitle_Resize(object sender, EventArgs e)
        {
            OnSizeChanged(e);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDay = monthCalendar1.SelectionStart;
            TitleFormat();
            monthCalendar1.Visible = false;
        }

        private void labMonthTitle_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
            {
                monthCalendar1.Visible = false;
            }
            else
            {
                monthCalendar1.SelectionStart = monthCalendar1.SelectionEnd = currentDay;
                monthCalendar1.Visible = true;

                monthCalendar1.Left = (this.Width - monthCalendar1.Width) / 2;
                monthCalendar1.Top = this.panel2.Height + this.panel2.Top;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < dailyScheduleList.Count && dataGridView1.Columns[e.ColumnIndex].Name == "ColStatusImage") //状态图标
            {
                if (dailyScheduleList[e.RowIndex].STATE == 0)
                    e.Value = Resources.unfinished;
                else
                    e.Value = Resources.finished;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EditSchedule view = new EditSchedule(currentDay, _loginName);
            DialogHostFormPC pc = new DialogHostFormPC("编辑事项", view.Width, view.Height);
            pc.Child = view;
            pc.ShowDialog();

            TitleFormat();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditItem(dailyScheduleList[e.RowIndex]);
        }

        public void EditItem(MedicalSystem.Anes.Domain.MED_DAILY_SCHEDULE item)
        {
            EditSchedule view = new EditSchedule(currentDay, _loginName);
            view.Edit(item);
            DialogHostFormPC pc = new DialogHostFormPC("编辑事项", view.Width, view.Height);
            pc.Child = view;
            pc.ShowDialog();

            TitleFormat();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dailyScheduleRepository.Update(dailyScheduleList[e.RowIndex]);
        }

        private void DailySchedule_SizeChanged(object sender, EventArgs e)
        {
            this.labMonthTitle.Left = (this.panel1.Width - this.labMonthTitle.Width) / 2;
            this.labMonthTitle.Top = (this.panel1.Height - this.labMonthTitle.Height - this.panel1.Padding.Bottom);

            this.pictureBox1.Left = this.labMonthTitle.Left - this.pictureBox1.Width;
            this.pictureBox1.Top = (this.panel1.Height - this.pictureBox1.Height - this.panel1.Padding.Bottom);

            this.pictureBox2.Left = this.labMonthTitle.Left + this.labMonthTitle.Width;
            this.pictureBox2.Top = (this.panel1.Height - this.pictureBox2.Height - this.panel1.Padding.Bottom);

            this.labInfo.Left = panelNoFlash1.Left - 2;
            this.labInfo.Top = panelNoFlash1.Top + panelNoFlash1.Height + 2;

            this.btnOk.Left = panelNoFlash1.Left + panelNoFlash1.Width - 8 - btnOk.Width;
            this.btnOk.Top = panelNoFlash1.Top + panelNoFlash1.Height + 2;
        }


    }
}
