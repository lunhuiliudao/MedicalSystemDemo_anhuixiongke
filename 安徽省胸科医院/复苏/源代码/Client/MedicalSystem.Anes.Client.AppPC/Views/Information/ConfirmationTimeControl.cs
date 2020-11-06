using System;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ConfirmationTimeControl : UserControl
    {
        AccountRepository accountRepository = new AccountRepository();

        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _statusName;
        private BaseDoc baseDoc = null;
        public DialogResult result = DialogResult.Cancel;
        public DateTime statusTime = DateTime.MinValue;
        public ConfirmationTimeControl()
        {
            InitializeComponent();
            _patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            _visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            _operID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
        }
        public ConfirmationTimeControl(string statusName, DateTime statusTime)
            : this()
        {
            _statusName = statusName;
            if (statusTime != DateTime.MinValue && statusTime != DateTime.MaxValue)
            {
                timeControl.DateTimes = statusTime;
            }
            else
            {
                timeControl.DateTimes = accountRepository.GetServerTime().Data;
            }
            lblSecond.Text = "第二步." + statusName + "时间确认";
            confirmationLoad();

        }
        public void confirmationLoad()
        {
            ShowFormByDocName(_patientID, _visitID, _operID, "安全核查表");

        }
        public void ShowFormByDocName(object patientId, object visitId, object operId, string docName)
        {
            panelSafetyDoc.Controls.Clear();
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);
            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                return;
            }
            try
            {
                Type t = Type.GetType(document.Type);
                baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.statusReadOnly = _statusName;
                baseDoc.isShowButton = false;
                if (patientId != null)
                {
                    object[] objs = new object[3];
                    objs[0] = patientId;
                    objs[1] = visitId;
                    objs[2] = operId;
                    baseDoc.SetDocParameters(objs);
                }
                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                baseDoc.AutoScroll = false;
                baseDoc.Height = 1200;
                panelSafetyDoc.Controls.Add(baseDoc);
                // baseDoc.Dock = DockStyle.Fill;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnNext_BtnClicked(object sender, EventArgs e)
        {
            panelSafetyDoc.Visible = false;
            panelInTimeControl.Visible = true;
            if (btnNext.Title.Equals("确认"))
            {
                if (baseDoc != null)
                    baseDoc.Save();
                statusTime = timeControl.DateTimes;
                result = DialogResult.OK;
                ParentForm.DialogResult = DialogResult.OK;
            }
            btnNext.Title = "确认";
            btnUp.Visible = true;
            lblFirst.Image = Resources.进程1_3;
            lblSecond.Image = Resources.进程2_3;
        }

        private void btnUp_BtnClicked(object sender, EventArgs e)
        {
            panelSafetyDoc.Visible = true;
            panelInTimeControl.Visible = false;
            btnUp.Visible = false;
            btnNext.Title = "上一步";
            lblFirst.Image = Resources.进程1_2;
            lblSecond.Image = Resources.进程2_0;
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }
    }
}
