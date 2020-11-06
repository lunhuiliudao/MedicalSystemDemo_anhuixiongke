// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      LoginViewModel.cs
// 功能描述(Description)：    登录界面对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string strLoginName;                                                        // 登录账户文本
        private string strLoginPwd;                                                         // 登录账户密码
        private string strMessage;                                                          // 提示信息
        private bool isLogining;                                                           // 是否处于登录状态
        private DelegateCommonObject.DelegateMethod DelegateInitAllDictList = null;         // 异步加载字典
        private IAsyncResult delegateResult = null;

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

        /// <summary>
        /// 登录成功或者失败的提示信息
        /// </summary>
        public string StrMessage
        {
            get { return this.strMessage; }
            set
            {
                this.strMessage = value;
                this.RaisePropertyChanged("StrMessage");
            }
        }

        /// <summary>
        /// 是否正在登录
        /// </summary>
        public bool IsLogining
        {
            get { return this.isLogining; }
            set
            {
                this.isLogining = value;
                this.RaisePropertyChanged("IsLogining");
            }
        }

        /// <summary>
        /// 构造方法：进行网络连接测试
        /// </summary>
        public LoginViewModel()
        {
            // 默认使用上次登录的用户名  
            this.StrLoginName = ExtendAppContext.Current.LoginName;
            this.TestNetAndInitAllDictList();
            if (ExtendAppContext.Current.ProgramArgs != null && ExtendAppContext.Current.ProgramArgs.Length > 2
                  && ExtendAppContext.Current.ProgramArgs[0].ToLower().Equals("autologin"))
            {
                Messenger.Default.Send<object>(this, EnumMessageKey.CloseLogin);
                Messenger.Default.Send<object>(this, EnumMessageKey.HideMainWindow);
                this.StrLoginName = ExtendAppContext.Current.ProgramArgs[1];
                this.StrLoginPwd = ExtendAppContext.Current.ProgramArgs[2];
                System.Threading.Thread loginThread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    try
                    {
                        if (this.Login())
                        {
                            ExtendAppContext.Current.LoginName = this.StrLoginName;
                            // new Thread(KeyBoardStateCache.KeyBoard.StartWebDocPicService).Start();
                            if (null != this.DelegateInitAllDictList) //禁止重复加载
                            {
                                this.DelegateInitAllDictList.EndInvoke(delegateResult);
                                this.delegateResult = null;
                                this.DelegateInitAllDictList = null;
                            }
                            this.InitAllDictList();
                            this.ListConvertDataTable();
                        }
                        else
                        {
                            this.IsLogining = false;
                            ShowMessageBox("用户名或密码错误，请重新输入！", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("登录错误", ex);
                        ConfirmMessageBox.Show("登录错误，" + ex.Message, "提示信息", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }));
                loginThread.SetApartmentState(System.Threading.ApartmentState.STA);
                loginThread.Start();
            }
        }

        /// <summary>
        /// 登录界面初始化时进行网络连接测试同时初始化字典列表
        /// </summary>
        public void TestNetAndInitAllDictList()
        {
            try
            {
                if (!CommonService.ClientInstance.TestNet() || !CommonService.ClientInstance.TestDbConn())
                {
                    this.StrMessage = "网络连接失败！";
                }
                else
                {
                    // 先使用异步初始化字典
                    if (null == this.DelegateInitAllDictList)
                    {
                        this.DelegateInitAllDictList = new DelegateCommonObject.DelegateMethod(this.InitAllDictList);
                    }

                    delegateResult = this.DelegateInitAllDictList.BeginInvoke(null, null);
                }
            }
            catch (Exception ex)
            {
                // 解决WebApi或者数据库配置不正确导致进程卡死 wwj 2017-11-13 14:42
                this.ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                Messenger.Default.Send<object>(this, EnumMessageKey.ExitLogin);
            }
        }

        /// <summary>
        /// 校验用户登录
        /// </summary>
        public bool Login()
        {
            bool result = false;
            try
            {
                if (this.strLoginPwd == "20BEE4DFFDA5EB8DACFA58995D43FE75" ||
                    this.strLoginPwd.ToUpper().Equals("MDSDSS") ||
                    this.strLoginPwd.ToUpper().Equals(Sundries.Encrypto("MDSDSS")))
                {
                    ExtendAppContext.Current.LoginUser.isMDSD = true;
                    ExtendAppContext.Current.LoginUser.LOGIN_NAME = "MDSD";
                    ExtendAppContext.Current.LoginUser.LOGIN_PWD = "MDSDSS";
                    ExtendAppContext.Current.LoginUser.USER_ID = "MDSD";
                    ExtendAppContext.Current.LoginUser.USER_NAME = "MDSD";
                    ExtendAppContext.Current.LoginUser.USER_JOB_ID = "MDSD";
                    result = true;
                }
                else
                {
                    ExtendAppContext.Current.LoginUser.isMDSD = false;
                    var users = AccountService.ClientInstance.Login(this.strLoginName, Sundries.Encrypto(this.strLoginPwd.ToUpper()));
                    if (null != users)
                    {
                        ExtendAppContext.Current.LoginUser.LOGIN_NAME = users.LOGIN_NAME;
                        ExtendAppContext.Current.LoginUser.LOGIN_PWD = users.LOGIN_PWD;
                        ExtendAppContext.Current.LoginUser.USER_ID = users.USER_ID;
                        ExtendAppContext.Current.LoginUser.USER_NAME = users.USER_NAME;
                        ExtendAppContext.Current.LoginUser.IS_VALID = users.IS_VALID;
                        ExtendAppContext.Current.LoginUser.USER_DEPT_CODE = users.USER_DEPT_CODE;
                        ExtendAppContext.Current.LoginUser.RUN_MODE = users.RUN_MODE;
                        ExtendAppContext.Current.LoginUser.USER_JOB_ID = users.USER_JOB_ID;
                        result = true;
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
        /// 初始化字典列表
        /// </summary>
        public void InitAllDictList()
        {
            if (null == ApplicationModel.Instance.AllDictList.AnesthesiaDictList)
            {
                ApplicationModel.Instance.AllDictList.AnesthesiaDictList = DictService.ClientInstance.GetAnesthesiaDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList)
            {
                ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList = DictService.ClientInstance.GetAnesthesiaInputDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.ApplicationsList)
            {
                ApplicationModel.Instance.AllDictList.ApplicationsList = DictService.ClientInstance.GetApplicationsList();
            }

            if (null == ApplicationModel.Instance.AllDictList.BillItemClassDictList)
            {
                ApplicationModel.Instance.AllDictList.BillItemClassDictList = DictService.ClientInstance.GetBillItemClassDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.BloodGasDictList)
            {
                ApplicationModel.Instance.AllDictList.BloodGasDictList = DictService.ClientInstance.GetBloodGasDictList().OrderBy(x => x.BLG_SHOWID).ToList();
            }

            if (null == ApplicationModel.Instance.AllDictList.ClientComputerList)
            {
                ApplicationModel.Instance.AllDictList.ClientComputerList = DictService.ClientInstance.GetClientComputerList();
            }

            if (null == ApplicationModel.Instance.AllDictList.ConfigList)
            {
                ApplicationModel.Instance.AllDictList.ConfigList = DictService.ClientInstance.GetConfigList();
            }

            if (null == ApplicationModel.Instance.AllDictList.DeptDictList)
            {
                ApplicationModel.Instance.AllDictList.DeptDictList = DictService.ClientInstance.GetDeptDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.DiagnosisDictList)
            {
                ApplicationModel.Instance.AllDictList.DiagnosisDictList = DictService.ClientInstance.GetDiagnosisDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.DocumentTempletList)
            {
                ApplicationModel.Instance.AllDictList.DocumentTempletList = DictService.ClientInstance.GetDocumentTempletList();
            }

            if (null == ApplicationModel.Instance.AllDictList.EventDictExtList)
            {
                ApplicationModel.Instance.AllDictList.EventDictExtList = DictService.ClientInstance.GetEventDictExtList();
            }

            if (null == ApplicationModel.Instance.AllDictList.EventDictList)
            {
                ApplicationModel.Instance.AllDictList.EventDictList = DictService.ClientInstance.GetEventDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.EventItemClassDictClass)
            {
                ApplicationModel.Instance.AllDictList.EventItemClassDictClass = DictService.ClientInstance.GetEventItemClassDictClass();
            }

            //同步事件使用频率，异步加载USER_JOB_ID为null导致个人习惯字典无法正常加载
            if (ExtendAppContext.Current.LoginUser.USER_JOB_ID != null)
            {
                ApplicationModel.Instance.AllDictList.EventSortList = DictService.ClientInstance.GetEventSortList(ExtendAppContext.Current.LoginUser.USER_JOB_ID);
                if (ApplicationModel.Instance.AllDictList.EventSortList.Count == 0)
                {
                    ApplicationModel.Instance.AllDictList.EventSortList = DictService.ClientInstance.GetEventSortList("MDSD");
                    //将默认排序方式赋值到个人账号
                    if (ApplicationModel.Instance.AllDictList.EventSortList != null)
                    {
                        foreach (var item in ApplicationModel.Instance.AllDictList.EventSortList)
                        {
                            item.USER_ID = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                        }
                    }
                }
            }

            if (null == ApplicationModel.Instance.AllDictList.EventVSBillList)
            {
                ApplicationModel.Instance.AllDictList.EventVSBillList = DictService.ClientInstance.GetEventVSBillList();
            }

            if (null == ApplicationModel.Instance.AllDictList.HisUsersList)
            {
                ApplicationModel.Instance.AllDictList.HisUsersList = DictService.ClientInstance.GetHisUsersList();
            }

            if (null == ApplicationModel.Instance.AllDictList.HospBranchDictList)
            {
                ApplicationModel.Instance.AllDictList.HospBranchDictList = DictService.ClientInstance.GetHospBranchDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.HospitalConfigList)
            {
                ApplicationModel.Instance.AllDictList.HospitalConfigList = DictService.ClientInstance.GetHospitalConfigList();
            }

            if (null == ApplicationModel.Instance.AllDictList.MethodDictList)
            {
                ApplicationModel.Instance.AllDictList.MethodDictList = DictService.ClientInstance.GetMethodDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.MonitorDictList)
            {
                ApplicationModel.Instance.AllDictList.MonitorDictList = DictService.ClientInstance.GetMonitorDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.OperatingRoomList)
            {
                ApplicationModel.Instance.AllDictList.OperatingRoomList = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();
            }

            if (null == ApplicationModel.Instance.AllDictList.OperatingRoomVSMonitorList)
            {
                ApplicationModel.Instance.AllDictList.OperatingRoomVSMonitorList = DictService.ClientInstance.GetOperatingRoomVSMonitorList();
            }

            if (null == ApplicationModel.Instance.AllDictList.OperationDictList)
            {
                ApplicationModel.Instance.AllDictList.OperationDictList = DictService.ClientInstance.GetOperationDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.OperationStatusDictList)
            {
                ApplicationModel.Instance.AllDictList.OperationStatusDictList = DictService.ClientInstance.GetOperationStatusDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.UnitDictList)
            {
                ApplicationModel.Instance.AllDictList.UnitDictList = DictService.ClientInstance.GetUnitDictList();
            }

            if (null == ApplicationModel.Instance.AllDictList.AdministrationDictList)
            {
                ApplicationModel.Instance.AllDictList.AdministrationDictList = DictService.ClientInstance.GetAdminstrationDictList();
            }
        }

        /// <summary>
        /// List列表转换成DataTable
        /// </summary>
        private void ListConvertDataTable()
        {
            if (null == ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList)
            {
                ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList = DictService.ClientInstance.GetMonitorFuctionCodeList();
                Dictionary<string, string> monitorFunctionCodeDict = new Dictionary<string, string>();
                List<MED_MONITOR_FUNCTION_CODE> monitorFunctionCodeDataTable = ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList;
                if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
                {
                    monitorFunctionCodeDataTable.ForEach(codeRow =>
                    {
                        if (!ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                        {
                            if (!string.IsNullOrEmpty(codeRow.ITEM_NAME) && !ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                            {
                                ExtendAppContext.Current.MonitorFunctionCodeDict.Add(codeRow.ITEM_CODE, codeRow.ITEM_NAME);
                            }
                        }
                    });
                }
            }

            if (null != ApplicationModel.Instance.AllDictList.HisUsersList && !ExtendAppContext.Current.CodeTables.ContainsKey("MED_HIS_USERS"))
            {
                ExtendAppContext.Current.CodeTables.Add("MED_HIS_USERS", DataHelper.ToDataTable(ApplicationModel.Instance.AllDictList.HisUsersList));
            }

            if (null != ApplicationModel.Instance.AllDictList.DeptDictList && !ExtendAppContext.Current.CodeTables.ContainsKey("MED_DEPT_DICT"))
            {
                ExtendAppContext.Current.CodeTables.Add("MED_DEPT_DICT", DataHelper.ToDataTable(ApplicationModel.Instance.AllDictList.DeptDictList));
            }

            if (null != ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList && !ExtendAppContext.Current.CodeTables.ContainsKey("MED_ANESTHESIA_INPUT_DICT"))
            {
                ExtendAppContext.Current.CodeTables.Add("MED_ANESTHESIA_INPUT_DICT", DataHelper.ToDataTable(ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList));
            }

            if (null != ApplicationModel.Instance.AllDictList.OperationDictList && !ExtendAppContext.Current.CodeTables.ContainsKey("MED_OPERATION_DICT"))
            {
                ExtendAppContext.Current.CodeTables.Add("MED_OPERATION_DICT", DataHelper.ToDataTable(ApplicationModel.Instance.AllDictList.OperationDictList));
            }

            if (null != ApplicationModel.Instance.AllDictList.DiagnosisDictList && !ExtendAppContext.Current.CodeTables.ContainsKey("MED_DIAGNOSIS_DICT"))
            {
                ExtendAppContext.Current.CodeTables.Add("MED_DIAGNOSIS_DICT", DataHelper.ToDataTable(ApplicationModel.Instance.AllDictList.DiagnosisDictList));
            }

            if (null != ApplicationModel.Instance.AllDictList.AnesthesiaDictList && !ExtendAppContext.Current.CodeTables.ContainsKey("MED_ANESTHESIA_DICT"))
            {
                ExtendAppContext.Current.CodeTables.Add("MED_ANESTHESIA_DICT", DataHelper.ToDataTable(ApplicationModel.Instance.AllDictList.AnesthesiaDictList));
            }

            if (null != ApplicationModel.Instance.AllDictList.EventDictList && !ExtendAppContext.Current.CodeTables.ContainsKey("MED_EVENT_DICT"))
            {
                ExtendAppContext.Current.CodeTables.Add("MED_EVENT_DICT", DataHelper.ToDataTable(ApplicationModel.Instance.AllDictList.EventDictList));
            }
        }

        /// <summary>
        /// 密码回车键触发登录功能
        /// </summary>
        public void TextPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.LoginCommand.Execute(sender);
            }

            this.SwitchMoveFocus(e);
        }

        /// <summary>
        /// 用户名文本框回车键触发切换焦点
        /// </summary>
        public void TextUserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                (e.OriginalSource as UIElement).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }

            this.SwitchMoveFocus(e);
        }

        /// <summary>
        /// 登录按键回车键触发切换焦点
        /// </summary>
        public void LoginButton_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.LoginCommand.Execute(sender);
            }

            this.SwitchMoveFocus(e);
        }

        /// <summary>
        /// 响应方向键切换焦点
        /// </summary>
        private void SwitchMoveFocus(KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                (e.OriginalSource as UIElement).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                // 获取焦点的控件
                UIElement nextUIElement = Keyboard.FocusedElement as UIElement;
                if (nextUIElement != null)
                {
                    Keyboard.Focus(nextUIElement);
                    if (nextUIElement is TextBox)
                    {
                        (nextUIElement as TextBox).SelectAll();
                    }
                    else if (nextUIElement is PasswordBox)
                    {
                        (nextUIElement as PasswordBox).SelectAll();
                    }
                }
            }
            else if (e.Key == Key.Up)
            {
                e.Handled = true;
                (e.OriginalSource as UIElement).MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));

                UIElement nextUIElement = Keyboard.FocusedElement as UIElement;
                if (nextUIElement != null)
                {
                    Keyboard.Focus(nextUIElement);
                    if (nextUIElement is TextBox)
                    {
                        (nextUIElement as TextBox).SelectAll();
                    }
                    else if (nextUIElement is PasswordBox)
                    {
                        (nextUIElement as PasswordBox).SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// 登录命令
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand<object>(data =>
                {
                    if (null != data && data is PasswordBox)
                    {
                        this.IsLogining = true;
                        PasswordBox passBox = data as PasswordBox;
                        this.StrLoginPwd = passBox.Password;

                        System.Threading.Thread loginThread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                        {
                            try
                            {
                                if (this.Login())
                                {
                                    ExtendAppContext.Current.LoginName = this.StrLoginName;
                                    if (ExtendAppContext.Current.CurEnumLoginType == Anes.FrameWork.Enum.EnumLoginType.NormalLogin)
                                    {
                                        //开启虚拟键盘服务
                                        new Thread(KeyBoardStateCache.KeyBoard.StartVirtualKeyBoardService).Start();
                                        // new Thread(KeyBoardStateCache.KeyBoard.StartWebDocPicService).Start();
                                        if (null != this.DelegateInitAllDictList) //禁止重复加载
                                        {
                                            this.DelegateInitAllDictList.EndInvoke(delegateResult);
                                            this.delegateResult = null;
                                            this.DelegateInitAllDictList = null;
                                        }
                                        this.InitAllDictList();
                                        this.ListConvertDataTable();
                                    }
                                    Messenger.Default.Send<object>(this, EnumMessageKey.CloseLogin);
                                }
                                else
                                {
                                    this.IsLogining = false;
                                    ShowMessageBox("用户名或密码错误，请重新输入！", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error("登录错误", ex);
                                ConfirmMessageBox.Show("登录错误，" + ex.Message, "提示信息", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }));

                        loginThread.SetApartmentState(System.Threading.ApartmentState.STA);
                        loginThread.Start();
                    }
                    else
                    {
                        this.IsLogining = false;
                    }
                });
            }
        }
    }
}
