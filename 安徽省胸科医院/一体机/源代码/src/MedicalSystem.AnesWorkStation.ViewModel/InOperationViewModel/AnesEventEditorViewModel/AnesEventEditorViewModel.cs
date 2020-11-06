//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AnesEventEditorViewModel.cs
//功能描述(Description)：    术中事件、呼吸、用药、麻药、输液、出液、插管、拔管操作逻辑
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:19:46
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.FrameWork.InputMethod;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.AnesEventEditorViewModel
{
    public class AnesEventEditorViewModel : BaseViewModel
    {
        #region 变量和构造函数
        private bool isChanged = false;
        /// <summary>
        /// 当前是否进入了快速切换大事件逻辑
        /// </summary>
        public bool IsChangeOperEventing = false;
        private List<MED_EVENT_DICT> tmpEventDictData;
        /// <summary>
        ///  事件集合
        /// </summary>
        private List<MED_EVENT_DICT> _eventDictData;
        public List<MED_EVENT_DICT> EventDictData
        {
            get { return _eventDictData; }
            set
            {
                _eventDictData = value;
                RaisePropertyChanged("EventDictData");
            }
        }

        private ObservableCollection<MED_ANESTHESIA_EVENT> tmpAnesEvent;
        /// <summary>
        ///  事件集合
        /// </summary>
        private ObservableCollection<MED_ANESTHESIA_EVENT> _anesEvent;
        public ObservableCollection<MED_ANESTHESIA_EVENT> AnesEvent
        {
            get { return _anesEvent; }
            set
            {
                _anesEvent = value;
                RaisePropertyChanged("AnesEvent");
            }
        }
        /// <summary>
        /// 所选行集合
        /// </summary>
        private MED_ANESTHESIA_EVENT _selectItem;
        public MED_ANESTHESIA_EVENT SelectItem
        {
            get { return _selectItem; }
            set
            {
                _selectItem = value;
                RaisePropertyChanged("SelectItem");
            }
        }
        /// <summary>
        /// 所选行号
        /// </summary>
        private int selectedIndex = -1;

        public int SelectedIndex
        {
            get { return this.selectedIndex; }
            set
            {
                this.selectedIndex = value;
                this.RaisePropertyChanged("SelectedIndex");
            }
        }

        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _eventNo;

        private dynamic paramaterData;

        #endregion
        /// <summary>
        /// 重写加载
        /// </summary>
        /// <returns></returns>
        public override void OnViewLoaded()
        {
            try
            {
                base.OnViewLoaded();
                if (Args != null)
                {
                    paramaterData = Args[0];
                }
            }
            catch (Exception ex)
            {
                Logger.Error("事件录入异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public AnesEventEditorViewModel()
        {
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            _eventNo = "0";
            this.RegisterMessage();
        }

        /// <summary>
        /// 注册快速切换大事件的命令
        /// </summary>
        public void RegisterMessage()
        {
            Messenger.Default.Register<object>(this, EnumMessageKey.QuickChangeOperEventWindow, msg =>
            {
                if (!this.IsChangeOperEventing && null != msg && !string.IsNullOrEmpty(msg.ToString()))
                {
                    this.IsChangeOperEventing = true;
                    // 保存当前界面数据
                    if (this.SaveBeforeChangeOperEvent())
                    {
                        ExtendAppContext.Current.CurntOpenForm = new OpenForm(msg.ToString(), null);
                        paramaterData = msg.ToString();
                        this.LoadData();

                        // 刷新窗口的标题
                        Messenger.Default.Send<string>(ExtendAppContext.Current.OperEventInfoList.First(x =>
                                                                                                        x.AppCode.Equals(msg)).Title,
                                                       EnumMessageKey.RefreshOperEventWindowTitle);
                    }
                }
            });
        }

        /// <summary>
        /// 在快速切换前判断数据是否需要保存
        /// </summary>
        private bool SaveBeforeChangeOperEvent()
        {
            bool result = true;
            // 检查数据是否修改过 以及判断数据是否完整
            if (this.CheckDataChange() && this.CheckData())
            {
                ShowMessageBox("当前数据有修改，是否保存数据？",
                                MessageBoxButton.YesNoCancel,
                                MessageBoxImage.Question,
                                new Action<MessageBoxResult>((r) =>
                                {
                                    // 是or否 跳转，取消
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
                                            result = false;
                                        }
                                    }
                                    else if (r == MessageBoxResult.No)
                                    {
                                        result = true;
                                    }
                                    else if (r == MessageBoxResult.Cancel)
                                    {
                                        result = false;
                                    }
                                }));
            }

            return result;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        protected override bool DeleteData()
        {
            bool result = true;
            if (_selectItem != null)
            {
                // 在删除后selectindex会变动，所以在这声明一个临时变量记录
                int tempSelectIndex = this.SelectedIndex;
                MED_ANESTHESIA_EVENT data = tmpAnesEvent.Single(x => x.PATIENT_ID == _selectItem.PATIENT_ID &&
                                                                     x.VISIT_ID == _selectItem.VISIT_ID &&
                                                                     x.OPER_ID == _selectItem.OPER_ID &&
                                                                     x.ITEM_NO == _selectItem.ITEM_NO &&
                                                                     x.EVENT_NO == _selectItem.EVENT_NO);
                data.ModelStatus = ModelStatus.Deleted;
                MED_ANESTHESIA_EVENT data2 = AnesEvent.Single(x => x.PATIENT_ID == _selectItem.PATIENT_ID &&
                                                                   x.VISIT_ID == _selectItem.VISIT_ID &&
                                                                   x.OPER_ID == _selectItem.OPER_ID &&
                                                                   x.ITEM_NO == _selectItem.ITEM_NO &&
                                                                   x.EVENT_NO == _selectItem.EVENT_NO);
                if (data.ModelStatus != ModelStatus.Add)
                {
                    data.ModelStatus = ModelStatus.Deleted;
                    AnesEvent.Remove(data2);
                }
                else
                {
                    tmpAnesEvent.Remove(data);
                    AnesEvent.Remove(data2);
                }

                Messenger.Default.Send<object>(tempSelectIndex, EnumMessageKey.ResetOperationMedNoteControlFocus);
            }
            else
            {
                result = false;
                this.ShowMessageBox("当前选中项为空，请重新操作！", MessageBoxButton.OK, MessageBoxImage.Information);
                Messenger.Default.Send<object>(this, EnumMessageKey.ResetOperationMedNoteControlFocus);
            }

            return result;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            if (null != this._eventDictData)
            {
                this.EventDictData.Clear();
                this.EventDictData = null;
                this.AnesEvent.Clear();
                this.AnesEvent = null;
            }

            _eventDictData = AILearnInputUtil.GetSortedList(ApplicationModel.Instance.AllDictList.EventDictList,
                                                            ApplicationModel.Instance.AllDictList.EventSortList);
            _anesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(AnesInfoService.ClientInstance.GetAnesthesiaEventByEventNo(_patientID, _visitID, _operID, _eventNo).OrderBy(x => x.START_TIME));
            tmpAnesEvent = _anesEvent;
            if (paramaterData != null)
            {
                switch ((string)paramaterData)
                {
                    case KeyCode.AppCode.Event:
                        EventDictData = _eventDictData.Where(x => x.EVENT_CLASS_CODE == "1").ToList();
                        AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                            _anesEvent.Where(x => x.EVENT_CLASS_CODE == "1").ToList());
                        break;
                    case KeyCode.AppCode.Intubatton:
                        EventDictData = _eventDictData.Where(x => x.EVENT_CLASS_CODE == "7").ToList();
                        AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                            _anesEvent.Where(x => x.EVENT_CLASS_CODE == "7").ToList());
                        break;
                    case KeyCode.AppCode.Extubation:
                        EventDictData = _eventDictData.Where(x => x.EVENT_CLASS_CODE == "8").ToList();
                        AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                            _anesEvent.Where(x => x.EVENT_CLASS_CODE == "8").ToList());
                        break;
                }
            }
            else
            {
                EventDictData = _eventDictData.Where(x => x.EVENT_CLASS_CODE != "2" && x.EVENT_CLASS_CODE != "3" &&
                                                          x.EVENT_CLASS_CODE != "4" && x.EVENT_CLASS_CODE != "B" &&
                                                          x.EVENT_CLASS_CODE != "C" && x.EVENT_CLASS_CODE != "D").ToList();
                AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(_anesEvent.Where(x => x.EVENT_CLASS_CODE != "2" &&
                                                          x.EVENT_CLASS_CODE != "3" && x.EVENT_CLASS_CODE != "4" &&
                                                          x.EVENT_CLASS_CODE != "B" && x.EVENT_CLASS_CODE != "C" &&
                                                          x.EVENT_CLASS_CODE != "D").ToList());
            }

            tmpEventDictData = EventDictData;
            isChanged = false;
        }

        /// <summary>
        /// 设置麻醉事件排序值
        /// </summary>
        private void SetEventSortValue(MED_ANESTHESIA_EVENT row)
        {
            MED_EVENT_SORT tempSortData = ApplicationModel.Instance.AllDictList.EventSortList.Where(p => p.EVENT_ITEM_CODE == row.EVENT_ITEM_CODE && p.EVENT_CLASS_CODE == row.EVENT_CLASS_CODE).FirstOrDefault();

            if (tempSortData != null)
            {
                tempSortData.SORT_NO += 1;
                tempSortData.ModelStatus = ModelStatus.Modeified;
            }
            else
            {
                tempSortData = new MED_EVENT_SORT
                {
                    EVENT_CLASS_CODE = row.EVENT_CLASS_CODE,
                    EVENT_ITEM_CODE = row.EVENT_ITEM_CODE,
                    EVENT_ITEM_NAME = row.EVENT_ITEM_NAME,
                    USER_ID = ExtendAppContext.Current.LoginUser.USER_JOB_ID,
                    SORT_NO = 1,
                    ModelStatus=ModelStatus.Add
                };
                ApplicationModel.Instance.AllDictList.EventSortList.Add(tempSortData);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            TransactionParamsters tp = TransactionParamsters.Create();
            //tp.Append(tmpAnesEvent).Append(ApplicationModel.Instance.AllDictList.EventSortList);
            tp.Append(this.GetTureModifiedData(tmpAnesEvent.ToList())).Append(this.GetTureModifiedData(ApplicationModel.Instance.AllDictList.EventSortList));
            bool result = CommonService.ClientInstance.UpdateByTransaction(tp.ToString());
            SaveResult saveResult = SaveResult.Fail;
            if (result)
            {
                //saveResult = SaveResult.Success;
                saveResult = SaveResult.CancelMessageBox;// 大事件保存成功后无需弹出框
            }
            // 刷新排序集合的ModelStatus，默认更新成功
            ApplicationModel.Instance.AllDictList.EventSortList.ForEach(sortEle =>
            {
                sortEle.ModelStatus = ModelStatus.Default;
            });
            return saveResult;
        }

        /// <summary>
        /// 新增事件
        /// </summary>
        /// <returns></returns>
        protected override bool InsertData()
        {
            Messenger.Default.Send<object>(this, EnumMessageKey.ResetOperationMedNoteControlFocus);
            return true;
        }

        /// <summary>
        /// 检查数据是否改变
        /// </summary>
        /// <returns></returns>
        protected override bool CheckDataChange()
        {
            bool result = false;
            if (tmpAnesEvent != null)
            {
                foreach (var item in tmpAnesEvent)
                {
                    if (item.ModelStatus != ModelStatus.Default)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = true;
            if (ExtendAppContext.Current.IsModify && ExtendAppContext.Current.IsPermission)
            {
                if (tmpAnesEvent != null)
                {
                    foreach (var item in tmpAnesEvent)
                    {
                        if (item.ModelStatus == ModelStatus.Deleted)
                        {
                            continue;
                        }

                        if (!item.START_TIME.HasValue)
                        {
                            ShowMessageBox("请填写开始时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                            result = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                ShowMessageBox("术后患者或非当前手术间患者的医生，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return result;
        }

        #region Commands

        /// <summary>
        /// 左侧事件按钮双击事件
        /// </summary>
        public ICommand LeftEventDoubleClick
        {
            get
            {
                return new RelayCommand<MED_EVENT_DICT>(data =>
                {
                    if (ExtendAppContext.Current.IsModify && ExtendAppContext.Current.IsPermission)
                    {
                        MED_ANESTHESIA_EVENT newAnesEvent = new MED_ANESTHESIA_EVENT();
                        newAnesEvent.PATIENT_ID = _patientID;
                        newAnesEvent.VISIT_ID = _visitID;
                        newAnesEvent.OPER_ID = _operID;

                        var maxEventNo = 0;
                        if (tmpAnesEvent != null && tmpAnesEvent.Count > 0)
                        {
                            maxEventNo = tmpAnesEvent.OrderByDescending(a => a.ITEM_NO).FirstOrDefault().ITEM_NO;
                        }
                        newAnesEvent.ITEM_NO = maxEventNo + 1;
                        newAnesEvent.EVENT_NO = _eventNo;

                        newAnesEvent.EVENT_CLASS_CODE = data.EVENT_CLASS_CODE;
                        newAnesEvent.EVENT_ITEM_NAME = data.EVENT_ITEM_NAME;
                        newAnesEvent.EVENT_ITEM_CODE = data.EVENT_ITEM_CODE;
                        newAnesEvent.EVENT_ITEM_SPEC = data.EVENT_ITEM_SPEC;
                        newAnesEvent.DOSAGE = data.DOSAGE;
                        newAnesEvent.DOSAGE_UNITS = data.DOSAGE_UNITS;
                        newAnesEvent.ADMINISTRATOR = data.ADMINISTRATOR;
                        newAnesEvent.START_TIME = DateTime.Now;
                        newAnesEvent.END_TIME = null;
                        newAnesEvent.DURATIVE_INDICATOR = data.DURATIVE_INDICATOR;
                        newAnesEvent.PERFORM_SPEED = data.PERFORM_SPEED;
                        newAnesEvent.SPEED_UNIT = data.SPEED_UNIT;
                        newAnesEvent.EVENT_ATTR = data.EVENT_ATTR;
                        newAnesEvent.CONCENTRATION = data.CONCENTRATION;
                        newAnesEvent.CONCENTRATION_UNIT = data.CONCENTRATION_UNIT;
                        newAnesEvent.SUPPLIER_NAME = data.SUPPLIER_NAME;
                        newAnesEvent.ModelStatus = ModelStatus.Add;
                        AnesEvent.Add(newAnesEvent);
                        tmpAnesEvent.Add(newAnesEvent);

                        SetEventSortValue(newAnesEvent);
                        this.SelectedIndex = this.AnesEvent.Count - 1;
                    }
                    else
                    {
                        ShowMessageBox("术后患者或非当前手术间患者，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                });
            }
        }

        /// <summary>
        /// 表格删除事件
        /// </summary>
        public ICommand DeleteItemClick
        {
            get
            {
                return new RelayCommand<MED_ANESTHESIA_EVENT>(data =>
                {
                    if (null != data)
                    {
                        if (ExtendAppContext.Current.IsModify && ExtendAppContext.Current.IsPermission)
                        {
                            if (data.ModelStatus != ModelStatus.Add)
                            {
                                data.ModelStatus = ModelStatus.Deleted;
                                AnesEvent.Remove(data);
                            }
                            else
                            {
                                tmpAnesEvent.Remove(data);
                                AnesEvent.Remove(data);
                            }
                        }
                        else
                        {
                            ShowMessageBox("术后患者或非当前手术间患者，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                });
            }
        }

        /// <summary>
        /// 搜索框点击按钮事件
        /// </summary>
        public ICommand SearchClick
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    if (!string.IsNullOrEmpty(key.Trim()))
                        EventDictData = tmpEventDictData.Where(x => x.EventNamePY.Contains(key.Trim().ToUpper()) || x.EVENT_ITEM_NAME.Contains(key.Trim())).ToList();
                });
            }
        }

        /// <summary>
        /// 搜索框文本变化事件
        /// </summary>
        public ICommand SearchTextBoxTextChanged
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    if (!string.IsNullOrEmpty(key.Trim()))
                        EventDictData = tmpEventDictData.Where(x => x.EventNamePY.Contains(key.Trim().ToUpper()) || x.EVENT_ITEM_NAME.Contains(key.Trim())).ToList();
                });
            }
        }
        #endregion

    }
}
