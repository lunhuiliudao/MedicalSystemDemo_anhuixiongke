using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Service;
using MedicalSystem.Anes.Core.Security;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PwdChangeFrm : Form
    {
        public PwdChangeFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Shift键按下
        /// </summary>
        private bool _shiftDown = false;

        private string _userID = ExtendApplicationContext.Current.LoginUser.LOGIN_NAME;
        private void btnOk_Click(object sender, EventArgs e)
        {
            MED_USERS user = AccountService.Login(_userID, txtPassWord.Text.Trim());

            if (user != null)
            {
                if (txtNewPWD.Text.Trim() != "" && txtNewPWDtoo.Text.Trim() != "")
                {
                    if (txtNewPWD.Text.Trim() == txtNewPWDtoo.Text.Trim())
                    {
                        user.LOGIN_PWD = MD5Encrypt.GetMd5To32Str(txtNewPWD.Text.Trim());
                        if (UserService.SaveUser(user))
                        {
                            ExtendApplicationContext.Current.LoginUser.LOGIN_PWD = MD5Encrypt.GetMd5To32Str(txtNewPWD.Text.Trim());
                            MessageBoxFormPC.Show("密码修改成功", MessageBoxIcon.Asterisk);
                        }

                    }
                    else
                    {
                        MessageBoxFormPC.Show("确认新密码错误", MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBoxFormPC.Show("新密码不能为空", MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBoxFormPC.Show("旧密码输入错误！", MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PwdChangeFrm_KeyUp(object sender, KeyEventArgs e)
        {
            _shiftDown = false;
        }

        private void PwdChangeFrm_KeyDown(object sender, KeyEventArgs e)
        {
            _shiftDown = e.Shift;
        }
    }
}
