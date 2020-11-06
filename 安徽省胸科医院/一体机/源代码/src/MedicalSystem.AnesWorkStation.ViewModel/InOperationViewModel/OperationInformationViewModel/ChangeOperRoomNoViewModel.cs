//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      ChangeOperRoomNoViewModel.cs
//功能描述(Description)：    切换手术间
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-26 16:12:56
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
    public class ChangeOperRoomNoViewModel : BaseViewModel
    {
        private ICommand btnCancelCommand = null;                                                       // 取消按钮命令
        private ICommand btnOKCommand = null;                                                           // 确定按钮命令
        private ICommand cbSelectionChanged = null;                                                     // 手术间下拉框更改事件命令
        private PatientModel curPatientModel = null;                                                    // 当前选中的患者信息
        private List<MED_OPERATING_ROOM> medOperatingRoomDict = null;                                   // 手术间字典
        private List<MED_OPERATING_ROOM> cbOperatingRoomSourceList = null;                              // 界面中的手术间数据源
        private string operRoomNo = null;                                                               // 选中的手术间号
        string strReason = string.Empty;
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
        /// 手术间下拉更改事件命令
        /// </summary>
        public ICommand CbSelectionChanged
        {
            get { return this.cbSelectionChanged; }
            set { this.cbSelectionChanged = value; }
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
        ///  界面中的手术间数据源
        /// </summary> 
        public List<MED_OPERATING_ROOM> CbOperatingRoomSourceList
        {
            get
            {
                return this.cbOperatingRoomSourceList;
            }
            set
            {
                this.cbOperatingRoomSourceList = value;
                this.RaisePropertyChanged("CbOperatingRoomSourceList");
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
        /// 构造方法
        /// </summary>
        public ChangeOperRoomNoViewModel(MED_PAT_INFO patModel)
        {
            if (patModel != null)
            {
                this.CurPatientModel = PatientModel.CreateModel(patModel);
                this.MedOperatingRoomDict = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE.Equals(ExtendAppContext.Current.OperDeptCode) &&
                                                                                                         x.BED_TYPE.Equals(ExtendAppContext.Current.EventNo)).ToList();
                this.CbOperatingRoomSourceList = new List<MED_OPERATING_ROOM>(this.MedOperatingRoomDict);
                //this.CbOperatingRoomSourceList = this.MedOperatingRoomDict.Where(x => x.BED_TYPE == ExtendAppContext.Current.EventNo && (x.PATIENT_ID == null || string.IsNullOrEmpty(x.PATIENT_ID)))
                //    .OrderBy(t => t.SORT_NO).ToList();
                // 注册按钮命令
                this.RegisterCommand();
            }
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
                bool isModify = ExtendAppContext.Current.IsModify;
                bool isPress = ExtendAppContext.Current.IsPermission;
                ExtendAppContext.Current.IsModify = true;
                ExtendAppContext.Current.IsPermission = true;
                RichTextBox rtb = par as RichTextBox;
                TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                strReason = tr.Text;
                PublicKeyBoardMessage(KeyCode.AppCode.Save);
                ExtendAppContext.Current.IsModify = isModify;
                ExtendAppContext.Current.IsPermission = isPress;
            });

            this.CbSelectionChanged = new RelayCommand<object>(par =>
            {
                ComboBox cb = par as ComboBox;
                if (!this.CheckNewRoomNo(cb.SelectedValue.ToString()))
                {

                }
            });
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = true;
            if (null == this.OperRoomNo || string.IsNullOrEmpty(this.OperRoomNo.ToString()))
            {
                this.ShowMessageBox("目标手术间不能为空，请重新输入。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else if (this.CurPatientModel.OperRoomNo.Equals(this.OperRoomNo))
            {
                this.ShowMessageBox("更换后的手术间不能和当前手术间一致，请重新输入。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            //else if (!this.CheckNewRoomNo(this.OperRoomNo))
            //{
            //    result = false;
            //}
            else if (strReason.Equals("\r\n"))
            {
                this.ShowMessageBox("更换手术间原因不能为空，请输入。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            MED_OPERATION_MASTER master = AnesInfoService.ClientInstance.GetOperationMaster(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            SaveResult saveResult = SaveResult.Fail;
            TransactionParamsters tp = TransactionParamsters.Create();
            // 更新明细表
            this.SaveChangeRoomNo(strReason, ref tp);

            // 更新手术室数据
            this.SaveOperatingRoom(master, ref tp);

            // 更新监护仪数据
            this.SaveMonitorDict(master, ref tp);

            // 更新主表手术间号
            this.SaveOperationMaster(ref tp);
            if (CommonService.ClientInstance.UpdateByTransaction(tp.ToString()))
            {
                // 新增跨手术间消息
                this.InsertTransportMessage();
                saveResult = SaveResult.Success;
            }

            // 刷新主界面信息
            Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);

            // 更新手术间字典表
            ApplicationModel.Instance.AllDictList.OperatingRoomList = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();
            // 更新字典表
            ApplicationModel.Instance.AllDictList.MonitorDictList = DictService.ClientInstance.GetMonitorDictList();

            //TransMessageModel tempTransMsgModel = new TransMessageModel(EnumAppType.AnesWorkStation, 
            //                                                            EnumMessageType.Single, 
            //                                                            this.OperRoomNo, 
            //                                                            string.Empty, 
            //                                                            EnumFunctionType.Function, 
            //                                                            EnumDetailFunctiom.ChangeOperRoomNo, 
            //                                                            "患者转手术间", 
            //                                                            true);
            //TransMessageManager.Instance.SendMsg(tempTransMsgModel);
            return saveResult;
        }

        /// <summary>
        /// 插入跨手术间消息
        /// </summary>
        private bool InsertTransportMessage()
        {
            List<MED_TRANSPORT_MESSAGE> list = CommonService.ClientInstance.GetTransportMessage(ExtendAppContext.Current.OperRoomNo);
            List<MED_OPERATING_ROOM> tempList = this.MedOperatingRoomDict;
            // 针对所有手术间发消息
            for (int i = 0; i < tempList.Count; i++)
            {
                if (!tempList[i].ROOM_NO.Equals(ExtendAppContext.Current.OperRoomNo))
                {
                    MED_TRANSPORT_MESSAGE newMessage = new MED_TRANSPORT_MESSAGE();
                    newMessage.MESSAGE_NO = list.Count + 1;
                    newMessage.SOURCE_ROOM_NO = ExtendAppContext.Current.OperRoomNo;
                    newMessage.TARGET_ROOM_NO = tempList[i].ROOM_NO;
                    newMessage.TRANS_ATOR = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                    newMessage.TRANS_DATE = DateTime.Now;
                    newMessage.HAS_READ = 0;
                    newMessage.MESSAGE_CLASS = (int)EnumTransportMessageClass.ChangeOperRoomNo;
                    newMessage.TRANS_MESSAGE = string.Format("[更换手术间]  患者:{0},{1},{2} 由{3}手术间更换至{4}手术间！",
                                                             this.CurPatientModel.PatientID,
                                                             this.CurPatientModel.VisitID,
                                                             this.CurPatientModel.OperID,
                                                             ExtendAppContext.Current.OperRoomNo,
                                                             this.OperRoomNo);
                    newMessage.ModelStatus = ModelStatus.Add;
                    list.Add(newMessage);
                }
            }
            return CommonService.ClientInstance.SaveTransportMessage(list);
        }

        /// <summary>
        /// 保存主表数据信息
        /// </summary>
        private void SaveOperationMaster(ref TransactionParamsters tp)
        {
            MED_OPERATION_MASTER master = AnesInfoService.ClientInstance.GetOperationMaster(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            master.OPER_ROOM_NO = this.OperRoomNo;
            master.ModelStatus = ModelStatus.Modeified;
            tp.Append(master);
        }

        /// <summary>
        /// 保存监护仪字典信息
        /// </summary>
        private void SaveMonitorDict(MED_OPERATION_MASTER master, ref TransactionParamsters tp)
        {
            if (master.OPER_STATUS_CODE >= 5 && master.OPER_STATUS_CODE <= 30)
            {
                List<MED_MONITOR_DICT> monitorDict = ApplicationModel.Instance.AllDictList.MonitorDictList.Where(x => x.WARD_TYPE.ToString() == ExtendAppContext.Current.EventNo).ToList();
                foreach (MED_MONITOR_DICT monitor in monitorDict)
                {
                    if (null != monitor.PATIENT_ID && monitor.PATIENT_ID.Equals(this.CurPatientModel.PatientID) &&
                        null != monitor.VISIT_ID && monitor.VISIT_ID == this.CurPatientModel.VisitID &&
                        null != monitor.OPER_ID && monitor.OPER_ID == this.CurPatientModel.OperID)
                    {
                        monitor.PATIENT_ID = null;
                        monitor.VISIT_ID = null;
                        monitor.OPER_ID = null;
                        monitor.ModelStatus = ModelStatus.Modeified;
                        continue;
                    }
                }

                tp.Append(monitorDict);
            }
        }

        /// <summary>
        /// 保存手术间字典数据信息
        /// </summary>
        private void SaveOperatingRoom(MED_OPERATION_MASTER master, ref TransactionParamsters tp)
        {
            if (master.OPER_STATUS_CODE >= 5 && master.OPER_STATUS_CODE <=30)
            {
                List<MED_OPERATING_ROOM> tempList = new List<MED_OPERATING_ROOM>();
                foreach (MED_OPERATING_ROOM room in this.MedOperatingRoomDict)
                {
                    // 将现患者的手术间信息清空同时将对应数据写入到新的手术间
                    if (null != room.PATIENT_ID && room.PATIENT_ID.Equals(this.CurPatientModel.PatientID) &&
                        null != room.VISIT_ID && room.VISIT_ID == this.CurPatientModel.VisitID &&
                        null != room.OPER_ID && room.OPER_ID == this.CurPatientModel.OperID)
                    {
                        room.PATIENT_ID = null;
                        room.VISIT_ID = null;
                        room.OPER_ID = null;
                        room.ModelStatus = ModelStatus.Modeified;
                        tempList.Add(room);
                        continue;
                    }
                    else if (room.ROOM_NO.Equals(this.OperRoomNo))
                    {
                        room.PATIENT_ID = this.CurPatientModel.PatientID;
                        room.VISIT_ID = this.CurPatientModel.VisitID;
                        room.OPER_ID = this.CurPatientModel.OperID;
                        room.ModelStatus = ModelStatus.Modeified;
                        tempList.Add(room);
                        continue;
                    }
                }

                tp.Append(tempList);
            }
        }

        /// <summary>
        /// 保存更换手术间记录数据
        /// </summary>
        private void SaveChangeRoomNo(string strReason, ref TransactionParamsters tp)
        {
            List<MED_CHANGE_ROOM_NO> list = CommonService.ClientInstance.GetChangeRoomNo(this.CurPatientModel.PatientID,
                                                                                         this.CurPatientModel.VisitID,
                                                                                         this.CurPatientModel.OperID);
            MED_CHANGE_ROOM_NO newRow = new MED_CHANGE_ROOM_NO();
            newRow.CHANGE_NO = list.Count > 0 ? list[0].CHANGE_NO + 1 : 1;
            newRow.PATIENT_ID = this.CurPatientModel.PatientID;
            newRow.VISIT_ID = this.CurPatientModel.VisitID;
            newRow.OPER_ID = this.CurPatientModel.OperID;
            newRow.OLD_ROOM_NO = this.CurPatientModel.OperRoomNo;
            newRow.NEW_ROOM_NO = this.OperRoomNo;
            newRow.CHANGE_DATE = DateTime.Now;
            newRow.CHANGE_ATOR = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
            newRow.CHANGE_REASON = strReason;
            list.Add(newRow);
            tp.Append(list);
        }

        /// <summary>
        /// 在设置新的手术间前需要判断该手术间是否可以做手术
        /// </summary>
        protected bool CheckNewRoomNo(string strNewRoomNo)
        {
            bool result = true;
            MED_OPERATING_ROOM tarRoomNo = this.MedOperatingRoomDict.Where(x => x.ROOM_NO.Equals(strNewRoomNo) &&
                                                                                (null == x.PATIENT_ID || string.IsNullOrEmpty(x.PATIENT_ID))).FirstOrDefault();
            if (null == tarRoomNo)
            {
                this.ShowMessageBox("该手术间有患者正在手术，请选择其他手术间！", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                result = false;
            }

            return result;
        }
    }
}
