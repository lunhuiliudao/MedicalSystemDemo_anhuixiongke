//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AnesDrugEditorViewModel.xaml.cs
//功能描述(Description)：    术中用药、麻药、输液、出液、输血逻辑处理
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:49:12
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
using MedicalSystem.AnesWorkStation.Model.AnesEventEditorModel;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
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
    public class AnesDrugEditorViewModel : BaseViewModel
    {
        #region 变量和构造函数
        /// <summary>
        /// 当前是否进入了快速切换大事件逻辑
        /// </summary>
        public bool IsChangeOperEventing = false;
        private dynamic paramaterData;                                           // 传入参数
        private string _patientID;                                               // 患者ID
        private int _visitID;                                                    // 患者ID
        private int _operID;                                                     // 患者ID
        private string _eventNo;                                                 // 事件类型：麻醉=0，复苏=1
        private DateTime _clickTime;                                             // 持续单元格连续两次鼠标点击的时间，用于判断是否是双击
        private bool isFirstAdd = false;                                         // 当前界面是否是首次添加
        private List<MED_EVENT_DICT> tmpDrugDictData;                            // 缓存麻醉事件字典表
        private List<MED_EVENT_DICT> _drugDictData;                              // 左侧列表字典的所有信息
        private MED_EVENT_DICT drugDictDataSelectedItem = null;                  // 左侧列表的选中项
        private ObservableCollection<MED_ANESTHESIA_EVENT> tmpAnesEvent;         // 患者事件缓存表
        private ObservableCollection<MED_ANESTHESIA_EVENT> _anesEvent;           // 患者事件表
        private MED_ANESTHESIA_EVENT _selectItem;                                // 列表选中的行
        private int selectedIndex = -1;                                          // 列表选中的行的索引
        private List<MED_EVENT_DICT_EXT> _drugDictExtData;                       // 左侧字典表
        private List<MED_ADMINISTRATION_DICT> _administrationDict;               // 途径字典表
        private List<MED_UNIT_DICT> _dosageUnitDict;                             // 剂量单位表
        private List<MED_UNIT_DICT> _speedUnitDict;                              // 速度单位表
        private List<MED_UNIT_DICT> _concentrationUnitDict;                      // 浓度单位表
        private bool _normalMode = false;                                        // 当前表格是简单模式还是详细模式，默认简单模式
        private string strDosageColumnHeader = "剂量";                           // 界面表格中，剂量列的列头显示信息，当为呼吸类型时，剂量显示成频率
        private bool isShowAdministratorColumn = true;                           // 界面表格中是否显示途径列。当为呼吸类型时，途径列不显示

        private List<DurativeIndicatorModel> durativeIndicatorList = new List<DurativeIndicatorModel>();   // 持续类型列表：持续还是单次用药

        /// <summary>
        /// 左侧列表字典的所有信息
        /// </summary>
        public List<MED_EVENT_DICT> DrugDictData
        {
            get { return _drugDictData; }
            set
            {
                _drugDictData = value;
                RaisePropertyChanged("DrugDictData");
            }
        }

        /// <summary>
        /// 左侧列表选中项
        /// </summary>
        public MED_EVENT_DICT DrugDictDataSelectedItem
        {
            get { return this.drugDictDataSelectedItem; }
            set
            {
                this.drugDictDataSelectedItem = value;
                this.RaisePropertyChanged("DrugDictDataSelectedItem");
            }
        }

        /// <summary>
        /// 患者事件表
        /// </summary>
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
        /// 列表选中的行
        /// </summary>
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
        /// 左侧字典表
        /// </summary>
        public List<MED_EVENT_DICT_EXT> DrugDictExtData
        {
            get { return _drugDictExtData; }
            set
            {
                _drugDictExtData = value;
                RaisePropertyChanged("DrugDictExtData");
            }
        }

        /// <summary>
        /// 途径字典表
        /// </summary>
        public List<MED_ADMINISTRATION_DICT> AdministrationDict
        {
            get { return _administrationDict; }
            set
            {
                _administrationDict = value;
                RaisePropertyChanged("AdministrationDict");
            }
        }

        /// <summary>
        /// 剂量单位表
        /// </summary>
        public List<MED_UNIT_DICT> DosageUnitDict
        {
            get { return _dosageUnitDict; }
            set
            {
                _dosageUnitDict = value;
                RaisePropertyChanged("DosageUnitDict");
            }
        }

        /// <summary>
        /// 速度单位表
        /// </summary>
        public List<MED_UNIT_DICT> SpeedUnitDict
        {
            get { return _speedUnitDict; }
            set
            {
                _speedUnitDict = value;
                RaisePropertyChanged("SpeedUnitDict");
            }
        }

        /// <summary>
        /// 浓度单位表
        /// </summary>
        public List<MED_UNIT_DICT> ConcentrationUnitDict
        {
            get { return _concentrationUnitDict; }
            set
            {
                _concentrationUnitDict = value;
                RaisePropertyChanged("ConcentrationUnitDict");
            }
        }

        /// <summary>
        /// 当前表格是简单模式还是详细模式，默认简单模式
        /// </summary>
        public bool NormalMode
        {
            get { return _normalMode; }
            set
            {
                _normalMode = value;
                RaisePropertyChanged("NormalMode");
                // 切换简单和详细模式时刷新界面，设置焦点到搜索框
                Messenger.Default.Send<object>(this, EnumMessageKey.ResetOperationMedNoteControlFocus);
            }
        }

        /// <summary>
        /// 列表选中的行的索引
        /// </summary>
        public int SelectedIndex
        {
            get { return this.selectedIndex; }
            set
            {
                this.selectedIndex = value;
                this.RaisePropertyChanged("SelectedIndex");
            }
        }

        /// <summary>
        /// 持续类型列表：持续还是单次用药
        /// </summary>
        public List<DurativeIndicatorModel> DurativeIndicatorList
        {
            get { return this.durativeIndicatorList; }
            set
            {
                this.durativeIndicatorList = value;
                this.RaisePropertyChanged("DurativeIndicatorList");
            }
        }

        /// <summary>
        /// 界面表格中，剂量列的列头显示信息，当为呼吸类型时，剂量显示成频率
        /// </summary>
        public string StrDosageColumnHeader
        {
            get { return this.strDosageColumnHeader; }
            set
            {
                this.strDosageColumnHeader = value;
                this.RaisePropertyChanged("StrDosageColumnHeader");
            }
        }

        /// <summary>
        /// 界面表格中是否显示途径列。当为呼吸类型时，途径列不显示
        /// </summary>
        public bool IsShowAdministratorColumn
        {
            get { return this.isShowAdministratorColumn; }
            set
            {
                this.isShowAdministratorColumn = value;
                this.RaisePropertyChanged("IsShowAdministratorColumn");
            }
        }
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public AnesDrugEditorViewModel()
        {
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            _eventNo = "0";
            isFirstAdd = true;
            this.DurativeIndicatorList.Add(new DurativeIndicatorModel(0, string.Empty));
            this.DurativeIndicatorList.Add(new DurativeIndicatorModel(1, "=>"));
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

                        // 刷新窗口的标题，在刷新完成后 IsChangeOperEventing = false
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
        /// 重写加载方法
        /// </summary>
        public override void LoadData()
        {
            this.CustomLoadDictData();

            tmpDrugDictData = _drugDictData;
            _anesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(AnesInfoService.ClientInstance.GetAnesthesiaEventByEventNo(_patientID, _visitID, _operID, _eventNo).OrderBy(x => x.START_TIME));

            tmpAnesEvent = _anesEvent;
            if (paramaterData != null)
            {
                if (paramaterData is IntakeAndOutputClickData)
                {
                    if (paramaterData.InAndOutType == IntakeAndOutputType.Medicine)
                    {
                        AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(_anesEvent.Where(x => x.EVENT_CLASS_CODE == "4" || x.EVENT_CLASS_CODE == "2" || x.EVENT_CLASS_CODE == "C").ToList());
                        DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "4" || x.EVENT_CLASS_CODE == "2" || x.EVENT_CLASS_CODE == "C").ToList();
                    }
                    else if (paramaterData.InAndOutType == IntakeAndOutputType.Output)
                    {
                        AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(_anesEvent.Where(x => x.EVENT_CLASS_CODE == "D").ToList());
                        DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "D").ToList();
                    }
                    else if (paramaterData.InAndOutType == IntakeAndOutputType.Infusion)
                    {
                        AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(_anesEvent.Where(x => x.EVENT_CLASS_CODE == "3" || x.EVENT_CLASS_CODE == "B").ToList());
                        DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "3" || x.EVENT_CLASS_CODE == "B").ToList();
                    }
                }
                else if (paramaterData is string)
                {
                    switch ((string)paramaterData)
                    {
                        case KeyCode.AppCode.AnesDrug:
                            AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                                _anesEvent.Where(x => x.EVENT_CLASS_CODE == "2").ToList());
                            DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "2").ToList();
                            break;
                        case KeyCode.AppCode.Drug:
                            AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                                _anesEvent.Where(x => x.EVENT_CLASS_CODE == "C").ToList());
                            DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "C").ToList();
                            break;
                        case KeyCode.AppCode.InLiquid:
                            AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                                _anesEvent.Where(x => x.EVENT_CLASS_CODE == "3").ToList());
                            DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "3").ToList();
                            break;
                        case KeyCode.AppCode.Breath:
                            AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                                _anesEvent.Where(x => x.EVENT_CLASS_CODE == "Y" || x.EVENT_CLASS_CODE == "A"
                                || x.EVENT_CLASS_CODE == "9").ToList());
                            DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "Y"
                                || x.EVENT_CLASS_CODE == "A" || x.EVENT_CLASS_CODE == "9").ToList();

                            // 隐藏途径列，把剂量列的表头设置成频率
                            this.IsShowAdministratorColumn = false;
                            this.StrDosageColumnHeader = "频率";
                            break;
                        case KeyCode.AppCode.Oxygen:
                            AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                                _anesEvent.Where(x => x.EVENT_CLASS_CODE == "4").ToList());
                            DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "4").ToList();
                            NormalMode = true;
                            break;
                        case KeyCode.AppCode.Blood:
                            AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                                _anesEvent.Where(x => x.EVENT_CLASS_CODE == "B").ToList());
                            DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "B").ToList();
                            break;
                        case KeyCode.AppCode.OutLiquid:
                            AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(
                                _anesEvent.Where(x => x.EVENT_CLASS_CODE == "D").ToList());
                            DrugDictData = _drugDictData.Where(x => x.EVENT_CLASS_CODE == "D").ToList();
                            break;
                    }
                }
                else if (paramaterData is List<MED_ANESTHESIA_EVENT_TEMPLET>)
                {
                    var maxEventNo = 0;
                    if (tmpAnesEvent != null && tmpAnesEvent.Count > 0)
                    {
                        maxEventNo = tmpAnesEvent.OrderByDescending(a => a.ITEM_NO).FirstOrDefault().ITEM_NO;
                    }
                    DateTime applyTime = (DateTime)Args[1];
                    for (int i = 0; i < paramaterData.Count; i++)
                    {
                        MED_ANESTHESIA_EVENT item = new MED_ANESTHESIA_EVENT();
                        item.PATIENT_ID = _patientID;
                        item.VISIT_ID = _visitID;
                        item.OPER_ID = _operID;
                        maxEventNo += 1;
                        item.ITEM_NO = maxEventNo;
                        item.EVENT_NO = _eventNo;

                        item.EVENT_CLASS_CODE = paramaterData[i].EVENT_ITEM_CLASS;
                        item.EVENT_ITEM_NAME = paramaterData[i].EVENT_ITEM_NAME;
                        item.EVENT_ITEM_CODE = paramaterData[i].EVENT_ITEM_CODE;
                        item.EVENT_ITEM_SPEC = paramaterData[i].EVENT_ITEM_SPEC;
                        item.DOSAGE = paramaterData[i].DOSAGE;
                        item.DOSAGE_UNITS = paramaterData[i].DOSAGE_UNITS;
                        item.ADMINISTRATOR = paramaterData[i].ADMINISTRATOR;
                        item.DURATIVE_INDICATOR = paramaterData[i].DURATIVE_INDICATOR;
                        item.METHOD = paramaterData[i].METHOD;
                        item.METHOD_PARENT_NO = paramaterData[i].METHOD_PARENT_NO;
                        item.PERFORM_SPEED = paramaterData[i].PERFORM_SPEED;
                        item.SPEED_UNIT = paramaterData[i].SPEED_UNIT;
                        item.CONCENTRATION = paramaterData[i].CONCENTRATION;
                        item.CONCENTRATION_UNIT = paramaterData[i].CONCENTRATION_UNIT;
                        item.EVENT_ATTR = paramaterData[i].EVENT_ATTR;
                        item.PARENT_ITEM_NO = paramaterData[i].PARENT_ITEM_NO;
                        item.START_TIME = applyTime.AddMinutes((double)paramaterData[i].START_AFTER_INPUT);
                        if (paramaterData[i].DURATIVE != null)
                        {
                            item.END_TIME = item.START_TIME.Value.AddMinutes((double)paramaterData[i].DURATIVE);
                        }
                        item.ModelStatus = ModelStatus.Add;
                        _anesEvent.Add(item);
                    }
                    AnesEvent = new ObservableCollection<MED_ANESTHESIA_EVENT>(_anesEvent);
                }
                tmpDrugDictData = DrugDictData;// 每次加载,用药、麻药、输液、出液、输血时都需要重新赋值字典
            }

            _clickTime = DateTime.Now;
        }

        /// <summary>
        /// 加载所需字典数据
        /// </summary>
        private void CustomLoadDictData()
        {
            // 快速切换进入，需要重新设置数据源，不然界面上无法显示
            if (null != this._drugDictData)
            {
                this.DrugDictData.Clear();
                this.DrugDictData = null;
                this.AnesEvent.Clear();
                this.AnesEvent = null;
                this.DosageUnitDict.Clear();
                this.DosageUnitDict = null;
                this.SpeedUnitDict.Clear();
                this.SpeedUnitDict = null;
                this.ConcentrationUnitDict.Clear();
                this.ConcentrationUnitDict = null;
                this.AdministrationDict.Clear();
                this.AdministrationDict = null;
            }

            _drugDictData = AILearnInputUtil.GetSortedList(ApplicationModel.Instance.AllDictList.EventDictList,
                                                           ApplicationModel.Instance.AllDictList.EventSortList);

            List<MED_ADMINISTRATION_DICT> tempAdminDict = new List<MED_ADMINISTRATION_DICT>(ApplicationModel.Instance.AllDictList.AdministrationDictList);
            if (tempAdminDict[0].ADMINISTRATION_NAME != "")
            {
                MED_ADMINISTRATION_DICT item = new MED_ADMINISTRATION_DICT();
                item.ADMINISTRATION_NAME = "";
                item.ADMINISTRATION_CODE = "";
                tempAdminDict.Insert(0, item);
            }

            List<MED_UNIT_DICT> tempDosageUnitDict = ApplicationModel.Instance.AllDictList.UnitDictList.Where(x => x.UNIT_TYPE == 3).ToList();
            List<MED_UNIT_DICT> tempSpeedUnitDict = ApplicationModel.Instance.AllDictList.UnitDictList.Where(x => x.UNIT_TYPE == 2).ToList();
            List<MED_UNIT_DICT> tempConcentrationUnitDict = ApplicationModel.Instance.AllDictList.UnitDictList.Where(x => x.UNIT_TYPE == 1).ToList();
            if (tempDosageUnitDict[0].UNIT_NAME != "")
            {
                MED_UNIT_DICT item = new MED_UNIT_DICT();
                item.UNIT_NAME = "";
                item.UNIT_CODE = "";
                tempDosageUnitDict.Insert(0, item);
                tempSpeedUnitDict.Insert(0, item);
                tempConcentrationUnitDict.Insert(0, item);
            }

            this.AdministrationDict = tempAdminDict;
            this.DosageUnitDict = tempDosageUnitDict;
            this.SpeedUnitDict = tempSpeedUnitDict;
            this.ConcentrationUnitDict = tempConcentrationUnitDict;
        }

        /// <summary>
        /// 获取窗口传参
        /// </summary>
        public override void OnViewLoaded()
        {
            try
            {
                base.OnViewLoaded();
                paramaterData = Args[0];
            }
            catch (Exception ex)
            {
                Logger.Error("用药录入异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 卸载窗口时绑定术中的按键响应
        /// </summary>
        public override void OnViewUnLoaded()
        {
            base.OnViewUnLoaded();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            SaveResult saveResult = SaveResult.Fail;
            TransactionParamsters tp = TransactionParamsters.Create();
            //tp.Append(tmpAnesEvent).Append(ApplicationModel.Instance.AllDictList.EventSortList);
            // 仅获取ModelStatus发什么变化的数据
            tp.Append(this.GetTureModifiedData(tmpAnesEvent.ToList())).Append(this.GetTureModifiedData(ApplicationModel.Instance.AllDictList.EventSortList));
            bool result = CommonService.ClientInstance.UpdateByTransaction(tp.ToString());
            if (result)
            {
                //saveResult = SaveResult.Success;
                saveResult = SaveResult.CancelMessageBox; // 大事件数据保存成功后无需弹出确认对话框
            }

            foreach (var item in tmpAnesEvent)
            {
                item.ModelStatus = ModelStatus.Default;
            }

            // 刷新排序集合的ModelStatus，默认更新成功
            ApplicationModel.Instance.AllDictList.EventSortList.ForEach(sortEle =>
            {
                sortEle.ModelStatus = ModelStatus.Default;
            });


            return saveResult;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        protected override bool DeleteData()
        {
            bool result = false;
            if (_selectItem != null)
            {
                // 在删除后selectindex会变动，所以在这声明一个临时变量记录
                int tempSelectIndex = this.SelectedIndex;

                MED_ANESTHESIA_EVENT data = tmpAnesEvent.Single(x => x.PATIENT_ID == _selectItem.PATIENT_ID &&
                                                                     x.VISIT_ID == _selectItem.VISIT_ID &&
                                                                     x.OPER_ID == _selectItem.OPER_ID &&
                                                                     x.ITEM_NO == _selectItem.ITEM_NO &&
                                                                     x.EVENT_NO == _selectItem.EVENT_NO);
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

                result = true;
                Messenger.Default.Send<object>(tempSelectIndex, EnumMessageKey.ResetOperationMedNoteControlFocus);
            }
            else
            {
                this.ShowMessageBox("当前选中项为空，请重新操作！", MessageBoxButton.OK, MessageBoxImage.Information);
                Messenger.Default.Send<object>(this, EnumMessageKey.ResetOperationMedNoteControlFocus);
            }

            return result;
        }

        /// <summary>
        /// 新增事件
        /// </summary>
        /// <returns></returns>
        protected override bool InsertData()
        {
            bool result = true;
            Messenger.Default.Send<object>(this, EnumMessageKey.ResetOperationMedNoteControlFocus);
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

            // 设置选中到最后一项
            if (this.AnesEvent.Count > 0)
            {
                this.SelectedIndex = this.AnesEvent.Count - 1;
            }
        }

        #region Commands

        /// <summary>
        /// 左侧用药栏的单击显示常用量事件
        /// </summary>
        public ICommand LeftDrugClick
        {
            get
            {
                return new RelayCommand<MED_EVENT_DICT>(data =>
                {
                    if (null != data)
                    {
                        DrugDictExtData = ApplicationModel.Instance.AllDictList.EventDictExtList.Where(x => x.EVENT_CLASS_CODE == data.EVENT_CLASS_CODE &&
                                                                                                            x.EVENT_ITEM_CODE == data.EVENT_ITEM_CODE).ToList();
                    }
                });
            }
        }

        /// <summary>
        /// 左侧用药栏双击直接添加到用药栏中
        /// </summary>
        public ICommand LeftDrugDoubleClick
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
                        if (isFirstAdd)
                        {
                            newAnesEvent.START_TIME = DateTime.Now;
                            isFirstAdd = false;
                        }
                        else
                        {
                            DateTime tempDt = AnesEvent.Count > 0 ? (DateTime)AnesEvent.Last<MED_ANESTHESIA_EVENT>().START_TIME : DateTime.Now;
                            newAnesEvent.START_TIME = tempDt;
                        }
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
                    }
                    else
                    {
                        ShowMessageBox("术后患者或非当前手术间患者，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                });
            }
        }

        /// <summary>
        /// 常用量单击添加到用药栏中
        /// </summary>
        public ICommand RefenceDosageClick
        {
            get
            {
                return new RelayCommand<MED_EVENT_DICT_EXT>(data =>
                {
                    if (ExtendAppContext.Current.IsModify && ExtendAppContext.Current.IsPermission)
                    {
                        MED_EVENT_DICT drugItem = DrugDictData.Find(delegate(MED_EVENT_DICT item)
                        {
                            return item.EVENT_CLASS_CODE == data.EVENT_CLASS_CODE && item.EVENT_ITEM_CODE == data.EVENT_ITEM_CODE;
                        });
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
                        newAnesEvent.EVENT_ITEM_NAME = drugItem.EVENT_ITEM_NAME;
                        newAnesEvent.EVENT_ITEM_CODE = data.EVENT_ITEM_CODE;
                        newAnesEvent.EVENT_ITEM_SPEC = drugItem.EVENT_ITEM_SPEC;
                        newAnesEvent.DOSAGE = data.STANDARD_DOSAGE;
                        newAnesEvent.DOSAGE_UNITS = data.DOSAGE_UNITS;
                        newAnesEvent.ADMINISTRATOR = drugItem.ADMINISTRATOR;
                        if (isFirstAdd)
                        {
                            newAnesEvent.START_TIME = DateTime.Now;
                            isFirstAdd = false;
                        }
                        else
                        {
                            DateTime tempDt = AnesEvent.Count > 0 ? (DateTime)AnesEvent.Last<MED_ANESTHESIA_EVENT>().START_TIME : DateTime.Now;
                            newAnesEvent.START_TIME = tempDt;
                        }
                        newAnesEvent.END_TIME = null;
                        newAnesEvent.DURATIVE_INDICATOR = drugItem.DURATIVE_INDICATOR;
                        newAnesEvent.PERFORM_SPEED = data.STANDARD_SPEED;
                        newAnesEvent.SPEED_UNIT = data.SPEED_UNITS;
                        newAnesEvent.EVENT_ATTR = drugItem.EVENT_ATTR;
                        newAnesEvent.CONCENTRATION = data.STANDARD_CONCENTRATION;
                        newAnesEvent.CONCENTRATION_UNIT = data.CONCENTRATION_UNIT;
                        newAnesEvent.SUPPLIER_NAME = drugItem.SUPPLIER_NAME;
                        newAnesEvent.ModelStatus = ModelStatus.Add;
                        AnesEvent.Add(newAnesEvent);
                        tmpAnesEvent.Add(newAnesEvent);

                        SetEventSortValue(newAnesEvent);
                    }
                    else
                    {
                        ShowMessageBox("术后患者或非当前手术间患者，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    DrugDictData = tmpDrugDictData.Where(x => x.EventNamePY.Contains(key.Trim().ToUpper())
                        || x.EVENT_ITEM_NAME.Contains(key.Trim())).ToList();
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
                    if (!this.IsChangeOperEventing)
                    {
                        DrugDictData = tmpDrugDictData.Where(x => x.EventNamePY.Contains(key.Trim().ToUpper()) || 
                                                                  x.EVENT_ITEM_NAME.Contains(key.Trim())).ToList();
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
        #endregion
    }
}
