using System;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Common.SecretManage;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PwdChangeControl : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        UserRepository userRepository = new UserRepository();

        public PwdChangeControl()
        {
            InitializeComponent();
            Caption = "修改密码";
        }
        /// <summary>
        /// Shift键按下
        /// </summary>
        private bool _shiftDown = false;

        private string _userID = ExtendApplicationContext.Current.LoginUser.LOGIN_NAME;
        private void btnCommit_BtnClicked(object sender, EventArgs e)
        {
            MED_USERS user = accountRepository.Login(_userID, txtPassWord.Value.Trim()).Data;

            if (user != null)
            {
                if (txtNewPWD.Value.Trim() != "" && txtNewPWDtoo.Value.Trim() != "")
                {
                    if (txtNewPWD.Value.Trim() == txtNewPWDtoo.Value.Trim())
                    {
                        user.LOGIN_PWD = SecretHelper.GetMd5To32Str(txtNewPWD.Value.Trim());
                        if (userRepository.SaveUser(user).Data > 0)
                        {
                            ExtendApplicationContext.Current.LoginUser.LOGIN_PWD = SecretHelper.GetMd5To32Str(txtNewPWD.Value.Trim());
                            MessageBoxFormPC.Show("密码修改成功", MessageBoxIcon.Asterisk);

                            ParentForm.DialogResult = DialogResult.OK;
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

        private void btnColse_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void PwdChangeControl_KeyUp(object sender, KeyEventArgs e)
        {
            _shiftDown = false;
        }

        private void PwdChangeControl_KeyDown(object sender, KeyEventArgs e)
        {
            _shiftDown = e.Shift;
        }

        private void txtPassWord_ValueKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                this.txtNewPWDtoo.Select();
                txtNewPWDtoo.SelectAll();
            }
        }

        private void txtNewPWDtoo_ValueKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                this.txtNewPWD.Select();
                txtNewPWD.SelectAll();
            }
        }

        private void txtNewPWD_ValueKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCommit_BtnClicked(sender, null);
            }
        }
    }
}
