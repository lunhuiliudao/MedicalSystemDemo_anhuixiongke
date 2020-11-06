// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      BottomMenuViewModel.cs
// 功能描述(Description)：    菜单栏对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             段世昱
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using MedicalSystem.Services;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.UsbKeyBoard;

namespace MedicalSystem.AnesWorkStation.ViewModel.ToolBarViewModel
{
    /// <summary>
    /// 【单个底部工具栏控件】
    /// </summary>
    public class SignleBottomMenuControl
    {
        private BitmapImage _controlPath;                           // 控件默认的背景图片
        private BitmapImage _ctrMouseOverPath;                      // 鼠标在图标上悬浮时显示的背景图片
        private string _controlName;                                // 控件名称

        /// <summary>
        /// 控件默认的背景图片
        /// </summary>
        public BitmapImage ControlPath
        {
            get { return _controlPath; }
            set { _controlPath = value; }
        }

        /// <summary>
        /// 鼠标在图标上悬浮时显示的背景图片
        /// </summary>
        public BitmapImage CtrMouseOverPath
        {
            get { return _ctrMouseOverPath; }
            set { _ctrMouseOverPath = value; }
        }

        /// <summary>
        /// 控件名称
        /// </summary>
        public string ControlName
        {
            get { return _controlName; }
            set { _controlName = value; }
        }
    }

    /// <summary>
    /// 底部工具栏ViewModel
    /// </summary>
    public class BottomMenuViewModel : BaseViewModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public BottomMenuViewModel()
        {
            IsCheckedItem = true;
        }

        #region 界面控件绑定
        /// <summary>
        /// 【单个底部工具栏控件】集合
        /// </summary>
        private List<SignleBottomMenuControl> _signleBottomMenuControlList = new List<SignleBottomMenuControl>();
        /// <summary>
        /// 【单个底部工具栏控件】集合(全部)
        /// </summary>
        private List<SignleBottomMenuControl> _signleBottomMenuControlListAll = new List<SignleBottomMenuControl>();
        /// <summary>
        /// 当前选中的【单个底部工具栏控件】
        /// </summary>
        private SignleBottomMenuControl _selectedSignleBottomMenuControl = new SignleBottomMenuControl();
        /// <summary>
        /// 是否勾选工具栏
        /// </summary>
        private bool _isCheckedItem = false;
        /// <summary>
        /// 是否勾选配置栏
        /// </summary>
        private bool _isCheckedItemConfig = false;
        /// <summary>
        /// 工具栏名称
        /// </summary>
        private string _toolBarName;
        /// <summary>
        /// 页码
        /// </summary>
        private int _pageIndex;

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                SetPageIndex();
            }
        }

        /// <summary>
        /// 工具栏名称
        /// </summary>
        public string ToolBarName
        {
            get { return _toolBarName; }
            set
            {
                _pageIndex = 0;
                _toolBarName = value;
                this.RaisePropertyChanged("ToolBarName");
            }
        }

        /// <summary>
        /// 是否勾选配置栏
        /// </summary>
        public bool IsCheckedItemConfig
        {
            get { return _isCheckedItemConfig; }
            set
            {
                _isCheckedItemConfig = value;
                if (value)
                {
                    ToolBarName = "功能菜单栏";
                    string configList = string.Empty;
                    // 从配置中获取需要显示的按钮信息列表
                    if (ExtendAppContext.Current.PatientInformationExtend != null)
                    {
                        if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.InOperationRoom)
                        {
                            configList = ApplicationConfiguration.BottomMenuFunctionListBeforeOperation;
                        }
                        else if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.InOperationRoom && ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                        {
                            configList = ApplicationConfiguration.BottomMenuFunctionListInOperation;
                        }
                        else if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.OutOperationRoom)
                        {
                            configList = ApplicationConfiguration.BottomMenuFunctionListAfterOperation;
                        }

                        _signleBottomMenuControlListAll = GetMenuList(configList);
                        this.SetPageIndex();
                    }
                }

                this.RaisePropertyChanged("IsCheckedItemConfig");
            }
        }

        /// <summary>
        /// 是否勾选工具栏
        /// </summary>
        public bool IsCheckedItem
        {
            get { return _isCheckedItem; }
            set
            {
                _isCheckedItem = value;
                if (value)
                {
                    ToolBarName = "文书菜单栏";
                    string configList = string.Empty;
                    // 从配置中获取需要显示的按钮信息列表
                    if (ExtendAppContext.Current.PatientInformationExtend != null)
                    {
                        if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.InOperationRoom)
                        {
                            configList = ApplicationConfiguration.SignleBottomMenuControlListBeforeOperationByNotPatienting;
                        }
                        else if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.InOperationRoom && ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                        {
                            configList = ApplicationConfiguration.SignleBottomMenuControlListInOperation;
                        }
                        else if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.OutOperationRoom)
                        {
                            configList = ApplicationConfiguration.SignleBottomMenuControlListAfterOperation;
                        }
                        _signleBottomMenuControlListAll = GetMenuList(configList);
                        SetPageIndex();
                    }
                }

                this.RaisePropertyChanged("CheckedItem");
            }
        }

        /// <summary>
        /// 【单个底部工具栏控件】集合
        /// </summary>
        public List<SignleBottomMenuControl> SignleBottomMenuControlList
        {
            get { return _signleBottomMenuControlList; }
            set
            {
                _signleBottomMenuControlList = value;
                this.RaisePropertyChanged("SignleBottomMenuControlList");
            }
        }

        /// <summary>
        /// 当前选中的【单个底部工具栏控件】
        /// </summary>
        public SignleBottomMenuControl SelectedSignleBottomMenuControl
        {
            get { return _selectedSignleBottomMenuControl; }
            set
            {
                _selectedSignleBottomMenuControl = value;
                this.RaisePropertyChanged("SelectedSignleBottomMenuControl");
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 翻页功能
        /// </summary>
        private void SetPageIndex()
        {
            if (_signleBottomMenuControlListAll.Count > MED_CONSTANT.TOOLS_PERPAGE * PageIndex)
            {
                SignleBottomMenuControlList = _signleBottomMenuControlListAll.Skip(MED_CONSTANT.TOOLS_PERPAGE * PageIndex).Take(MED_CONSTANT.TOOLS_PERPAGE).ToList();

                SignleBottomMenuControlList = _signleBottomMenuControlListAll;
            }
        }

        /// <summary>
        /// 从配置中获取需要显示的按钮信息列表
        /// </summary>
        private List<SignleBottomMenuControl> GetMenuList(string configList)
        {
            List<SignleBottomMenuControl> resultList = new List<SignleBottomMenuControl>();
            try
            {
                Dictionary<string, ImageList> bottonMenuItemDict = BottomMenuItemDictionary.BottomMenuItemDict;
                string[] docList = configList.Split(',');
                ImageList docInfo = null;
                foreach (string doc in docList)
                {
                    // 在平台添加文书，如果默认的字典BottomMenuItemDict里没有，则使用麻醉单文书的图标
                    if (bottonMenuItemDict.ContainsKey(doc))
                    {
                        docInfo = bottonMenuItemDict[doc];
                    }
                    else
                    {
                        docInfo = new ImageList() { ImageFirst = ResourceImage.麻醉记录单, ImageSecond = ResourceImage.麻醉单_选中 };
                    }

                    if (docInfo.ImageFirst != null && docInfo.ImageSecond != null)
                    {
                        SignleBottomMenuControl signleBottomMenuControl = new SignleBottomMenuControl();
                        signleBottomMenuControl.ControlPath = ImageHelper.BitmapToBitmapImage(docInfo.ImageFirst);
                        signleBottomMenuControl.CtrMouseOverPath = ImageHelper.BitmapToBitmapImage(docInfo.ImageSecond);
                        signleBottomMenuControl.ControlName = doc;
                        resultList.Add(signleBottomMenuControl);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("功能菜单异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return resultList;
        }

        /// <summary>
        /// 根据选择名称进行相应处理
        /// </summary>
        private void DoLoadReportOrWork(SignleBottomMenuControl selectedSignleBottomMenuControl)
        {
            if (ExtendAppContext.Current.PatientInformationExtend == null)
            {
                ShowMessageBox("请先选中一个患者后再操作手术信息。", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string controlName = selectedSignleBottomMenuControl.ControlName;
            switch (controlName)
            {
                case "麻醉记录单":
                case "术前访视单":
                case "术后随访单":
                case "三方核查单":
                case "麻醉同意书":
                case "不良后果告知书":
                case "麻醉总结单":
                case "术后镇痛记录单":
                case "输血评估单":
                case "手术安全核查单":
                    this.ShowDocByDocName(controlName);
                    break;
                case MED_CONSTANT.OPERATION_INFOMATION:
                    this.ShowContentWindow("OperationInformationControl", MED_CONSTANT.OPERATION_INFOMATION);
                    break;
                case MED_CONSTANT.AfterOperationInformationControl:
                    this.ShowContentWindow("AfterOperationInformationControl", MED_CONSTANT.AfterOperationInformationControl);
                    break;
                case "仪器设置":
                    if (ExtendAppContext.Current.PatientInformationExtend == null)
                    {
                        this.ShowMessageBox("无正在进行的手术，无法绑定仪器。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    this.ShowContentWindow("MonitorBind", "仪器设置", 760, 1200);
                    break;
                case "模板调用":
                    break;
                case "保存模板":
                    this.ShowContentWindow("AnesthesiaRouteControl", "保存模板", 438, 185);
                    break;
                case "更换手术间":
                    
                    this.ShowContentWindow("ChangeOperRoomNo", "更换手术间", 600, 660);
                    break;
                case "查看术中":
                    Messenger.Default.Send<object>(this, EnumMessageKey.ShowInOperationWindow);
                    break;
                case "手术交接班":
                    this.ShowContentWindow("OperationShift", "手术交接班", 700, 660);
                    break;
                case "检验结果":
                    this.ShowContentWindow("AssayReport", "检验结果查询", 600, 620);
                    break;
                case "血气分析":
                    this.BloodGasAnalysisControlMethod();
                    break;
                case "个性化体征":
                    this.ShowContentWindow("IndividuationVitalSignControl", "个性化体征", 600, 620);
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshSignVitalWindow);
                    break;
                case "手术跳转":
                    this.OperatioinJumpMethod();
                    break;
                case "手术取消":
                    if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE == (int)OperationStatus.InOperationRoom)
                    {
                        this.ShowContentWindow("OperationCanceled", "手术取消", 600, 660);
                    }
                    else
                    {
                        this.ShowMessageBox("只有处于入室状态才能取消手术！", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    break;
                case "家属协同":
                    this.ShowContentWindow("OperationScreen", "术中家属协同", 600, 660);
                    break;
                case "麻醉计费":
                    if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.AnesthesiaEnd)
                    {
                        this.ShowContentWindow("AnesFree", "麻醉计费", 700, 800);
                    }
                    else
                    {
                        this.ShowMessageBox("只有麻醉结束后才能进入麻醉计费功能！", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    break;
                case "批量归档":
                    if (ExtendAppContext.Current.LoginUser.USER_JOB_ID.Equals("MDSD"))
                    {
                        this.ShowMessageBox("当前登录账户为管理员账户，请使用医生账户重新登录！",
                                            MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    else
                    {
                        this.ShowContentWindow("UnPostPDFControl", "批量归档", 600, 730);
                    }
                    break;
                case "拍照":
                    var message = new ShowContentWindowMessage("CameraControl", "拍照");
                    message.Height = 660;
                    message.Width = 600;
                    message.WindowType = ContentWindowType.Document;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    // this.ShowContentWindow("CameraControl", "拍照", 600, 660);
                    break;
                case "麻醉评分":
                    this.ShowContentWindow("Balthazar", "麻醉评分", (int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight);
                    break;
                case "PACS检查信息":
                    this.ShowContentWindow("PacsInterface", "PACS检查信息", 600, 660);
                    break;
                default: // 当为找到对应的值时，默认使用文书解析
                    this.ShowDocByDocName(controlName);
                    break;
            }

            this.CloseContentWindow();
        }

        /// <summary>
        /// 卸载窗口说明：菜单栏是在执行调用文书后再关闭
        /// 导致卸载时会将AppCodeStack中的值移除不对。所以在这特殊处理
        /// </summary>
        public override void OnViewUnLoaded()
        {
            List<string> tempStackList = KeyBoardStateCache.AppCodeStack.ToList();
            tempStackList.Remove(AppCode.FunctionMenu);

            // 去除所有
            while (KeyBoardStateCache.AppCodeStack.Count > 0)
            {
                KeyBoardStateCache.AppCodeStack.Pop();
            }

            // 重新插入
            tempStackList.ForEach(x =>
            {
                KeyBoardStateCache.AppCodeStack.Push(x);
            });

            Messenger.Default.Unregister<dynamic>(this);
            UnRegisterKeyBoardMessage();
        }

        /// <summary>
        /// 载入窗口，用作接受参数
        /// </summary>
        public override void OnViewLoaded()
        {
            KeyBoardStateCache.AppCodeStack.Push(AppCode.FunctionMenu);
        }

        /// <summary>
        ///  因为菜单栏关闭时，CurntOpenForm已经设置过了，这里就不再重置
        /// </summary>
        public override void ResetCurntOpenForm()
        {
        }

        /// <summary>
        /// 根据窗体名，载入窗体
        /// </summary>
        private void ShowContentWindow(string windowName, string title)
        {
            var message = new ShowContentWindowMessage(windowName, title);
            message.Height = MED_CONSTANT.POPUP_WINDOW_HEIGHT;
            message.Width = MED_CONSTANT.POPUP_WINDOW_WIDTH;
            Messenger.Default.Send<ShowContentWindowMessage>(message);
        }

        #endregion

        #region 命令
        /// <summary>
        /// 选择菜单项
        /// </summary>
        public ICommand ChooseCommand
        {
            get
            {
                return new RelayCommand<SignleBottomMenuControl>(signleBottomMenuControl =>
                {
                    try
                    {
                        if (signleBottomMenuControl != null)
                        {
                            this.DoLoadReportOrWork(signleBottomMenuControl);
                            this.SelectedSignleBottomMenuControl = signleBottomMenuControl;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("功能菜单异常信息", ex);
                        ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        /// <summary>
        /// 翻页
        /// </summary>
        public ICommand PageChange
        {
            get
            {
                return new RelayCommand<int>(index =>
                {
                    try
                    {
                        if (PageIndex == 0)
                        {
                            PageIndex++;
                        }
                        else
                        {
                            PageIndex--;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("功能菜单异常信息", ex);
                        this.ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        #endregion

        /// <summary>
        /// 丢失焦点时关闭菜单栏
        /// </summary>
        public override void Control_LostFocus(object sender, EventArgs e)
        {
            base.Control_LostFocus(sender, e);
            this.CloseContentWindow();
        }

        /// <summary>
        /// 响应按键事件
        /// </summary>
        protected override void KeyBoardMessage(string keyCode)
        {
            switch (keyCode)
            {
                case MedicalSystem.Anes.FrameWork.KeyCode.AppCode.Back:
                    this.CloseContentWindow();
                    break;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected override SaveResult SaveData()
        {
            return SaveResult.CancelMessageBox;//工具栏不提示保存按ML键
        }
    }
}
