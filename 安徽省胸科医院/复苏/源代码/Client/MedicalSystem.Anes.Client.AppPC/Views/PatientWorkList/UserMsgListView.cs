using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class UserMsgListView : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        MED_USERS loginUser = ExtendApplicationContext.Current.LoginUser;
        List<MED_USERS> userList = null;
        List<MED_DEPT_DICT> deptList = null;
        List<MED_RESCUE_MESSAGE_LOG> messageList = null;
        public UserMsgListView()
        {
            InitializeComponent();
            Caption = "消息浏览";
            dgControlMAIL.AutoGenerateColumns = false;
            dateEditStart.DateTime = accountRepository.GetServerTime().Data;
        }
        public void UserMsgLoad()
        {
            //messageList = RescueService.GetRescueMessageList();
            //Expression<Func<MED_RESCUE_MESSAGE_LOG, bool>> expression = p => true;
            //if (!loginUser.isMDSD)
            //    expression = expression.And(p => p.EXPERT_ID == loginUser.USER_JOB_ID);

            //if (check.Checked)
            //{
            //    expression = expression.And(p => p.RECEIVE_CONFIRM == 1);
            //}

            //if (dateEditStart.DateTime != DateTime.MinValue && dateEditStart.DateTime != DateTime.MaxValue)
            //{
            //    expression = expression.And(p => p.SEND_TIME.ToString("yyyy-MM-dd") == dateEditStart.DateTime.ToString("yyyy-MM-dd"));
            //}

            //messageList = messageList.Where(expression.Compile()).ToList();

            //if (messageList != null && messageList.Count > 0)
            //{
            //    foreach (MED_RESCUE_MESSAGE_LOG message in messageList)
            //    {
            //        if (message.RECEIVE_CONFIRM == 1) message.ISCHECKED = true;
            //        message.SEND_USER_NAME = BindControls("MED_HIS_USERS", message.SEND_USER_ID);
            //    }
            //}
            //dgControlMAIL.DataSource = messageList;
        }
        public void SaveUserMsg()
        {
            if (messageList != null && messageList.Count > 0)
            {
                foreach (MED_RESCUE_MESSAGE_LOG message in messageList)
                {
                    if (message.ISCHECKED) message.RECEIVE_CONFIRM = 1;
                }
                //RescueService.SaveRescueMessageList(messageList);
            }
        }
        private void UserMsgListView_Load(object sender, EventArgs e)
        {
            this.SetDefaultGridViewStyle(dgControlMAIL);
            UserMsgLoad();
        }

        public string BindControls(string bindTable, string code)
        {
            string value = code;
            if (bindTable.ToUpper().Equals("MED_DEPT_DICT"))
            {
                List<MED_DEPT_DICT> deptList = ExtendApplicationContext.Current.CommDict.DeptDict;
                foreach (MED_DEPT_DICT dept in deptList)
                {
                    if (dept.DEPT_CODE == code) { value = dept.DEPT_NAME; break; }
                }
            }
            else if (bindTable.ToUpper().Equals("MED_HIS_USERS"))
            {
                List<MED_HIS_USERS> hisUserList = ExtendApplicationContext.Current.CommDict.HisUsersDict;
                foreach (MED_HIS_USERS user in hisUserList)
                {
                    if (user.USER_JOB_ID == code) { value = user.USER_NAME; break; }
                }
            }
            return value;
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            SaveUserMsg();
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void dgControlMAIL_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgControlMAIL.IsCurrentCellDirty) //有未提交的更//改
            {
                this.dgControlMAIL.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void radioButtonCheck_CheckedChanged(object sender, EventArgs e)
        {
            SaveUserMsg();
            UserMsgLoad();
        }

        private void dateEditStart_EditValueChanged(object sender, EventArgs e)
        {
            SaveUserMsg();
            UserMsgLoad();
        }
    }
}
