//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnesFreeViewModel.cs
// 功能描述(Description)：    麻醉计费对应的ViewModel
// 数据表(Tables)：		      
// 作者(Author)：             许文龙
// 日期(Create Date)：        2018-03-06 10:22:48
// R1:
//     修改作者:
//     修改日期:
//     修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    /// <summary>
    /// 麻醉计费的ViewModel
    /// </summary>
    public class AnesFreeViewModel : BaseViewModel
    {
        private PatientModel curPatientModel = null;                                // 当前检验信息的患者信息
        private string strAnesTimeLength = string.Empty;                           // 麻醉时长  
        private ObservableCollection<MED_ANES_VALUATION_LIST> valuationList = null;     //病人计价单
        private ObservableCollection<MED_ANES_VALUATION_LIST> tmpValuationList;         // 病人计价单缓存表
        private MED_ANES_VALUATION_LIST _selectItem = null;
        List<MED_CHARGE_VS_EVENT> chargeList = null;    //当前患者事件表里课收费的项目
        private List<MED_BILL_ITEM_CLASS_DICT> billDict = null;//收费项目分类表
        private List<MED_VALUATION_ITEM_LIST> valuationItemList = null; //计价单项目表 
        private string[] vitalSignTitle = null;//体征检测项目

        private ICommand refreshCommon = null;                                     // 更新命令
        private ICommand insertCommon = null;                                       // 新增命令
        private ICommand userTemplateCommon = null;                                // 套用模板命令
        private ICommand saveTemplateCommon = null;     //保存模板命令
        private ICommand saveCommon = null;                                        // 保存数据命令
        private ICommand submitCommon = null;                                               // 提交命令 
        private ICommand deleteItemClick = null;                 //删除选中行命令 
        private bool isAddEnabled = false;
        private bool isInsertEnabled = true;
        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _eventNo;
        /// <summary>
        /// 当前检验信息的患者信息
        /// </summary>
        public PatientModel CurPatientModel
        {
            get { return this.curPatientModel; }
            set
            {
                this.curPatientModel = value;
                this.RaisePropertyChanged("CurPatientModel");
            }
        }

        /// <summary>
        /// 麻醉时长
        /// </summary>
        public string StrAnesTimeLength
        {
            get { return this.strAnesTimeLength; }
            set
            {
                this.strAnesTimeLength = value;
                this.RaisePropertyChanged("StrAnesTimeLength");
            }
        }
        /// <summary>
        /// 病人计价单表
        /// </summary>
        public ObservableCollection<MED_ANES_VALUATION_LIST> ValuationList
        {
            get { return this.valuationList; }
            set
            {
                this.valuationList = value;
                this.RaisePropertyChanged("ValuationList");
            }
        }
        /// <summary>
        /// 选中某行
        /// </summary>
        public MED_ANES_VALUATION_LIST SelectItem
        {
            get { return this._selectItem; }
            set
            {
                this._selectItem = value;
                this.RaisePropertyChanged("SelectItem");
            }
        }
        /// <summary>
        ///收费项目分类表
        /// </summary>
        public List<MED_BILL_ITEM_CLASS_DICT> BillDict
        {
            get { return this.billDict; }
            set
            {
                this.billDict = value;
                this.RaisePropertyChanged("BillDict");
            }
        }


        /// <summary>
        /// 计价单项目表
        /// </summary>
        public List<MED_VALUATION_ITEM_LIST> ValuationItemList
        {
            get { return this.valuationItemList; }
            set
            {
                this.valuationItemList = value;
                this.RaisePropertyChanged("ValuationItemList");
            }
        }

        public bool IsAddEnabled
        {
            get { return this.isAddEnabled; }
            set
            {
                this.isAddEnabled = value;
                this.RaisePropertyChanged("IsAddEnabled");
            }
        }
        //IsInsertEnabled
        public bool IsInsertEnabled
        {
            get { return this.isInsertEnabled; }
            set
            {
                this.isInsertEnabled = value;
                this.RaisePropertyChanged("IsInsertEnabled");
            }
        }
        /// <summary>
        /// 更新命令
        /// </summary>
        public ICommand RefreshCommon
        {
            get { return this.refreshCommon; }
            set { this.refreshCommon = value; }
        }

        /// <summary>
        /// 新增命令
        /// </summary>
        public ICommand InsertCommon
        {
            get { return this.insertCommon; }
            set { this.insertCommon = value; }
        }

        /// <summary>
        /// 套用模板命令
        /// </summary>
        public ICommand UserTemplateCommon
        {
            get { return this.userTemplateCommon; }
            set { this.userTemplateCommon = value; }
        }
        /// <summary>
        /// 保存模板命令
        /// </summary>
        public ICommand SaveTemplateCommon
        {
            get { return this.saveTemplateCommon; }
            set { this.saveTemplateCommon = value; }
        }
        /// <summary>
        /// 保存数据命令
        /// </summary>
        public ICommand SaveCommon
        {
            get { return this.saveCommon; }
            set { this.saveCommon = value; }
        }

        /// <summary>
        /// 提交命令
        /// </summary>
        public ICommand SubmitCommon
        {
            get { return this.submitCommon; }
            set { this.submitCommon = value; }
        }

        /// <summary>
        /// 删除选中行命令
        /// </summary>
        public ICommand DeleteItemClickCommon
        {
            get { return this.deleteItemClick; }
            set { this.deleteItemClick = value; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public AnesFreeViewModel(MED_PAT_INFO patModel)
        {
            this.RegisterCommand();
            this.CurPatientModel = PatientModel.CreateModel(patModel);
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            _eventNo = "0";
            // 计算麻醉时长
            if (this.CurPatientModel.AnesStartTime != DateTime.MinValue && this.CurPatientModel.AnesEndTime != DateTime.MinValue)
            {
                TimeSpan ts = this.CurPatientModel.AnesEndTime - this.CurPatientModel.AnesStartTime;
                this.StrAnesTimeLength = string.Format("{0}小时{1}分", ts.Hours, ts.Minutes);
            }
            BillDict = ApplicationModel.Instance.AllDictList.BillItemClassDictList.Where(x => x.TYPE == "0").ToList();
            ValuationItemList = ChargeInfoService.ClientInstance.GetValuationItemList();
            vitalSignTitle = AnesInfoService.ClientInstance.GetVitalSignTitles(_patientID, _visitID, _operID, _eventNo, ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO);
            List<MED_ANES_VALUATION_LIST> lists = ChargeInfoService.ClientInstance.GetValuationList(_patientID, _visitID, _operID);
            foreach (MED_ANES_VALUATION_LIST row in lists)
            {
                row.ITEM_CLASS_NAME = billDict.Where(x => x.BILL_CLASS_CODE == row.ITEM_CLASS).FirstOrDefault().BILL_CLASS_NAME;
            }
            valuationList = new ObservableCollection<MED_ANES_VALUATION_LIST>(lists);
            tmpValuationList = valuationList;
            this.ValuationList = new ObservableCollection<MED_ANES_VALUATION_LIST>(valuationList);
            if (this.ValuationList.Count > 0)
                IsAddEnabled = true;
            foreach (MED_ANES_VALUATION_LIST row in ValuationList)
            {
                if (row.STATUS.HasValue && row.STATUS == 2) { IsInsertEnabled = false; IsAddEnabled = false; }
            }
        }
        /// <summary>
        /// 更新事件表数据
        /// </summary>
        /// 

        private void UpdateAnesEventInfo()
        {
            chargeList = ChargeInfoService.ClientInstance.GetChargeEventInfo(_patientID, _visitID, _operID);
            foreach (MED_CHARGE_VS_EVENT charge in chargeList)
            {
                MED_ANES_VALUATION_LIST valuation = AddNewInfo(charge, 1);
                if (valuation != null)
                {
                    valuationList.Add(valuation);
                    tmpValuationList.Add(valuation);
                }
            }
            ValuationList = valuationList;
        }
        /// <summary>
        /// 新增一行
        /// </summary>
        private MED_ANES_VALUATION_LIST AddNewInfo(MED_CHARGE_VS_EVENT charge, int method)
        {
            MED_ANES_VALUATION_LIST newRow;
            if (charge != null)
            {
                MED_ANES_VALUATION_LIST valuation = null;
                if (valuationList.Count > 0)
                    valuation = valuationList.Where(x => x.ITEM_CODE == charge.ITEM_CODE && x.ITEM_CLASS == charge.ITEM_CALSS).FirstOrDefault();
                if (valuation == null)
                {
                    valuation = new MED_ANES_VALUATION_LIST();
                    valuation.PATIENT_ID = _patientID;
                    valuation.VISIT_ID = _visitID;
                    valuation.OPER_ID = _operID;
                    valuation.VALUATION_NO = valuationList.Count + 1;
                    valuation.ITEM_CLASS = charge.ITEM_CALSS;
                    valuation.ITEM_CODE = charge.ITEM_CODE;
                    valuation.ITEM_NAME = charge.ITEM_NAME;
                    valuation.ITEM_CLASS_NAME = charge.ITEM_CLASS_NAME;
                    valuation.ITEM_SPEC = charge.ITEM_SPEC;
                    valuation.DOSAGE = charge.DOSAGE;
                    valuation.AMOUNT = charge.AMOUNT;
                    valuation.UNITS = charge.UNITS;
                    valuation.AMOUNT = 1;
                    valuation.STATUS = 0;
                    valuation.METHOD = method;
                    valuation.TECHNICIAN = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                    valuation.ORDERED_BY = ExtendAppContext.Current.LoginUser.USER_DEPT_CODE;
                    valuation.BILLING_DATE_TIME = DateTime.Now;
                    newRow = valuation;
                }
                else
                    newRow = null;
            }
            else
            {
                newRow = new MED_ANES_VALUATION_LIST();
                newRow.PATIENT_ID = _patientID;
                newRow.VISIT_ID = _visitID;
                newRow.OPER_ID = _operID;
                newRow.VALUATION_NO = valuationList.Count + 1;
                newRow.ITEM_CLASS = "";
                newRow.ITEM_CODE = "";
                newRow.STATUS = 0;
                newRow.AMOUNT = 1;
                newRow.METHOD = method;
                newRow.TECHNICIAN = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                newRow.ORDERED_BY = ExtendAppContext.Current.LoginUser.USER_DEPT_CODE;
                newRow.BILLING_DATE_TIME = DateTime.Now;
            }
            return newRow;
        }
        /// <summary>
        /// 类型改变事件
        /// </summary>
        public void TypeChange(string itemClass)
        {
            ValuationItemList = ChargeInfoService.ClientInstance.GetValuationItemList().Where(x => x.ITEM_CLASS == itemClass).ToList();
        }
        /// <summary>
        /// 项目改变事件
        /// </summary>
        public void ChargItemChange(MED_VALUATION_ITEM_LIST row)
        {
            if (SelectItem != null)
            {
                SelectItem.ITEM_CLASS = row.ITEM_CLASS;
                SelectItem.ITEM_SPEC = row.ITEM_SPEC;
                SelectItem.ITEM_NAME = row.ITEM_NAME;
                SelectItem.ITEM_CODE = row.ITEM_CODE;
                SelectItem.UNITS = row.UNITS;
                SelectItem.AMOUNT = 1;
            }
        }
        /// <summary>
        /// 注册命令信息
        /// </summary>
        private void RegisterCommand()
        {
            // 更新命令：将现有的数据直接清空，根据患者用药信息自动获取最新的数据
            this.RefreshCommon = new RelayCommand<object>(par =>
            {
                UpdateAnesEventInfo();
            });

            // 新增命令：再最后一行新增数据行
            this.InsertCommon = new RelayCommand<object>(par =>
            {
                MED_ANES_VALUATION_LIST valuation = AddNewInfo(null, 3);
                if (valuation != null)
                {
                    IsAddEnabled = true;
                    valuationList.Add(valuation);
                    tmpValuationList.Add(valuation);
                }
            });

            // 套用模板：左侧显示模板列表，确认模板后将模板数据追加到计费列表后
            this.UserTemplateCommon = new RelayCommand<object>(par =>
            {
                var message = new ShowContentWindowMessage("ChargeTempletControl", "收费模板");
                message.Height = 800;
                message.Width = 700;
                message.CallBackCommand = CallChatgeTemplet;
                Messenger.Default.Send<ShowContentWindowMessage>(message);
            });
            // 保存模板
            this.SaveTemplateCommon = new RelayCommand<object>(par =>
            {
                var message = new ShowContentWindowMessage("ChargeTemplateMethodControl", "收费模板名称");
                message.Height = 220;
                message.Width = 500;
                message.CallBackCommand = CallSaveTemplet;
                Messenger.Default.Send<ShowContentWindowMessage>(message);
            });
            //删除行命令
            this.DeleteItemClickCommon = new RelayCommand<MED_ANES_VALUATION_LIST>(data =>
            {
                if (null != data)
                {
                    if (data.ModelStatus != ModelStatus.Add)
                    {
                        data.ModelStatus = ModelStatus.Deleted;
                        ValuationList.Remove(data);
                    }
                    else
                    {
                        data.ModelStatus = ModelStatus.Deleted;
                        tmpValuationList.Remove(data);
                        ValuationList.Remove(data);
                    }
                }
            });
            // 保存命令：将现有数据保存到数据库
            this.SaveCommon = new RelayCommand<object>(par =>
            {
                bool con = true;
                foreach (MED_ANES_VALUATION_LIST row in tmpValuationList)
                {
                    if (row.ModelStatus != ModelStatus.Deleted)
                    {
                        if (string.IsNullOrEmpty(row.ITEM_CLASS) || string.IsNullOrEmpty(row.ITEM_NAME) || !row.AMOUNT.HasValue)
                        {
                            ShowMessageBox("类别、项目名称、数量不能为空", MessageBoxButton.OK, MessageBoxImage.Information);
                            con = false;
                            break;
                        }
                    }
                }
                if (con)
                {
                    bool result = ChargeInfoService.ClientInstance.SaveValuationList(new List<MED_ANES_VALUATION_LIST>(tmpValuationList));
                    if (result)
                    {
                        ShowMessageBox("保存成功", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    foreach (var item in tmpValuationList)
                    {
                        if (item.ModelStatus != ModelStatus.Deleted)
                            item.ModelStatus = ModelStatus.Default;
                    }
                }

            });

            // 提交命令：将现有数据提交，提交后的数据不能更改。提交前弹出确认框，再录入用户名和密码验证成功后才可提交
            this.SubmitCommon = new RelayCommand<object>(par =>
            {
                bool result = true;
                List<MED_ANES_VALUATION_LIST> anesList = new List<MED_ANES_VALUATION_LIST>(ValuationList);
                foreach (MED_ANES_VALUATION_LIST anes in anesList)
                {
                    if (anes.ModelStatus != ModelStatus.Deleted)
                    {
                        if (string.IsNullOrEmpty(anes.ITEM_CLASS) || string.IsNullOrEmpty(anes.ITEM_NAME))
                        {
                            ShowMessageBox("类别、项目名称、数量不能为空", MessageBoxButton.OK, MessageBoxImage.Information);
                            result = false;
                            break;
                        }
                        if (!anes.AMOUNT.HasValue)
                        {
                            result = false;
                            ShowMessageBox(anes.ITEM_NAME + "的数量不能为空，请填写数量。", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    }
                }
                if (result)
                {
                    var message = new ShowContentWindowMessage("ChargeSubmitControl", "确认提交");
                    message.Height = 400;
                    message.Width = 400;
                    message.CallBackCommand = CallSubmit;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                }
            });
        }
        #region 命令
        /// <summary>
        /// 增加确认提交返回值
        /// </summary>
        public ICommand CallSubmit
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    if (key != null && !string.IsNullOrEmpty(key))
                    {
                        List<MED_ANES_VALUATION_LIST> anesList = new List<MED_ANES_VALUATION_LIST>(ValuationList);
                        foreach (MED_ANES_VALUATION_LIST anes in anesList)
                        {
                            if (anes.ModelStatus != ModelStatus.Deleted)
                            {
                                anes.STATUS = 1;
                                anes.TECHNICIAN = key;
                                anes.BILLING_DATE_TIME = DateTime.Now;
                                anes.ModelStatus = ModelStatus.Modeified;
                            }
                        }
                        bool result = ChargeInfoService.ClientInstance.SaveValuationList(anesList);
                        if (result)
                            ShowMessageBox("数据提交成功。", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }
        /// <summary>
        /// 保存模板返回值
        /// </summary>
        public ICommand CallSaveTemplet
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    if (key != null && ValuationList.Count > 0)
                    {
                        List<MED_ANES_VALUATION_LIST> anesList = new List<MED_ANES_VALUATION_LIST>(ValuationList);
                        List<MED_ANES_BILL_TEMPLET> templetList = ChargeInfoService.ClientInstance.GetBillTempletList(key.templetType, key.name);
                        int number = 0;
                        foreach (MED_ANES_BILL_TEMPLET row in templetList)
                        {
                            if (row.ITEM_NO.HasValue && row.ITEM_NO > number)
                            {
                                number = Convert.ToInt32(row.ITEM_NO);
                            }
                        }
                        foreach (MED_ANES_VALUATION_LIST row in anesList)
                        {
                            if (row.ModelStatus != ModelStatus.Deleted)
                            {
                                MED_ANES_BILL_TEMPLET templet = new MED_ANES_BILL_TEMPLET();
                                templet.TEMPLET = key.name;
                                templet.ANESTHESIA_METHOD = key.templetType;
                                templet.ITEM_NO = number + 1;
                                templet.ITEM_CLASS = row.ITEM_CLASS;
                                templet.ITEM_CODE = row.ITEM_CODE;
                                templet.ITEM_NAME = row.ITEM_NAME;
                                templet.ITEM_SPEC = row.ITEM_SPEC;
                                templet.UNITS = row.UNITS;
                                templet.AMOUNT = row.AMOUNT;
                                templetList.Add(templet);
                                number++;
                            }
                        }
                        if (ChargeInfoService.ClientInstance.SaveBillTempletList(templetList))
                            ShowMessageBox("模板保存成功。", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }
        /// <summary>
        /// 套用模板返回值
        /// </summary>
        public ICommand CallChatgeTemplet
        {
            get
            {
                return new RelayCommand<List<MED_ANES_BILL_TEMPLET>>(key =>
                {
                    if (null != key)
                    {
                        List<MED_ANES_BILL_TEMPLET> templetList = key;
                        foreach (MED_ANES_BILL_TEMPLET row in templetList)
                        {
                            MED_ANES_VALUATION_LIST valuation = new MED_ANES_VALUATION_LIST();
                            valuation.PATIENT_ID = _patientID;
                            valuation.VISIT_ID = _visitID;
                            valuation.OPER_ID = _operID;
                            valuation.VALUATION_NO = ValuationList.Count + 1;
                            valuation.ITEM_CLASS = row.ITEM_CLASS;
                            valuation.ITEM_CODE = row.ITEM_CODE;
                            valuation.ITEM_NAME = row.ITEM_NAME;
                            valuation.ITEM_CLASS_NAME = row.ITEM_CLASS_NAME;
                            valuation.ITEM_SPEC = row.ITEM_SPEC;
                            valuation.AMOUNT = row.AMOUNT.HasValue ? row.AMOUNT : 1;
                            valuation.UNITS = row.UNITS;
                            valuation.STATUS = 0;
                            valuation.METHOD = 2;
                            valuation.TECHNICIAN = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                            valuation.ORDERED_BY = ExtendAppContext.Current.LoginUser.USER_DEPT_CODE;
                            valuation.BILLING_DATE_TIME = DateTime.Now;
                            ValuationList.Add(valuation);
                            tmpValuationList.Add(valuation);
                        }
                        IsAddEnabled = true;
                    }

                });
            }

        }
        #endregion

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            SaveResult saveResult = SaveResult.Fail;
            bool result = ChargeInfoService.ClientInstance.SaveValuationList(new List<MED_ANES_VALUATION_LIST>(tmpValuationList));
            if (result)
            {
                saveResult = SaveResult.Success;
            }

            foreach (var item in tmpValuationList)
            {
                item.ModelStatus = ModelStatus.Default;
            }

            return saveResult;
        }
    }
}
