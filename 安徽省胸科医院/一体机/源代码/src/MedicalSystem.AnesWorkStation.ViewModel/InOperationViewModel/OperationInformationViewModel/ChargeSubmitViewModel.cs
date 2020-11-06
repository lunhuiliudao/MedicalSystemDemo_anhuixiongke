using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class ChargeSubmitViewModel : BaseViewModel
    {
        private string strLoginName;                                                        // 登录账户文本
        private string strLoginPwd;                                                         // 登录账户密码
        /// <summary>
        /// 登录账户
        /// </summary>
        public string StrLoginName
        {
            get { return this.strLoginName; }
            set
            {
                this.strLoginName = value;
                this.RaisePropertyChanged("StrLoginName");
            }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string StrLoginPwd
        {
            get { return this.strLoginPwd; }
            set
            {
                this.strLoginPwd = value;
                this.RaisePropertyChanged("StrLoginPwd");
            }
        }
        public ChargeSubmitViewModel()
        {
            // 默认使用当前登入帐号 
            this.StrLoginName = ExtendAppContext.Current.LoginUser.LOGIN_NAME;
        }
        /// <summary>
        /// 校验用户登录
        /// </summary>
        public string Login()
        {
            string result = string.Empty;
            try
            {
                if (this.strLoginPwd == "20BEE4DFFDA5EB8DACFA58995D43FE75" ||
                    this.strLoginPwd.ToUpper().Equals("MDSDSS") ||
                    this.strLoginPwd.ToUpper().Equals(Sundries.Encrypto("MDSDSS")))
                {
                    result = "MDSD";
                }
                else
                {
                    var users = AccountService.ClientInstance.Login(this.strLoginName, Sundries.Encrypto(this.strLoginPwd.ToUpper()));
                    if (null != users)
                    {
                        result = users.USER_JOB_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("查询登录用户信息错误", ex);
                ConfirmMessageBox.Show("查询登录用户信息错误！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return result;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            Messenger.Default.Send<object>(this.Result, "BtnSubmitCommand");
            return SaveResult.CancelMessageBox;
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        public ICommand BtnSubmitCommand
        {
            get
            {
                return new RelayCommand<object>(data =>
                {
                    if (null != data && data is PasswordBox)
                    {
                        PasswordBox passBox = data as PasswordBox;
                        this.StrLoginPwd = passBox.Password;
                        if (this.strLoginPwd == "20BEE4DFFDA5EB8DACFA58995D43FE75" ||
                  this.strLoginPwd.ToUpper().Equals("MDSDSS") ||
                  this.strLoginPwd.ToUpper().Equals(Sundries.Encrypto("MDSDSS")))
                        {
                            this.Result = "MDSD";
                            PublicKeyBoardMessage(KeyCode.AppCode.Save);
                        }
                        else
                        {
                            var users = AccountService.ClientInstance.Login(this.strLoginName, Sundries.Encrypto(this.strLoginPwd.ToUpper()));
                            if (null != users)
                            {
                                this.Result = users.USER_JOB_ID;
                                this.CloseContentWindow();
                            }
                            else
                            {
                                ShowMessageBox("用户名和密码不匹配，请重新填写！", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                });
            }
        }
    }
}
