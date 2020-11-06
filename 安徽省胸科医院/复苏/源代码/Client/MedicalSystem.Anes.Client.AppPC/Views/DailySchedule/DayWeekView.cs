using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using System.Drawing.Drawing2D;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.AppPC.Views.DailySchedule;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class DayWeekView : BaseView
    {
        public static readonly Color UN_FINISHED_COLOR = Color.FromArgb(255, 224, 202);
        public static readonly Color FINISHED_COLOR = Color.FromArgb(210, 220, 249);


        DateTime currentDay = DateTime.Now;
        bool toDay = false;
        List<MED_DAILY_SCHEDULE> data = null;

        public DayWeekView()
        {
            InitializeComponent();
        }

        public DateTime CurrentDay
        {
            get { return currentDay; }
        }

        public void SetDay(DateTime now, bool today, List<MED_DAILY_SCHEDULE> list)
        {
            currentDay = now;
            toDay = today;
            data = list;

            this.labTitle.Visible = false;
            if (today)
            {
                this.labDay.Image = Resources.day1;
                this.labDay.Text = "";
                if (list != null && list.Count > 0)
                {
                    this.labTitle.Text = string.Format("代办事项{0}项", list.Count);
                    this.labTitle.Visible = true;
                }
            }
            else if (list != null && list.Count > 0)
            {
                this.labDay.Image = Resources.day2;
                this.labDay.Text = now.Day.ToString();
                this.labDay.ForeColor = Color.White;

                this.labTitle.Text = string.Format("代办事项{0}项", list.Count);
                this.labTitle.Visible = true;
            }
            else
            {
                this.labDay.Image = null;
                this.labDay.Text = now.Day.ToString();
                this.labDay.ForeColor = Color.Black;
            }

            PanelBorder p = null;
            Label lab = null;
            for (int i = 0; i < this.panelNoFlash2.Controls.Count || list != null && i < list.Count; i++)
            {
                if (i < panelTmpList.Count)
                {
                    p = panelTmpList[i] as PanelBorder;
                    lab = p.Controls[0] as Label;
                }
                else
                {
                    p = new PanelBorder() { Height = 26 };
                    p.Padding = new Padding(6);
                    p.DashStyle = DashStyle.Custom;
                    p.DashPattern = new float[] { 1f, 3f };
                    panelTmpList.Add(p);
                    this.panelNoFlash2.Controls.Add(p);
                    p.Dock = DockStyle.Top;

                    lab = new Label();
                    p.Controls.Add(lab);
                    lab.Dock = DockStyle.Fill;
                    lab.ImageAlign = ContentAlignment.MiddleLeft;
                    lab.TextAlign = ContentAlignment.MiddleLeft;

                    p.Tag = i;
                    lab.Tag = i;
                    lab.DoubleClick += (sender, e) =>
                    {
                        EditSchedule view = new EditSchedule(currentDay, ExtendApplicationContext.Current.LoginUser.LOGIN_NAME);
                        view.Edit(list[(int)(sender as Control).Tag]);
                        DialogHostFormPC pc = new DialogHostFormPC("编辑事项", view.Width, view.Height);
                        pc.Child = view;
                        pc.ShowDialog();
                        SetDay(now, today, list);
                    };
                }
                p.BringToFront();

                if (list != null && i < list.Count)
                {
                    var tmp = list[i];
                    if (tmp.STATE == 0)
                    {
                        p.BorderColor = UN_FINISHED_COLOR;
                        p.BackColor = UN_FINISHED_COLOR;
                        lab.Image = Resources.unfinished;
                    }
                    else
                    {
                        p.BorderColor = FINISHED_COLOR;
                        p.BorderColor = FINISHED_COLOR;
                        p.BackColor = FINISHED_COLOR;
                        lab.Image = Resources.finished;
                    }
                    lab.Text = string.Format("    {0} {1}", tmp.CREATE_DATE.Value.ToString("HH:mm"), tmp.CONTENT);
                }
                else
                {
                    p.Visible = false;
                }
            }
        }

        List<PanelBorder> panelTmpList = new List<PanelBorder>();

        public Action DayViewClicked { get; set; }

        public void SetDoubleClick(Control cc)
        {
            cc.DoubleClick += cc_DoubleClick;
            if (cc.HasChildren && cc != panelNoFlash2)
            {
                foreach (Control c in cc.Controls)
                {
                    SetDoubleClick(c);
                }
            }
        }

        void cc_DoubleClick(object sender, EventArgs e)
        {
            if (DayViewClicked != null)
                DayViewClicked();
        }

    }


}
