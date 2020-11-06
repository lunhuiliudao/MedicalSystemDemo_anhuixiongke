using System;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class TimeInPutFrmPC : DialogHostFormPC
    {
        AccountRepository accountRepository = new AccountRepository();

        public TimeInPutFrmPC()
        {
            InitializeComponent();
            SelectedDateTime = accountRepository.GetServerTime().Data;
            //this.HeaderIcon = HeaderIconEnumPC.Time;
            timeControl.StrMemo = string.Empty;
        }

        public DateTime SelectedDateTime
        {
            get { return timeControl.DateTimes; }
            set { timeControl.DateTimes = value; }
        }

        public override bool RegisterControlByHotKey(string keyCode)
        {
          //  this.InputMethods.InputType = InputMethodType.InputType.NO;
            return base.RegisterControlByHotKey(keyCode);
        }

        private void buttonColorClose_BtnClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonColorOK_BtnClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TimeInPutFrmPC_Load(object sender, EventArgs e)
        {
            timeControl.SetFocus();
        }

        private void timeControl_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
