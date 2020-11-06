// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      BaseViewModel.cs
// 功能描述(Description)：    所有ViewModel的父类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using System.Reflection;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.ViewModel
{
    public abstract class BaseViewModel : ViewModelBase
    {
        /// <summary>
        /// 键盘消息锁
        /// </summary>
        public bool keyBoardMessageLock = false;                                   // 键盘消息锁
        private bool IsSaved = false;                                              // 是否已经保存过
        private bool _registerPublicKeyBoard = true;                               // 是否需要注册键盘
        private List<MED_DEPT_DICT> _medDeptDict;                                  // 科室
        private List<MED_OPERATING_ROOM> _medOperatingRoomDict;                    // 手术间
        private List<MED_DIAGNOSIS_DICT> _medDiagnosisDict;                        // 术前诊断
        private List<MED_OPERATION_DICT> _medOperationDict;                        // 手术名称
        private List<MED_ANESTHESIA_INPUT_DICT> _medOperationScaleDict;            // 手术等级
        private List<MED_ANESTHESIA_INPUT_DICT> _medOperationPositionDict;         // 手术体位
        private List<MED_HIS_USERS> _medHisUsersDict;                              // 所有医生
        private List<MED_HIS_USERS> _medDoctorDict;                                // 麻醉医生
        private List<MED_HIS_USERS> _medNurseDict;                                 // 护士
        private List<string> _medAnesthesiaTypeDict;                               // 麻醉方法类型
        private List<MED_ANESTHESIA_DICT> _medAnesthesiaDict;                      // 麻醉方法
        private List<MED_ANESTHESIA_INPUT_DICT> _medASAGradeDict;                  // ASA分级
        private List<MED_ANESTHESIA_INPUT_DICT> _medQieClassDict;                  // 切口等级
        private List<MED_ANESTHESIA_INPUT_DICT> _medAnesEfectDict;                 // 麻醉效果
        private List<MED_ANESTHESIA_INPUT_DICT> _medAfterAnalgesiaDict;            // 术后镇痛   是；否
        private List<MED_ANESTHESIA_INPUT_DICT> _medAnalgesiaMethodDict;           // 镇痛方式 
        private List<MED_ANESTHESIA_INPUT_DICT> _medImageTypeDict;                 // 图像类型
        private List<string> _emergencyType;                                       // 急诊/择期类型选择
        private List<string> _emergencyFlow;                                       // 流向选择
        private List<MED_OPERATION_MASTER> _patientList;                           // 流向选择
        private List<MED_MONITOR_DICT> _monitorDict;                               // 监护仪字典数据

        /// <summary>
        /// 科室字典绑定
        /// </summary>
        public List<MED_DEPT_DICT> DEPT_DICT
        {
            get { return this._medDeptDict; }
            set
            {
                this._medDeptDict = value;
                RaisePropertyChanged("DEPT_DICT");
            }
        }

        /// <summary>
        /// 急诊/择期患者去向
        /// </summary>
        public List<string> EmergencyFlow
        {
            get { return this._emergencyFlow; }
            set
            {
                this._emergencyFlow = value;
                this.RaisePropertyChanged("EmergencyFlow");
            }
        }

        /// <summary>
        /// 搜索下拉框的患者列表
        /// </summary>
        public List<MED_OPERATION_MASTER> PatientList
        {
            get { return this._patientList; }
            set
            {
                this._patientList = value;
                this.RaisePropertyChanged("PatientList");
            }
        }
        /// <summary>
        /// 急诊/择期
        /// </summary>
        public List<string> EmergencyType
        {
            get { return this._emergencyType; }
            set
            {
                this._emergencyType = value;
                this.RaisePropertyChanged("EmergencyType");
            }
        }

        /// <summary>
        /// 手术间字典绑定
        /// </summary>
        public List<MED_OPERATING_ROOM> MED_OPERATING_ROOM
        {
            get { return this._medOperatingRoomDict; }
            set
            {
                this._medOperatingRoomDict = value;
                RaisePropertyChanged("MED_OPERATING_ROOM");
            }
        }

        /// <summary>
        /// 术前诊断字典绑定
        /// </summary>
        public List<MED_DIAGNOSIS_DICT> MED_DIAGNOSIS_DICT
        {
            get { return this._medDiagnosisDict; }
            set
            {
                this._medDiagnosisDict = value;
                RaisePropertyChanged("MED_DIAGNOSIS_DICT");
            }
        }

        /// <summary>
        /// 手术名称（拟施手术）字典绑定
        /// </summary>
        public List<MED_OPERATION_DICT> MED_OPERATION_DICT
        {
            get { return this._medOperationDict; }
            set
            {
                this._medOperationDict = value;
                RaisePropertyChanged("MED_OPERATION_DICT");
            }
        }

        /// <summary>
        /// 手术等级字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> MED_OPERATION_SCALE_DICT
        {
            get { return this._medOperationScaleDict; }
            set
            {
                this._medOperationScaleDict = value;
                RaisePropertyChanged("MED_OPERATION_SCALE_DICT");
            }
        }

        /// <summary>
        /// 手术体位字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> MED_OPERATION_POSITION_DICT
        {
            get { return this._medOperationPositionDict; }
            set
            {
                this._medOperationPositionDict = value;
                RaisePropertyChanged("MED_OPERATION_POSITION_DICT");
            }
        }

        /// <summary>
        /// 麻醉医生字典绑定
        /// </summary>
        public List<MED_HIS_USERS> MED_DOCTOR_DICT
        {
            get { return this._medDoctorDict; }
            set
            {
                this._medDoctorDict = value;
                RaisePropertyChanged("MED_DOCTOR_DICT");
            }
        }

        /// <summary>
        /// 护士字典绑定
        /// </summary>
        public List<MED_HIS_USERS> MED_NURSE_DICT
        {
            get { return this._medNurseDict; }
            set
            {
                this._medNurseDict = value;
                RaisePropertyChanged("MED_NURSE_DICT");
            }
        }

        /// <summary>
        /// 人员信息列表
        /// </summary>
        public List<MED_HIS_USERS> MED_USERS_DICT
        {
            get { return this._medHisUsersDict; }
            set
            {
                this._medHisUsersDict = value;
                RaisePropertyChanged("MED_USERS_DICT");
            }
        }

        /// <summary>
        /// 麻醉方法字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_DICT> MED_ANESTHESIA_DICT
        {
            get { return this._medAnesthesiaDict; }
            set
            {
                this._medAnesthesiaDict = value;
                RaisePropertyChanged("MED_ANESTHESIA_DICT");
            }
        }

        /// <summary>
        /// ASA分级字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> MED_ASA_GRADE_DICT
        {
            get { return this._medASAGradeDict; }
            set
            {
                this._medASAGradeDict = value;
                RaisePropertyChanged("MED_ASA_GRADE_DICT");
            }
        }

        /// <summary>
        /// 切口等级字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> MED_QIE_CLASS_DICT
        {
            get { return this._medQieClassDict; }
            set
            {
                this._medQieClassDict = value;
                RaisePropertyChanged("MED_QIE_CLASS_DICT");
            }
        }

        /// <summary>
        /// 麻醉效果字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> MED_ANES_EFECT_DICT
        {
            get { return this._medAnesEfectDict; }
            set
            {
                this._medAnesEfectDict = value;
                RaisePropertyChanged("MED_ANES_EFECT_DICT");
            }
        }

        /// <summary>
        /// 术后镇痛字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> MED_AFTER_ANALGESIA_DICT
        {
            get { return this._medAfterAnalgesiaDict; }
            set
            {
                this._medAfterAnalgesiaDict = value;
                RaisePropertyChanged("MED_AFTER_ANALGESIA_DICT");
            }
        }

        /// <summary>
        /// 镇痛方式字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> MED_ANALGESIA_METHOD_DICT
        {
            get { return this._medAnalgesiaMethodDict; }
            set
            {
                this._medAnalgesiaMethodDict = value;
                RaisePropertyChanged("MED_ANALGESIA_METHOD_DICT");
            }
        }

        public List<MED_ANESTHESIA_INPUT_DICT> MED_IMAGE_TYPE_DICT
        {
            get { return this._medImageTypeDict; }
            set
            {
                this._medImageTypeDict = value;
                RaisePropertyChanged("MED_IMAGE_TYPE_DICT");
            }
        }

        /// <summary>
        /// 监护仪字典绑定
        /// </summary>
        public List<MED_MONITOR_DICT> MONITORDICT
        {
            get { return _monitorDict; }
            set
            {
                this._monitorDict = value;
                RaisePropertyChanged("MONITORDICT");
            }
        }

        /// <summary>
        /// 是否需要注册键盘事件
        /// </summary>
        public bool RegisterPublicKeyBoard
        {
            get { return _registerPublicKeyBoard; }
            set { _registerPublicKeyBoard = value; }
        }

        /// <summary>
        /// 在创建窗口时传递过来的默认参数
        /// </summary>
        public object[] Args { get; set; }

        /// <summary>
        /// 额外的数据
        /// </summary>
        public object ExtraData { get; set; }

        /// <summary>
        /// 窗口返回的结果数据
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// 无参异步关闭窗口的委托定义，用以在多线程情况下关闭窗口
        /// </summary>
        public Action CloseContentWindowDelegate { get; set; }

        /// <summary>
        /// 有参异步关闭窗口的委托定义，用以在多线程情况下关闭窗口
        /// </summary>
        public Action<object> CloseContentWindowDelegateEx { get; set; }

        /// <summary>
        /// 无参构造
        /// </summary>
        public BaseViewModel()
        {
        }

        /// <summary>
        /// 检查是否有更新数据
        /// </summary>
        protected virtual bool CheckDataChange()
        {
            return false;
        }

        /// <summary>
        /// 检查页面数据是否完整
        /// </summary>
        protected virtual bool CheckData()
        {
            return true;
        }

        /// <summary>
        /// 打开文书
        /// </summary>
        /// <param name="docName">文书名称</param>
        public void ShowDocByDocName(string docName)
        {
            if (ExtendAppContext.Current.PatientInformationExtend == null || ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID == "")
            {
                ConfirmMessageBox.Show("系统提示", "请先选中一个患者后重试。", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var message = new ShowContentWindowMessage("LoadReport", docName);
            message.Height = SystemParameters.PrimaryScreenHeight;
            message.Width = SystemParameters.PrimaryScreenWidth;
            message.WindowType = ContentWindowType.Document;
            message.Args = new object[] { docName };
            Messenger.Default.Send<ShowContentWindowMessage>(message);
        }

        /// <summary>
        /// 调用血气分析
        /// </summary>
        public void BloodGasAnalysisControlMethod()
        {
            ExtendAppContext.Current.CurntOpenForm = new OpenForm("BloodGasAnalysisControl", null);
            this.ShowContentWindow("BloodGasAnalysisControl", "血气分析", 600, 620);
        }

        /// <summary>
        /// 调用手术跳转
        /// </summary>
        public void OperatioinJumpMethod()
        {
            if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE == (int)OperationStatus.IsReady ||
                ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE == (int)OperationStatus.Done)
            {
                this.ShowMessageBox("病案已归档或者还未开始手术不能进入手术跳转功能", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE == (int)OperationStatus.InPACU ||
                     ExtendAppContext.Current.PatientInformationExtend.IN_PACU_DATE_TIME.HasValue)
            {
                this.ShowMessageBox("该患者在复苏中或已经完成复苏不能进入手术跳转功能", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                ExtendAppContext.Current.CurntOpenForm = new OpenForm("OperationJump", null);
                this.ShowContentWindow("OperationJump", "手术跳转", 600, 660);
            }
        }

        /// <summary>
        /// 根据窗体名，载入窗体,同时设置窗体的宽和高
        /// </summary>
        public void ShowContentWindow(string windowName, string title, int width, int height)
        {
            var message = new ShowContentWindowMessage(windowName, title);
            message.Height = height;
            message.Width = width;
            Messenger.Default.Send<ShowContentWindowMessage>(message);
        }

        /// <summary>
        /// 注册键盘消息
        /// </summary>
        public void RegisterKeyBoardMessage()
        {
            Messenger.Default.Register<string>(this, MessageTokens.KEYBOARDMSG, msg =>
                {
                    this.KeyBoardMessage(msg);

                    if (this.RegisterPublicKeyBoard)//术中主页面不需要调取这些公共保存消息
                    {
                        this.PublicKeyBoardMessage(msg);
                    }
                });
        }

        /// <summary>
        /// 卸载键盘消息
        /// </summary>
        public void UnRegisterKeyBoardMessage()
        {
            Messenger.Default.Unregister<string>(this, MessageTokens.KEYBOARDMSG);
        }

        /// <summary>
        /// 键盘响应事件，提供各个模块调用
        /// </summary>
        protected virtual void KeyBoardMessage(string keyCode)
        {
        }

        /// <summary>
        /// 键盘响应公共消息，Home，Back，Save，Delete等等
        /// </summary>
        protected virtual void PublicKeyBoardMessage(string keyCode)
        {
            // 按键响应屏蔽多次响应
            if ((keyCode == KeyCode.AppCode.Delete ||
                 keyCode == KeyCode.AppCode.Save ||
                 keyCode == KeyCode.AppCode.Back) && keyBoardMessageLock)
            {
                return;
            }

            // 如果按键是 新增事件 按键，则按键锁无需打开
            if (keyCode != KeyCode.AppCode.Insert ||
                 keyCode == KeyCode.AppCode.HOME)
            {
                keyBoardMessageLock = true;
            }

            try
            {
                WhirlingControlManager.ShowWaitingForm();
                switch (keyCode)
                {
                    case KeyCode.AppCode.Insert:
                        InsertData();
                        break;
                    case KeyCode.AppCode.Delete:
                        if (ExtendAppContext.Current.IsModify && ExtendAppContext.Current.IsPermission)
                        {
                            DeleteData();
                        }
                        else
                        {
                            ShowMessageBox("术后患者或非当前手术间患者，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case KeyCode.AppCode.Save:
                        if (ExtendAppContext.Current.IsModify && ExtendAppContext.Current.IsPermission)
                        {
                            if (CheckData())//检查数据是否完整
                            {
                                //此处省略检查数据是否修改过，既然点击保存就执行保存操作
                                SaveResult saveResult = SaveData();
                                if (saveResult == SaveResult.Fail)
                                {
                                    ShowMessageBox("数据保存失败。", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else if (saveResult == SaveResult.Success)
                                {
                                    ShowMessageBox("数据保存成功。", MessageBoxButton.OK, MessageBoxImage.Information);
                                    IsSaved = true;
                                }
                                else if (saveResult == SaveResult.CancelMessageBox)
                                {
                                    IsSaved = true;
                                }
                                if (IsSaved)
                                {
                                    this.CloseContentWindow();
                                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshInOperationWindow);
                                }
                            }
                        }
                        else
                        {
                            ShowMessageBox("术后患者或非当前手术间患者，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case KeyCode.AppCode.HOME:
                        this.CloseContentWindow();
                        Messenger.Default.Send<object>(this, EnumMessageKey.CloseInOperationWindow);
                        break;
                    case KeyCode.AppCode.Back:
                        KeyBack();
                        break;
                }
            }
            catch (Exception ex)
            {
                WhirlingControlManager.CloseWaitingForm();
                Logger.Error("程序异常", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                WhirlingControlManager.CloseWaitingForm();
                if (keyCode != KeyCode.AppCode.Insert)
                {
                    keyBoardMessageLock = false;
                }
            }
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        public virtual void LoadData()
        {
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected virtual SaveResult SaveData()
        {
            return SaveResult.Success;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected virtual bool DeleteData()
        {
            return true;
        }

        /// <summary>
        /// 新增事件
        /// </summary>
        protected virtual bool InsertData()
        {
            return true;
        }

        /// <summary>
        /// 返回按键
        /// </summary>
        protected virtual void KeyBack()
        {
            this.CloseContentWindow();
        }

        /// <summary>
        /// 载入窗口，用作接受参数
        /// </summary>
        public virtual void OnViewLoaded()
        {
            if (!string.IsNullOrEmpty(KeyBoardStateCache.CurrentAppCode))
            {
                KeyBoardStateCache.AppCodeStack.Push(KeyBoardStateCache.CurrentAppCode);
            }
        }

        /// <summary>
        /// 卸载窗口
        /// </summary>
        public virtual void OnPreviewViewUnLoaded(CancelEventArgs e)
        {
            // 已经保存过了
            if (IsSaved)
            {
                return;
            }

            try
            {
                if (ExtendAppContext.Current.IsModify && ExtendAppContext.Current.IsPermission)
                {
                    if (CheckDataChange())//检查数据是否修改过
                    {
                        if (CheckData())//检查数据是否完整
                        {
                            keyBoardMessageLock = true;
                            ShowMessageBox("当前数据有修改，是否保存数据？",
                                           MessageBoxButton.YesNoCancel,
                                           MessageBoxImage.Question,
                                           new Action<MessageBoxResult>((r) =>
                                           {
                                               if (r == MessageBoxResult.Yes || r == MessageBoxResult.OK)
                                               {
                                                   SaveResult saveResult = SaveResult.Success;
                                                   try
                                                   {
                                                       WhirlingControlManager.ShowWaitingForm();
                                                       saveResult = SaveData();
                                                   }
                                                   finally
                                                   {
                                                       WhirlingControlManager.CloseWaitingForm();
                                                   }
                                                   if (saveResult == SaveResult.Fail)
                                                   {
                                                       ShowMessageBox("数据保存失败。", MessageBoxButton.OK, MessageBoxImage.Error);
                                                   }
                                               }
                                               else if (r == MessageBoxResult.No)
                                               {
                                               }
                                               else
                                               {
                                                   keyBoardMessageLock = false;
                                                   e.Cancel = true;
                                               }
                                           }));
                        }
                        else
                        {
                            // 检查数据不完整，并且有修改 不关闭窗口
                            keyBoardMessageLock = false;
                            e.Cancel = true;
                        }
                    }
                }

                // 关闭窗口时，清除当前打开窗体对象
                if (!e.Cancel)
                {
                    ExtendAppContext.Current.CurrentDocName = string.Empty;// 文书加载也清空
                    this.ResetCurntOpenForm();
                    Messenger.Default.Unregister<string>(this);
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshInOperationWindow);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("程序异常", ex);
                ShowMessageBox("系统异常，中断该操作", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        /// <summary>
        /// 重置CurntOpenForm，但有的界面在关闭时无需重置，需要重写该方法
        /// </summary>
        public virtual void ResetCurntOpenForm()
        {
            ExtendAppContext.Current.CurntOpenForm = null;
        }

        /// <summary>
        /// 卸载窗口，注销键盘按键事件，防止多次注册导致多次调用
        /// </summary>
        public virtual void OnViewUnLoaded()
        {
            if (KeyBoardStateCache.AppCodeStack.Count > 0 &&
                KeyBoardStateCache.AppCodeStack.Peek() == KeyBoardStateCache.CurrentAppCode)
            {
                KeyBoardStateCache.CurrentAppCode = KeyBoardStateCache.AppCodeStack.Peek();
                KeyBoardStateCache.AppCodeStack.Pop();
            }

            Messenger.Default.Unregister<dynamic>(this);
            UnRegisterKeyBoardMessage();
        }

        /// <summary>
        /// 虚方法：键盘按下事件
        /// </summary>
        public virtual void KeyDown(object sender, KeyEventArgs e)
        {
        }

        /// <summary>
        /// 虚方法：窗口丢失焦点事件
        /// </summary>
        public virtual void Control_LostFocus(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 关闭窗口，使用异步委托
        /// </summary>
        protected virtual void CloseContentWindow()
        {
            if (CloseContentWindowDelegate != null)
            {
                CloseContentWindowDelegate();
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        protected void SendMessage<T>(T message)
        {
            MessengerInstance.Send<T>(message);
        }

        /// <summary>
        /// 向View层发送消息弹出MessageBox
        /// </summary>
        public void ShowMessageBox(string subMessage = "",
                                   MessageBoxButton button = MessageBoxButton.OK,
                                   MessageBoxImage icon = MessageBoxImage.None,
                                   Action<MessageBoxResult> callBack = null,
                                   bool isAutoClose = false,
                                   int autoCloseTime = 2000,
                                   bool isAsyncShow = false)
        {
            SendMessage<ShowMessageBoxMessage>(new ShowMessageBoxMessage("预留Title", isAutoClose, subMessage, button, icon, callBack, autoCloseTime, isAsyncShow));
        }

        /// <summary>
        /// 载入字典数据
        /// </summary>
        protected virtual void LoadDictData()
        {
            try
            {
                // 获取字典数据
                DEPT_DICT = ApplicationModel.Instance.AllDictList.DeptDictList;
                // 手术间字典需要获取最新
                ApplicationModel.Instance.AllDictList.OperatingRoomList = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();
                MED_OPERATING_ROOM = ApplicationModel.Instance.AllDictList.OperatingRoomList.Where(x => x.BED_TYPE == ExtendAppContext.Current.EventNo).ToList();
                MED_DIAGNOSIS_DICT = ApplicationModel.Instance.AllDictList.DiagnosisDictList;
                MED_OPERATION_DICT = ApplicationModel.Instance.AllDictList.OperationDictList;
                MED_DOCTOR_DICT = ApplicationModel.Instance.AllDictList.HisUsersList.Where(x => x.USER_DEPT_CODE == ExtendAppContext.Current.AnesWardCode && (x.USER_JOB == null || x.USER_JOB.Contains("医生"))).ToList();
                MED_NURSE_DICT = ApplicationModel.Instance.AllDictList.HisUsersList.Where(x => x.USER_DEPT_CODE == ExtendAppContext.Current.OperDeptCode && (x.USER_JOB == null || x.USER_JOB.Contains("护士"))).ToList();
                MED_USERS_DICT = ApplicationModel.Instance.AllDictList.HisUsersList.Where(x => x.USER_JOB == null || x.USER_JOB.Contains("医生")).ToList();
                MED_OPERATION_SCALE_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "手术等级").ToList();
                MED_OPERATION_POSITION_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "手术体位").ToList();
                MED_ANESTHESIA_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaDictList;
                MED_ASA_GRADE_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "ASA分级").ToList();
                MED_QIE_CLASS_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "切口等级").ToList();
                MED_ANES_EFECT_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "麻醉效果").ToList();
                MED_AFTER_ANALGESIA_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "术后镇痛").ToList();
                MED_ANALGESIA_METHOD_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "镇痛方式").ToList();
                MED_IMAGE_TYPE_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS == "图像分类").ToList();
                ApplicationModel.Instance.AllDictList.MonitorDictList = DictService.ClientInstance.GetMonitorDictList();
                MONITORDICT = ApplicationModel.Instance.AllDictList.MonitorDictList.Where(x => x.WARD_TYPE.ToString() == ExtendAppContext.Current.EventNo && x.BED_NO == ExtendAppContext.Current.OperRoomNo).ToList();

                List<string> emtype = new List<string>();
                emtype.Add("急诊");
                emtype.Add("择期");
                EmergencyType = emtype;

                List<string> flow = new List<string>();
                flow.Add("ICU");
                flow.Add("恢复室");
                flow.Add("病房");
                flow.Add("急诊");
                flow.Add("离院");
                EmergencyFlow = flow;
            }
            catch (Exception ex)
            {
                Logger.Error("异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 人员名称转换
        /// </summary>
        protected virtual string ShowUserName(string code)
        {
            string value = code;
            List<MED_HIS_USERS> hisUserList = ApplicationModel.Instance.AllDictList.HisUsersList;
            foreach (MED_HIS_USERS user in hisUserList)
            {
                if (user.USER_JOB_ID == code) { value = user.USER_NAME; break; }
            }

            return value;
        }

        /// <summary>
        /// 根据ID判断是否存在该人员
        /// </summary>
        protected virtual bool ExistsUser(string jobID)
        {
            if (MED_USERS_DICT != null)
            {
                MED_HIS_USERS mhu = MED_USERS_DICT.Where(r => r.USER_JOB_ID == jobID).FirstOrDefault();
                if (mhu != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 根据ID判断是否存在该护士
        /// </summary>
        protected virtual bool ExistsNurse(string jobID)
        {
            if (MED_NURSE_DICT != null)
            {
                MED_HIS_USERS mhu = MED_NURSE_DICT.Where(r => r.USER_JOB_ID == jobID).FirstOrDefault();
                if (mhu != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 根据ID判断是否存在该医生
        /// </summary>
        protected virtual bool ExistsDoctor(string jobID)
        {
            if (MED_USERS_DICT != null)
            {
                MED_HIS_USERS mhu = MED_DOCTOR_DICT.Where(r => r.USER_JOB_ID == jobID).FirstOrDefault();
                if (mhu != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 对比新老数据集合，获取真正需要更新的数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="oldList">旧数据</param>
        /// <param name="newList">新数据</param>
        /// <returns>真正变化的数据</returns>
        protected virtual List<T> GetTureModifiedData<T>(List<T> oldList, List<T> newList) where T : BaseModel
        {
            if (oldList != null && newList != null && (oldList.Count > 0 || newList.Count > 0))
            {
                List<PropertyInfo> keyPropInfos = new List<PropertyInfo>();// 键值属性
                List<PropertyInfo> otherPropInfos = new List<PropertyInfo>();// 普通属性
                // PropertyInfo modelStatus; // 实体变化属性
                PropertyInfo[] proInfos = typeof(T).GetProperties();
                List<T> trueList = new List<T>();
                foreach (PropertyInfo proInfo in proInfos)
                {
                    Attribute keyAttribute = proInfo.GetCustomAttribute(typeof(KeyAttribute));// 得到键相关信息
                    if (keyAttribute != null)
                    {
                        keyPropInfos.Add(proInfo);// 获取键值属性
                    }
                    else
                    {
                        if (!proInfo.Name.Equals("ModelStatus"))// 获取除了状态变化属性以外的普通属性
                        {
                            otherPropInfos.Add(proInfo);
                        }
                        //else
                        //  modelStatus = proInfo;
                    }
                }
                if (oldList.Count == 0 && newList.Count > 0)// 全部都是新增值
                {
                    return newList;
                }
                else
                {
                    foreach (T newEle in newList)
                    {
                        if (newEle.ModelStatus == ModelStatus.Add || newEle.ModelStatus == ModelStatus.Deleted)// 状态是新增或删除，直接添加
                        {
                            trueList.Add(newEle);
                        }
                        else
                        {
                            // 获取oldList里主键相同的元素
                            T oldElement = oldList.FirstOrDefault(oldEle =>
                            {
                                foreach (PropertyInfo key in keyPropInfos)
                                {
                                    // 使用var只会是object类型比较
                                    dynamic newValue = Convert.ChangeType(newEle.GetValue(key.Name), key.PropertyType);
                                    dynamic oldValue = Convert.ChangeType(oldEle.GetValue(key.Name), key.PropertyType);
                                    if (newValue != oldValue)// 主键不同，则进行下一个元素的比较
                                    {
                                        return false;
                                    }
                                }
                                return true;
                            });
                            if (oldElement == null)// oldList里找不到newList里的某个对象，说明这个对象肯定是新增的
                            {
                                trueList.Add(newEle);
                            }
                            else// 对比主键相同的对象
                            {
                                foreach (PropertyInfo field in otherPropInfos)// 普通字段比较
                                {
                                    // 可空类型时，需要使用Nullable的转换，否则Convert.ChangeType会报错
                                    Type fieldType = Nullable.GetUnderlyingType(field.PropertyType) ?? field.PropertyType;
                                    dynamic newValue = newEle.GetValue(field.Name) == null ? null : Convert.ChangeType(newEle.GetValue(field.Name), fieldType);
                                    dynamic oldValue = oldElement.GetValue(field.Name) == null ? null : Convert.ChangeType(oldElement.GetValue(field.Name), fieldType);
                                    if (newValue != oldValue)// 只要普通字段有一个值不同，就认为发生了改变
                                    {
                                        trueList.Add(newEle);
                                        break;
                                    }
                                }
                            }
                            #region 旧处理
                            //foreach (T oldEle in oldList)
                            //{
                            //    bool sameEle = true;
                            //    foreach (PropertyInfo key in keyPropInfos)// 主键比较,主键不为空
                            //    {
                            //        // 使用var只会是object类型比较
                            //        dynamic newValue = Convert.ChangeType(newEle.GetValue(key.Name), key.PropertyType);
                            //        dynamic oldValue = Convert.ChangeType(oldEle.GetValue(key.Name), key.PropertyType);

                            //        if (newValue != oldValue)// 主键不同，则进行下一个元素的比较
                            //        {
                            //            sameEle = false;
                            //            break;
                            //        }
                            //    }
                            //    if (sameEle)// 主键相同，比较其他字段
                            //    {
                            //        foreach (PropertyInfo field in otherPropInfos)// 普通字段比较
                            //        {
                            //            // 可空类型时，需要使用Nullable的转换，否则Convert.ChangeType会报错
                            //            Type fieldType = Nullable.GetUnderlyingType(field.PropertyType) ?? field.PropertyType;
                            //            dynamic newValue = newEle.GetValue(field.Name) == null ? null : Convert.ChangeType(newEle.GetValue(field.Name), fieldType);
                            //            dynamic oldValue = oldEle.GetValue(field.Name) == null ? null : Convert.ChangeType(oldEle.GetValue(field.Name), fieldType);
                            //            if (newValue != oldValue)// 只要普通字段有一个值不同，就认为发生了改变
                            //            {
                            //                trueList.Add(newEle);
                            //                break;
                            //            }
                            //        }
                            //        break;
                            //    }
                            //}
                            #endregion
                        }
                    }
                    return trueList;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取术中界面真正需要更新的数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="newList">新数据</param>
        /// <returns>真正变化的数据</returns>
        protected virtual List<T> GetTureModifiedData<T>(List<T> newList) where T : BaseModel
        {
            if (newList != null && newList.Count > 0)
            {
                List<T> trueList = new List<T>();
                newList.ForEach(newEle =>
                {
                    if (newEle.ModelStatus != ModelStatus.Default)// 术中界面由于BaseModel的RaisePropertyChanged事件，实体类属性变化，则会变成Modeified
                    {
                        trueList.Add(newEle);
                    }
                });
                return trueList;
            }
            return null;
        }


        /// <summary>
        /// 获取动态对象
        /// </summary>
        public dynamic GetDynamicObject(Dictionary<string, object> properties)
        {
            return new CustomDynamicObject(properties);
        }

        #region
        /// <summary>
        /// 自定义动态对象
        /// </summary>
        public class CustomDynamicObject : DynamicObject, INotifyPropertyChanged, ICustomTypeDescriptor
        {

            #region DynamicObject
            public readonly Dictionary<string, object> _properties;                        // 字典信息
            public event PropertyChangedEventHandler PropertyChanged;                      // 属性值更改事件

            /// <summary>
            /// 带参的构造方法
            /// </summary>
            /// <param name="properties">字典</param>
            public CustomDynamicObject(Dictionary<string, object> properties)
            {
                _properties = properties;
            }

            /// <summary>
            /// 根据字典的KEY获取对应的Value
            /// </summary>
            public object GetMemberValue(string name)
            {
                if (_properties.ContainsKey(name))
                {
                    return _properties[name];
                }
                else
                {
                    return null;
                }
            }

            /// <summary>
            /// 字典新增数据
            /// </summary>
            public bool AddProp(string key, object value)
            {
                if (!_properties.ContainsKey(key))
                {
                    _properties.Add(key, value);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// 重写方法：获取字典的所有KEY
            /// </summary>
            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return _properties.Keys;
            }

            /// <summary>
            /// 重写方法：根据属性，获取字典中的值
            /// </summary>
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (_properties.ContainsKey(binder.Name))
                {
                    result = _properties[binder.Name];
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }

            /// <summary>
            /// 重写方法：根据属性信息和新值，重新设置字典中对应KEY的值
            /// </summary>
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                if (_properties.ContainsKey(binder.Name))
                {
                    if (!_properties[binder.Name].Equals(value))
                    {
                        _properties[binder.Name] = value;
                        OnPropertyChanged(binder.Name);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// 方法：实现接口INotifyPropertyChanged
            /// </summary>
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            /// <summary>
            /// 直接根据KEY获取值
            /// </summary>
            public object this[string name]
            {
                get
                {
                    if (_properties.ContainsKey(name))
                    {
                        return _properties[name];
                    }
                    return null;
                }
                set
                {
                    _properties[name] = value;
                }
            }

            /// <summary>
            /// 获取属性
            /// </summary>
            public AttributeCollection GetAttributes()
            {
                return AttributeCollection.Empty;
            }

            /// <summary>
            /// 获取类型名称
            /// </summary>
            public string GetClassName()
            {
                return null;
            }

            /// <summary>
            /// 获取空间信息
            /// </summary>
            public string GetComponentName()
            {
                return null;
            }

            public TypeConverter GetConverter()
            {
                return null;
            }

            public EventDescriptor GetDefaultEvent()
            {
                return null;
            }

            public PropertyDescriptor GetDefaultProperty()
            {
                return null;
            }

            public object GetEditor(Type editorBaseType)
            {
                return null;
            }

            public EventDescriptorCollection GetEvents(Attribute[] attributes)
            {
                return EventDescriptorCollection.Empty;
            }

            public EventDescriptorCollection GetEvents()
            {
                return EventDescriptorCollection.Empty;
            }

            public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                return new PropertyDescriptorCollection(_properties.Keys.Select(key => new MyDescriptor(key)).ToArray());
            }

            public PropertyDescriptorCollection GetProperties()
            {
                return GetProperties(null);
            }

            public object GetPropertyOwner(PropertyDescriptor pd)
            {
                return this;
            }

            #endregion
        }

        /// <summary>
        /// 自定义属性描述类
        /// </summary>
        public class MyDescriptor : PropertyDescriptor
        {
            public MyDescriptor(string name) : base(name, null) { }

            public override bool CanResetValue(object component)
            {
                return true;
            }

            public override Type ComponentType
            {
                get { return typeof(CustomDynamicObject); }
            }

            public override object GetValue(object component)
            {
                return (component as CustomDynamicObject)[Name];
            }

            public override bool IsReadOnly
            {
                get { return false; }
            }

            public override Type PropertyType
            {
                get { return typeof(object); }
            }

            public override void ResetValue(object component)
            {
                (component as CustomDynamicObject)._properties.Remove(Name);
            }

            public override void SetValue(object component, object value)
            {
                (component as CustomDynamicObject)[Name] = value;
            }

            public override bool ShouldSerializeValue(object component)
            {
                return (component as CustomDynamicObject)._properties.ContainsKey(Name);
            }
        }
        #endregion

        ~BaseViewModel()
        {
            this.Destroy();
        }
    }
}
