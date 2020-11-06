using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MedicalSystem.MedScreen.Network;
using MedicalSystem.AnesIcuQuery.Network;

namespace MedicalSystem.MedScreen.Client.ScreenConfig
{
    public partial class ConfigLoginFrm : DevExpress.XtraEditors.XtraForm
    {
        #region 构造函数
        public ConfigLoginFrm()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }
        #endregion

        #region 事件
        private void ConfigLoginFrm_Load(object sender, EventArgs e)
        {
            txtPwd.Focus();
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(13))
            {
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!TestNet)
            {
                return;
            }
            string loginName = txtUserName.Text.Trim().ToUpper();
            string loginPassWord = txtPwd.Text.Trim().ToUpper();
            bool isLogin = false;

            try
            {
                isLogin = Login(loginName, loginPassWord);

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            if (isLogin)
            {

                //成功返回
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult dialogResult = XtraMessageBox.Show("您输入的密码或用户名有误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPwd.Focus();
                this.DialogResult = DialogResult.None;
            }

            this.Cursor = Cursors.Default;

        }
        #endregion

        #region 方法
        /// <summary>
        /// 校验用户登录
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="password">用户密码</param>
        /// <returns>true 合法用户 false 非法用户</returns>
        public static bool Login(string loginName, string password)
        {
            bool result = true;
            try
            {
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return result;
        }

        #endregion

        #region 测试网络

        /// <summary>
        /// 测试网络
        /// </summary>
        protected bool TestNet
        {
            get
            {
                try
                {
                    return DataOperator.HttpWebApi<bool>(ApiUrlEnum.TestNet, null);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                    return false;
                }
            }
        }

        #endregion
    }
}