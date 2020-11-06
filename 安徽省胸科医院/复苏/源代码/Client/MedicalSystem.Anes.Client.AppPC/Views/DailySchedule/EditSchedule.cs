using System;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC.Views.DailySchedule
{
    public partial class EditSchedule : UserControl
    {
        DailyScheduleRepository dailyScheduleRepository = new DailyScheduleRepository();


        DateTime _currentDay;
        string _loginName;
        bool isEditMode = false;

        protected EditSchedule()
        {
            InitializeComponent();
        }

        public EditSchedule(DateTime currentDay, string loginName)
            : this()
        {
            _currentDay = currentDay;
            _loginName = loginName;
        }

        MedicalSystem.Anes.Domain.MED_DAILY_SCHEDULE editItem = null;

        public void Edit(MedicalSystem.Anes.Domain.MED_DAILY_SCHEDULE item)
        {
            editItem = item;
            isEditMode = true;

            labDAILYNO.Text = item.DAILY_NO.ToString();

            if (rbtnTYPE0.Text == item.SCHEDULE_TYPE)
            {
                rbtnTYPE0.Checked = true;
            }
            else
            {
                rbtnTYPE1.Checked = true;
            }

            if (item.STATE == 0)
            {
                rbtnSTATE0.Checked = true;
            }
            else
            {
                rbtnSTATE1.Checked = true;
            }

            txtCONTENT.Text = item.CONTENT;

        }

        private void buttonBorder1_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (!isEditMode)
            {
                editItem = new Domain.MED_DAILY_SCHEDULE()
                {
                    DAILY_DAY = _currentDay,
                    DAILY_USER = _loginName,
                    DAILY_NO = 1,
                    SCHEDULE_TYPE = this.rbtnTYPE0.Checked ? this.rbtnTYPE0.Text : this.rbtnTYPE1.Text,
                    CONTENT = this.txtCONTENT.Text.Trim(),
                    STATE = this.rbtnSTATE0.Checked ? 0 : 1,
                    CREATE_DATE = DateTime.Now,
                    UPDATE_DATE = DateTime.Now
                };
                flag = dailyScheduleRepository.Add(editItem).Data;
            }
            else
            {
                editItem.SCHEDULE_TYPE = this.rbtnTYPE0.Checked ? this.rbtnTYPE0.Text : this.rbtnTYPE1.Text;
                editItem.CONTENT = this.txtCONTENT.Text.Trim();
                editItem.STATE = this.rbtnSTATE0.Checked ? 0 : 1;
                flag = dailyScheduleRepository.Update(editItem).Data;
            }

            if (flag)
            {
                MessageBoxFormPC.Show("保存成功。");
                if (this.ParentForm != null)
                {
                    this.ParentForm.Close();
                }
            }
            else
            {
                MessageBoxFormPC.Show("保存失败。");
            }
        }

    }
}
