//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationCanceledViewModel.cs
//功能描述(Description)：    手术取消
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:19:46
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class OperationCanceledViewModel : BaseViewModel
    {
        private ICommand btnCancelCommand = null;                                                       // 取消按钮命令
        private ICommand btnOKCommand = null;                                                           // 确定按钮命令
        private ICommand rbChangedCanceledTypeCommand = null;                                           // 切换手术取消分类
        private PatientModel curPatientModel = null;                                                    // 当前选中的患者信息
        private List<MED_OPERATING_ROOM> medOperatingRoomDict = null;                                   // 手术间字典
        private string operRoomNo = null;                                                               // 选中的手术间号
        private string strReason = string.Empty;                                                        // 取消原因
        private RichTextBox rtbResaon = null;                                                           // 界面中的原因富文本框，由于不能直接绑定，所以把控件传到VM中
        private List<OperationCanceledTypeModel> allOperCanceledTypeList = new List<OperationCanceledTypeModel>();  // 所有取消分类信息
        private List<OperationCanceledTypeModel> curOperCanceledTypeList = new List<OperationCanceledTypeModel>();  // 当前显示的取消分类

        /// <summary>
        /// 当前正在手术的患者信息
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
        /// 取消按钮命令
        /// </summary>
        public ICommand BtnCancelCommand
        {
            get { return this.btnCancelCommand; }
            set { this.btnCancelCommand = value; }
        }

        /// <summary>
        /// 确定按钮命令
        /// </summary>
        public ICommand BtnOKCommand
        {
            get { return this.btnOKCommand; }
            set { this.btnOKCommand = value; }
        }

        /// <summary>
        /// 取消类型切换
        /// </summary>
        public ICommand RbChangedCanceledTypeCommand
        {
            get { return this.rbChangedCanceledTypeCommand; }
            set { this.rbChangedCanceledTypeCommand = value; }
        }

        /// <summary>
        ///  手术间字典绑定
        /// </summary>
        public List<MED_OPERATING_ROOM> MedOperatingRoomDict
        {
            get
            {
                this.medOperatingRoomDict = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE.Equals(ExtendAppContext.Current.OperDeptCode) &&
                                                                                                         x.BED_TYPE.Equals(ExtendAppContext.Current.EventNo)).ToList();
                return this.medOperatingRoomDict;
            }
            set
            {
                this.medOperatingRoomDict = value;
                RaisePropertyChanged("MedOperatingRoomDict");
            }
        }

        /// <summary>
        /// 手术间号
        /// </summary>
        public string OperRoomNo
        {
            get
            {
                return this.operRoomNo;
            }
            set
            {
                this.operRoomNo = value;
                RaisePropertyChanged("OperRoomNo");
            }
        }

        /// <summary>
        /// 当前显示的取消分类
        /// </summary>
        public List<OperationCanceledTypeModel> CurOperCanceledTypeList
        {
            get { return this.curOperCanceledTypeList; }
            set
            {
                this.curOperCanceledTypeList = value;
                this.RaisePropertyChanged("CurOperCanceledTypeList");
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationCanceledViewModel(MED_PAT_INFO patModel, RichTextBox rtb)
        {
            if (patModel != null)
            {
                this.CurPatientModel = PatientModel.CreateModel(patModel);
                this.MedOperatingRoomDict = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE.Equals(ExtendAppContext.Current.OperDeptCode) &&
                                                                                                         x.BED_TYPE.Equals(ExtendAppContext.Current.EventNo)).ToList();
                this.OperRoomNo = ExtendAppContext.Current.OperRoomNo;
                this.rtbResaon = rtb;
                // 设置列表信息
                this.ResetOperCancelTypeList("医院因素");
                // 注册按钮命令
                this.RegisterCommand();
            }
        }

        /// <summary>
        /// 设置取消手术列表信息
        /// </summary>
        private void ResetOperCancelTypeList(string itemClass)
        {
            if (this.allOperCanceledTypeList.Count == 0)
            {
                List<MED_ANESTHESIA_INPUT_DICT> tempList = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS.Equals("患者因素") || x.ITEM_CLASS.Equals("医院因素") || x.ITEM_CLASS.Equals("医护因素")).ToList();
                if (null != tempList && tempList.Count > 0)
                {
                    foreach (MED_ANESTHESIA_INPUT_DICT item in tempList)
                    {
                        this.allOperCanceledTypeList.Add(new OperationCanceledTypeModel(false, item.ITEM_CLASS, item.ITEM_NAME));
                    }
                }
            }
            this.CurOperCanceledTypeList = this.allOperCanceledTypeList.Where(x => x.ItemClass.Equals(itemClass)).ToList();
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        public void RegisterCommand()
        {
            // 取消按钮命令
            this.BtnCancelCommand = new RelayCommand<string>(par =>
            {
                this.CloseContentWindow();
            });

            // 确定按钮命令
            this.BtnOKCommand = new RelayCommand<object>(par =>
            {
                PublicKeyBoardMessage(KeyCode.AppCode.Save);
            });

            // 切换取消手术类别
            this.RbChangedCanceledTypeCommand = new RelayCommand<string>(par =>
            {
                this.ResetOperCancelTypeList(par);
            });
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        protected override bool CheckData()
        {
            bool result = true;

            if (null != this.rtbResaon)
            {
                TextRange tr = new TextRange(this.rtbResaon.Document.ContentStart, this.rtbResaon.Document.ContentEnd);
                this.strReason = tr.Text;
            }

            if (result && (this.strReason.Trim().Equals("\r\n") || string.IsNullOrEmpty(this.strReason.Trim())))
            {
                this.ShowMessageBox("手术取消原因不能为空，请输入！", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            if (result && this.allOperCanceledTypeList.Where(x => x.IsChecked).ToList().Count == 0)
            {
                this.ShowMessageBox("手术取消分类必须有选中项，请重新勾选！", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            TransactionParamsters tp = TransactionParamsters.Create();

            // 保存手术取消记录
            this.SaveOperationCanceled(ref tp);
            // 更新主表的手术状态
            this.SaveOperationMaster(ref tp);
            // 更新手术室数据
            this.SaveOperatingRoom(ref tp);
            // 更新监护仪数据
            this.SaveMonitorDict(ref tp);

            // 使用事务批量更新数据
            bool result = CommonService.ClientInstance.UpdateByTransaction(tp.ToString());

            // 刷新主界面信息
            Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);

            // 更新手术间字典表
            ApplicationModel.Instance.AllDictList.OperatingRoomList = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();

            return result ? SaveResult.Success : SaveResult.Fail;
        }

        /// <summary>
        /// 保存主表数据信息
        /// </summary>
        private void SaveOperationMaster(ref TransactionParamsters tp)
        {
            MED_OPERATION_MASTER master = AnesInfoService.ClientInstance.GetOperationMaster(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            master.OPER_STATUS_CODE = (int)OperationStatus.CancelOperation;
            master.ModelStatus = ModelStatus.Modeified;
            tp.Append(master);
        }

        /// <summary>
        /// 保存监护仪字典信息
        /// </summary>
        private void SaveMonitorDict(ref TransactionParamsters tp)
        {
            List<MED_MONITOR_DICT> tempMonitorDict = ApplicationModel.Instance.AllDictList.MonitorDictList.
                                                            Where(x => x.WARD_TYPE.ToString() == ExtendAppContext.Current.EventNo &&
                                                                       x.BED_NO == ExtendAppContext.Current.OperRoomNo).ToList();
            if (tempMonitorDict != null && tempMonitorDict.Count > 0)
            {
                foreach (MED_MONITOR_DICT row in tempMonitorDict)
                {
                    row.PATIENT_ID = string.Empty;
                    row.VISIT_ID = null;
                    row.OPER_ID = null;
                    row.ModelStatus = ModelStatus.Modeified;
                }

                tp.Append(tempMonitorDict);
            }
        }

        /// <summary>
        /// 保存手术间字典数据信息
        /// </summary>
        private void SaveOperatingRoom(ref TransactionParamsters tp)
        {
            foreach (MED_OPERATING_ROOM room in this.MedOperatingRoomDict)
            {
                // 将患者信息写入到新的手术间
                if (room.ROOM_NO.Equals(this.OperRoomNo))
                {
                    room.PATIENT_ID = string.Empty;
                    room.VISIT_ID = null;
                    room.OPER_ID = null;
                    room.ModelStatus = ModelStatus.Modeified;
                    tp.Append(room);
                    break;
                }
            }
        }

        /// <summary>
        /// 保存取消手术明细
        /// </summary>
        /// <returns></returns>
        private void SaveOperationCanceledDetail(int cancelID, ref TransactionParamsters tp)
        {
            List<MED_OPERATION_CANCELED_DETAIL> list = CommonService.ClientInstance.GetOperationCanceledDetail(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, cancelID);
            foreach (OperationCanceledTypeModel item in this.allOperCanceledTypeList)
            {
                if (item.IsChecked)
                {
                    MED_OPERATION_CANCELED_DETAIL newRow = new MED_OPERATION_CANCELED_DETAIL();
                    newRow.PATIENT_ID = this.CurPatientModel.PatientID;
                    newRow.VISIT_ID = this.CurPatientModel.VisitID;
                    newRow.CANCEL_ID = cancelID;
                    newRow.CANCEL_CLASS = item.ItemClass;
                    newRow.CANCEL_TYPE = item.ItemName;
                    newRow.ModelStatus = ModelStatus.Add;
                    list.Add(newRow);
                }
            }

            tp.Append(list);
        }

        /// <summary>
        /// 保存手术取消记录数据
        /// </summary>
        private void SaveOperationCanceled(ref TransactionParamsters tp)
        {
            MED_OPERATION_SCHEDULE scheduled = AnesInfoService.ClientInstance.GetOperSchedule(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            List<MED_OPERATION_CANCELED> list = CommonService.ClientInstance.GetOperationCanceled(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID);
            MED_OPERATION_CANCELED newRow = new MED_OPERATION_CANCELED();
            newRow.PATIENT_ID = this.CurPatientModel.PatientID;
            newRow.VISIT_ID = this.CurPatientModel.VisitID;
            newRow.CANCEL_ID = list.Count + 1;
            newRow.SCHEDULE_ID = null != scheduled ? scheduled.SCHEDULE_ID : 1;
            newRow.OPER_ID = this.CurPatientModel.OperID;
            newRow.OPER_STATUS_CODE = (int)this.CurPatientModel.OperStatusCode;
            newRow.CANCEL_REASON = this.strReason;
            newRow.CANCEL_DATE = DateTime.Now;
            newRow.CANCEL_BY = string.Empty;
            newRow.ENTERED_BY = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
            newRow.ModelStatus = ModelStatus.Add;
            list.Add(newRow);

            tp.Append(list);
            this.SaveOperationCanceledDetail(newRow.CANCEL_ID, ref tp);
        }
    }
}
