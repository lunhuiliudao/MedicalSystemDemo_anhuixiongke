using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class UserMsgView : BaseControl
    {
        MED_USERS loginUser = ExtendApplicationContext.Current.LoginUser;
        List<MED_USERS> userList = null;
        List<MED_DEPT_DICT> deptList = null;
        public UserMsgView()
        {
            InitializeComponent();
        }

        private void UserMsgView_Load(object sender, EventArgs e)
        {
            this.comboBoxReciverType.Properties.Items.Clear();
            this.comboBoxReciverType.Properties.Items.Add("人员");
            this.comboBoxReciverType.Properties.Items.Add("科室");
           // this.comboBoxReciverType.Properties.Items.Add("角色");
           // this.comboBoxReciverType.SelectedText = "人员";
            //this.comboBoxReciverType.Properties.ReadOnly = true;
            if (userList == null)
            {
                userList = new UserRepository().GetUserList().Data;
            }
            if (deptList == null)
            {
                deptList = ExtendApplicationContext.Current.CommDict.DeptDict;
            }
            if (userList != null)
            {
                this.comboBoxReciver.Properties.Items.Clear();
                userList.ForEach(user =>
                {
                    this.comboBoxReciver.Properties.Items.Add(user.USER_NAME);
                });
            }
        }

        private void comboBoxReciverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxReciverType.SelectedText)
            {
                case "人员":
                    {
                        if (userList == null)
                        {
                            userList = new UserRepository().GetUserList().Data;
                        }
                        if (userList != null)
                        {
                            this.comboBoxReciver.Properties.Items.Clear();
                            userList.ForEach(user =>
                            {
                                this.comboBoxReciver.Properties.Items.Add(user.USER_NAME);
                            });
                        }
                        this.comboBoxReciver.SelectedText = "";
                    }
                    break;
                case "科室":
                    {
                        this.comboBoxReciver.Properties.Items.Clear();
                        if (deptList != null) { 
                            deptList.ForEach(dept =>
                            {
                                this.comboBoxReciver.Properties.Items.Add(dept.DEPT_NAME);
                            });
                        }
                        this.comboBoxReciver.SelectedText = "";
                    }
                    break;
                case "角色":
                    {
                        this.comboBoxReciver.Properties.Items.Clear();
                        this.comboBoxReciver.SelectedText = "";
                    }
                    break;
            }
        }

        private void rTbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendMsg();
            }
        }

        private void SendMsg()
        {
            MED_USER_MESSAGES msg = new MED_USER_MESSAGES();
            switch (comboBoxReciverType.SelectedText)
            {
                case "人员":
                    {
                        if (this.comboBoxReciver.SelectedIndex >= 0)
                        {
                            msg.RECEIVE_USER_ID = userList[this.comboBoxReciver.SelectedIndex].USER_ID;
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case "科室":
                    {
                        if (this.comboBoxReciver.SelectedIndex >= 0)
                        {
                            msg.RECEIVE_DEPT_CODE = deptList[this.comboBoxReciver.SelectedIndex].DEPT_CODE;
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case "角色":
                    {
                        if (this.comboBoxReciver.SelectedIndex >= 0)
                        {
                            msg.RECEIVE_ROLE_ID = "";
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
            }
            msg.SEND_USER_ID = loginUser.USER_JOB_ID;
            msg.MEMO = rTbMessage.Text.Trim();

            bool flag = new UserRepository().SaveUserMessage(msg).Data;

            if (flag)
            {
                btnClose_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            SendMsg();
        }
    }
}
