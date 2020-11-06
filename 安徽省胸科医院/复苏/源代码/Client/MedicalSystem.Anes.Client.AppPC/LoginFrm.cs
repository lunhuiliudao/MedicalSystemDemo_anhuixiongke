using System;
using System.ComponentModel;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Common.SecretManage;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class LoginFrm : BaseForm
    {
        AccountRepository accountRepository = new AccountRepository();

        UserRepository userRepository = new UserRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        private bool IsCheck = false;
        public LoginFrm(string[] args)
        {
            InitializeComponent();
        }
        public LoginFrm()
            : this(null)
        {
        }
        public LoginFrm(bool isCheck)
            : this(null)
        {
            IsCheck = isCheck;
        }
        private void LoginFrm_Load(object sender, EventArgs e)
        {
            this.label1.Text = "版权所有@2005-" + accountRepository.GetServerTime().Data.Year + " 麦迪斯顿 Copyright Reserved 2005-2018 Medicalsystem Co.,Ltd.";

            if (ExtendApplicationContext.Current.LoginUser == null
                || string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUser.LOGIN_NAME))
            {
                txtLoginName.Value = ConfigurationHelper.Read("LoginName");
            }
            else
            {
                txtLoginName.Value = ExtendApplicationContext.Current.LoginUser.LOGIN_NAME;
            }
            InitTaskList();
            if (string.IsNullOrWhiteSpace(txtLoginName.Value))
            {
                txtLoginName.Select();
                txtLoginName.SelectAll();
            }
            else
            {
                txtLoginPwd.Select();
                txtLoginPwd.SelectAll();
            }
            DialogResult = System.Windows.Forms.DialogResult.None;

            if (ScreenLocker.lockState)
                txtLoginName.Focus();

            new ControlAddEvent(Resources.login最小化_1, Resources.login最小化_2, Resources.login最小化_3).AddMouseMove(panelMin);
            new ControlAddEvent(Resources.login_x1, Resources.login_x2, Resources.login_x3).AddMouseMove(panelClose);
            new ControlAddEvent(Resources.login_登录1, Resources.login_登录2, Resources.logi_登录3).AddMouseMove(panelOK);

        }

        /// <summary>
        /// 登录
        /// </summary>
        private void Login()
        {
            if (string.IsNullOrEmpty(txtLoginName.Value))
            {
                labelMsg.Text = "用户名不能为空，请重新输入。";
                txtLoginName.Focus();
                txtLoginName.SelectAll();
                return;
            }
            else if (string.IsNullOrEmpty(txtLoginPwd.Value))
            {
                labelMsg.Text = "密码不能为空，请重新输入。";
                txtLoginPwd.Focus();
                txtLoginPwd.SelectAll();
                return;
            }

            if (ScreenLocker.lockState == true)   // 锁屏和切换用户的情况
            {
                IsChangeUser = false;
                if (ExtendApplicationContext.Current.LoginUser == null) // 切换用户的情况
                {

                    NewUserLogin();
                }
                else         // 锁屏的情况
                {
                    if (txtLoginName.Value == ExtendApplicationContext.Current.LoginUser.LOGIN_NAME             // 当前用户解锁
                        && SecretHelper.GetMd5To32Str(txtLoginPwd.Value.Trim()) == ExtendApplicationContext.Current.LoginUser.LOGIN_PWD)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        NewUserLogin();           // 新用户登录
                    }
                }
            }
            else
            {
                var user = accountRepository.Login(txtLoginName.Value, txtLoginPwd.Value).Data;
                if (user != null)
                {
                    ExtendApplicationContext.Current.LoginUser = user;
                    ExtendApplicationContext.Current.LoginName = user.LOGIN_NAME;
                    user.RUN_MODE = Convert.ToInt32(ApplicationConfiguration.ApplicationPatterns);
                    if (ApplicationConfiguration.ApplicationPatterns == "1")
                    {
                        user.RUN_ADDRESS = "办公室";
                    }
                    else
                    {
                        if (ApplicationConfiguration.IsPACUProgram)
                        {
                            user.RUN_ADDRESS = "恢复室";
                        }
                        else
                            user.RUN_ADDRESS = ExtendApplicationContext.Current.OperRoomNo;
                    }
                    userRepository.SaveUser(user);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    labelMsg.Text = "用户名或者密码错误,请重新输入。";
                    txtLoginPwd.Focus();
                    txtLoginPwd.SelectAll();
                }
            }
        }

        /// <summary>
        /// 新用户登录情况
        /// </summary>
        private void NewUserLogin()
        {
            var user = accountRepository.Login(txtLoginName.Value, txtLoginPwd.Value).Data;
            if (user != null)
            {
                ExtendApplicationContext.Current.LoginUser = user;
                user.RUN_MODE = Convert.ToInt32(ApplicationConfiguration.ApplicationPatterns);
                if (ApplicationConfiguration.ApplicationPatterns == "1")
                {
                    user.RUN_ADDRESS = "办公室";
                }
                else
                {
                    if (ApplicationConfiguration.IsPACUProgram)
                    {
                        user.RUN_ADDRESS = "恢复室";
                    }
                    else
                        user.RUN_ADDRESS = ExtendApplicationContext.Current.OperRoomNo;
                }
                userRepository.SaveUser(user);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();
                IsChangeUser = true;
            }
            else
            {
                txtLoginPwd.Focus();
                txtLoginPwd.SelectAll();
                labelMsg.Text = "用户名或者密码错误,请重新输入。";
            }
        }

        /// <summary>
        /// 锁屏时，是否切换用户
        /// </summary>
        public static bool IsChangeUser = false;

        private void txtLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                this.txtLoginPwd.Select();
                txtLoginPwd.SelectAll();
            }
        }

        private void txtLoginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.txtLoginName.Select();
                txtLoginName.SelectAll();
            }
        }


        private void panelOK_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void panelMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelClose_Click(object sender, EventArgs e)
        {
            if (IsCheck)
            {
                if (MessageBoxFormPC.Show("是否要退出系统?",
                                   "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Application.Exit();
                    }
                    catch
                    {
                        System.Environment.Exit(0);
                    }
                    return;
                }
            }
            else
                this.Close();
        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            labelMsg.Text = string.Empty;
        }
        private void InitTaskList()
        {
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate (object sender, DoWorkEventArgs e)
                {
                    if (null == ExtendApplicationContext.Current.CommDict.EventDict)
                    {
                        ExtendApplicationContext.Current.CommDict.EventDict = comnDictRepository.GetEventDictList().Data;
                    }
                    if (null == ExtendApplicationContext.Current.CommDict.UnitDictExt)
                    {
                        ExtendApplicationContext.Current.CommDict.UnitDictExt = comnDictRepository.GetUnitDictList().Data;
                    }
                    if (ExtendApplicationContext.Current.CommDict.AdministrationDictExt == null)
                        ExtendApplicationContext.Current.CommDict.AdministrationDictExt = comnDictRepository.GetAdminstrationDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.HisUsersDict == null)
                        ExtendApplicationContext.Current.CommDict.HisUsersDict = comnDictRepository.GetHisUsersList().Data;

                    if (ExtendApplicationContext.Current.CommDict.DeptDict == null)
                        ExtendApplicationContext.Current.CommDict.DeptDict = comnDictRepository.GetDeptDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.OperationRoomDict == null)
                        ExtendApplicationContext.Current.CommDict.OperationRoomDict = comnDictRepository.GetAllOperatingRoomList().Data;

                    if (ExtendApplicationContext.Current.CommDict.AnesInputDictDict == null)
                        ExtendApplicationContext.Current.CommDict.AnesInputDictDict = comnDictRepository.GetAnesInputDictList(null).Data;

                    if (ExtendApplicationContext.Current.CommDict.BloodGasDict == null)
                        ExtendApplicationContext.Current.CommDict.BloodGasDict = comnDictRepository.GetBloodGasDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.WardDict == null)
                        ExtendApplicationContext.Current.CommDict.WardDict = comnDictRepository.GetWardDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.EventDictExt == null)
                        ExtendApplicationContext.Current.CommDict.EventDictExt = comnDictRepository.GetAnesEventDictExt().Data;

                    if (ExtendApplicationContext.Current.CommDict.ConfigDict == null)
                        ExtendApplicationContext.Current.CommDict.ConfigDict = comnDictRepository.GetConfig().Data;

                    if (ExtendApplicationContext.Current.CommDict.HosotalConfigDict == null)
                        ExtendApplicationContext.Current.CommDict.HosotalConfigDict = comnDictRepository.GetHosotalConfig().Data;

                    if (ExtendApplicationContext.Current.CommDict.AnesMethodDict == null)
                        ExtendApplicationContext.Current.CommDict.AnesMethodDict = comnDictRepository.GetAnesMethodDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.DiagnosisDict == null)
                        ExtendApplicationContext.Current.CommDict.DiagnosisDict = comnDictRepository.GetDiagDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.OperationNameDict == null)
                        ExtendApplicationContext.Current.CommDict.OperationNameDict = comnDictRepository.GetOperNameDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.MonitorDict == null)
                        ExtendApplicationContext.Current.CommDict.MonitorDict = comnDictRepository.GetMonitorDictList().Data;

                    if (ExtendApplicationContext.Current.CommDict.MonitorFuntionDict == null)
                        ExtendApplicationContext.Current.CommDict.MonitorFuntionDict = comnDictRepository.GetMonitorFuctionCodeList().Data;
                };
                worker.RunWorkerAsync();
            };
        }
    }
}
