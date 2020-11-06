using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.AnesWorkStationCoordination.Model;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ScreenInfoNotice : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        CommonRepository commonRepository = new CommonRepository();

        public ScreenInfoNotice()
        {
            InitializeComponent();
        }

        private void ScreenInfoNotice_Load(object sender, EventArgs e)
        {
            if (ExtendApplicationContext.Current.PatientContextExtend != null)
            {
                lbMsgHeader.Text = TransDeptCode(ExtendApplicationContext.Current.PatientInformationExtend.DEPT_CODE) + "，" + ExtendApplicationContext.Current.PatientInformationExtend.NAME + "的家属";
            }
            else
            {
                lbMsgHeader.Text = "患者家属";
            }
            dgvMsg.AutoGenerateColumns = false;
            this.SetDefaultGridViewStyle(dgvMsg);
            txtNoticeContext_TextChanged(null, null);

            ShowMsgGrid();
        }

        private void txtNoticeContext_TextChanged(object sender, EventArgs e)
        {
            if (chkPreMsg.Checked)
                lbMsg.Text = lbMsgHeader.Text + "，" + txtNoticeContext.Text;
            else
                lbMsg.Text = txtNoticeContext.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoticeContext.Text))
            {
                string id = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID + " " + accountRepository.GetServerTime().Data.Ticks;
                MED_SCREEN_MSG msg = new MED_SCREEN_MSG();
                msg.ID = id;
                msg.MSG = lbMsg.Text;
                msg.INSERT_TIME = accountRepository.GetServerTime().Data;
                msg.COUNTS = int.Parse(numUDNoticeTime.Value.ToString());
                msg.STATUS = 1;
                msg.USER_ID = "紧急公告";
                msg.TYPE = 2;
                msg.DEPT_CODE = ExtendApplicationContext.Current.OperRoom;
                commonRepository.SaveScreenMsg(msg);

                string msgStr = msg.ID + "@" + msg.MSG + "@" + msg.COUNTS;

                TransMessageModel tempTransMsgModel = new TransMessageModel(EnumAppType.Screen,
                                                                           EnumMessageType.Broadcase,
                                                                           EnumFunctionType.OperationScreen,
                                                                           msgStr
                                                                           );
                TransMessageManager.Instance.SendMsg(tempTransMsgModel);
            }
            ShowMsgGrid();
        }

        private void ShowMsgGrid()
        {
            List<MED_SCREEN_MSG> dt = commonRepository.GetScreenMsgList().Data;
            dgvMsg.DataSource = dt;
        }
        private string TransDeptCode(string code)
        {
            string deptName = code;
            foreach (MED_DEPT_DICT row in ExtendApplicationContext.Current.CommDict.DeptDict)
            {
                if (row.DEPT_CODE.Equals(code))
                {
                    deptName = row.DEPT_NAME;
                }
            }
            return deptName;
        }
        private void chkPreMsg_CheckedChanged(object sender, EventArgs e)
        {
            lbMsgHeader.Visible = chkPreMsg.Checked;
            txtNoticeContext_TextChanged(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowMsgGrid();
        }
    }
}
