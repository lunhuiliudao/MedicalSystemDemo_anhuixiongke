using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC.Views.DailySchedule
{
    public partial class WeekView : UserControl
    {
        public WeekView()
        {
            InitializeComponent();
        }

        DateTime _currentDay;
        DateTime _serverDay;
        List<MedicalSystem.Anes.Domain.MED_DAILY_SCHEDULE> _list;

        readonly string[] weekStr = new string[] { "周一", "周二", "周三", "周四", "周五", "周六", "周日" };
        public void SetWeek(DateTime currentDay, DateTime serverDay, List<MedicalSystem.Anes.Domain.MED_DAILY_SCHEDULE> list)
        {
            _currentDay = currentDay;
            _serverDay = serverDay;
            _list = list;

            DateTime firstDay = DateTime.Parse(currentDay.ToString("yyyy-MM-01"));
            DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);
            firstDay = firstDay.AddDays(1 - (firstDay.DayOfWeek != DayOfWeek.Sunday ? (int)firstDay.DayOfWeek : 7));
            lastDay = lastDay.AddDays(7 - (firstDay.DayOfWeek != DayOfWeek.Sunday ? (int)firstDay.DayOfWeek : 7));

            int weeks = (lastDay - firstDay).Days / 7;


            int dayWidth = (this.Width - 8) / 7;
            int dayHeight = (this.Height - 28 - weeks - 1) / weeks;

            int left = 1; int top = 0;

            for (int i = 0; i < 7; i++)
            {
                int dayWidth1 = (this.Width - left - 7 + i) / (7 - i);
                Label lab = null;
                if (this.Controls.Count > i)
                {
                    lab = this.Controls[i] as Label;
                }
                else
                {
                    lab = new Label() { Height = 28, AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.FromArgb(93, 159, 220), ForeColor = Color.White, Text = weekStr[i] };
                    this.Controls.Add(lab);
                }
                lab.Left = left;
                lab.Top = top;
                lab.Width = dayWidth1;

                left += dayWidth1 + 1;
            }
            top += 29;

            for (int ii = 0; ii < weeks; ii++)
            {
                left = 1;
                int dayHeight1 = (this.Height - top - weeks + ii) / (weeks - ii);

                for (int i = 0; i < 7; i++)
                {
                    int dayWidth1 = (this.Width - left - 7 + i) / (7 - i);

                    AppPC.DayWeekView lab = null;
                    if (this.Controls.Count > (ii + 1) * 7 + i)
                    {
                        lab = this.Controls[(ii + 1) * 7 + i] as AppPC.DayWeekView;
                    }
                    else
                    {
                        lab = new AppPC.DayWeekView();

                        lab.DayViewClicked = () =>
                        {
                            if (this.DayClick != null)
                            {
                                this.DayClick(lab, new DayEventArgs() { CurrentDay = lab.CurrentDay });
                            }
                        };
                        lab.SetDoubleClick(lab);

                        this.Controls.Add(lab);
                    }
                    lab.Left = left;
                    lab.Top = top;
                    lab.Width = dayWidth1;
                    lab.Height = dayHeight1;

                    var day = firstDay.AddDays(ii * 7 + i);
                    var tmpList = list.Where(x => x.DAILY_DAY == day.Date).OrderBy(x => x.DAILY_NO).ToList();
                    lab.SetDay(day, day.Date == serverDay.Date, tmpList);

                    if (day.Month != currentDay.Month)
                    {
                        lab.BackColor = Color.Transparent;
                    }
                    else
                    {
                        lab.BackColor = Color.White;
                    }

                    left += dayWidth1 + 1;
                }

                top += dayHeight1 + 1;
            }
        }

        public event DayEventHandler DayClick;

        private void WeekView_SizeChanged(object sender, EventArgs e)
        {
            if (_list != null)
            {
                SetWeek(_currentDay, _serverDay, _list);
            }
        }

    }

    public delegate void DayEventHandler(object sender, DayEventArgs e);

    public class DayEventArgs : EventArgs
    {
        public DateTime CurrentDay { get; set; }
    }
}
