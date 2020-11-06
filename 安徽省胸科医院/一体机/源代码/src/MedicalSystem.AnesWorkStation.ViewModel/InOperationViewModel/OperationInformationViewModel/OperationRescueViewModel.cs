//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationRescueViewModel.cs
//功能描述(Description)：    按第二次抢救按钮 代表抢救结束弹出此页面
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 14:40:45
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
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.Wpf.Helper;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class OperationRescueViewModel : BaseViewModel
    {
        private ICommand btnCancelCommand = null;                                                       // 取消按钮命令
        private ICommand btnOKCommand = null;                                                           // 确定按钮命令
        private PatientModel curPatientModel = null;                                                    // 当前选中的患者信息
        private string strReason = string.Empty;                                                        // 抢救原因
        private string strMeasure = string.Empty;                                                       // 抢救措施
        private string strDocAndNurse = string.Empty;                                                   // 参与抢救人员
        private string strSuccessInfo = "1";                                                         // 抢救结果
        private string strRescueTimeLength = string.Empty;                                              // 抢救时长
        private DateTime startDateTime = DateTime.MinValue;                                             // 抢救开始时间
        private DateTime endDateTime = DateTime.MaxValue;                                               // 抢救结束时间
        private Grid mainGrid = null;                                                                   // 界面控件集合

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
        /// 抢救结果：成功=1或失败=0
        /// </summary>
        public string StrSuccessInfo
        {
            get { return this.strSuccessInfo; }
            set
            {
                this.strSuccessInfo = value;
                this.RaisePropertyChanged("StrSuccessInfo");
            }
        }

        /// <summary>
        /// 抢救时长
        /// </summary>
        public string StrRescueTimeLength
        {
            get { return this.strRescueTimeLength; }
            set
            {
                this.strRescueTimeLength = value;
                this.RaisePropertyChanged("StrRescueTimeLength");
            }
        }

        /// <summary>
        /// 抢救开始时间
        /// </summary>
        public DateTime StartDateTime
        {
            get { return this.startDateTime; }
            set
            {
                this.startDateTime = value;
                this.RaisePropertyChanged("StartDateTime");
                this.RefreshStrRescueTimeLength();
            }
        }

        /// <summary>
        /// 抢救结束时间
        /// </summary>
        public DateTime EndDateTime
        {
            get { return this.endDateTime; }
            set
            {
                this.endDateTime = value;
                this.RaisePropertyChanged("EndDateTime");
                this.RefreshStrRescueTimeLength();
            }
        }

        /// <summary>
        /// 抢救原因
        /// </summary>
        public string StrReason
        {
            get { return this.strReason; }
            set
            {
                this.strReason = value;
                this.RaisePropertyChanged("StrReason");
            }
        }

        /// <summary>
        /// 抢救措施
        /// </summary>
        public string StrMeasure
        {
            get { return this.strMeasure; }
            set
            {
                this.strMeasure = value;
                this.RaisePropertyChanged("StrMeasure");
            }
        }

        /// <summary>
        /// 参与抢救的人员
        /// </summary>
        public string StrDocAndNurse
        {
            get { return this.strDocAndNurse; }
            set
            {
                this.strDocAndNurse = value;
                this.RaisePropertyChanged("StrDocAndNurse");
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationRescueViewModel(MED_PAT_INFO patModel, DateTime startDateTime, DateTime endDateTime, Grid grid)
        {
            if (patModel != null)
            {
                this.CurPatientModel = PatientModel.CreateModel(patModel);
                this.StartDateTime = startDateTime;
                this.EndDateTime = endDateTime;
                this.mainGrid = grid;
                // 注册按钮命令
                this.RegisterCommand();
            }
        }

        /// <summary>
        /// 刷新抢救时长
        /// </summary>
        private void RefreshStrRescueTimeLength()
        {
            if (this.StartDateTime != DateTime.MinValue && this.StartDateTime != DateTime.MaxValue &&
               this.EndDateTime != DateTime.MinValue && this.EndDateTime != DateTime.MaxValue && this.StartDateTime <= this.EndDateTime)
            {
                TimeSpan ts = this.EndDateTime - this.StartDateTime;
                this.StrRescueTimeLength = string.Format("{0}{1}", ts.TotalHours >= 1 ? ts.Hours.ToString() + "小时" : string.Empty,
                                                                   ts.Minutes.ToString() + "分钟");
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
                PublicKeyBoardMessage(KeyCode.AppCode.Save);
            });
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        protected override bool CheckData()
        {
            bool result = true;
            List<RichTextBox> rtcList = VisualTreeFinder.GetChildObjects<RichTextBox>(this.mainGrid, typeof(RichTextBox));
            RichTextBox tbReason = rtcList.Find(x => x.Name.Equals("tbReason"));
            RichTextBox tbMeasure = rtcList.Find(x => x.Name.Equals("tbMeasure"));
            RichTextBox tbDocAndNurse = rtcList.Find(x => x.Name.Equals("tbDocAndNurse"));
            if (null == tbReason || null == tbMeasure || null == tbDocAndNurse)
            {
                this.ShowMessageBox("获取界面信息失败，请联系管理员", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
                return result;
            }

            // 获取信息
            TextRange tempTextRange = new TextRange(tbReason.Document.ContentStart, tbReason.Document.ContentEnd);
            this.strReason = tempTextRange.Text;

            tempTextRange = new TextRange(tbMeasure.Document.ContentStart, tbMeasure.Document.ContentEnd);
            this.StrMeasure = tempTextRange.Text;

            tempTextRange = new TextRange(tbDocAndNurse.Document.ContentStart, tbDocAndNurse.Document.ContentEnd);
            this.StrDocAndNurse = tempTextRange.Text;

            if (result && (this.strReason.Trim().Equals("\r\n") || string.IsNullOrEmpty(this.strReason.Trim())))
            {
                this.ShowMessageBox("抢救原因不能为空，请重新录入！", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
                return result;
            }

            if (result && (this.StrMeasure.Trim().Equals("\r\n") || string.IsNullOrEmpty(this.StrMeasure.Trim())))
            {
                this.ShowMessageBox("抢救措施不能为空，请重新录入！", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
                return result;
            }

            if (result && (this.StrDocAndNurse.Trim().Equals("\r\n") || string.IsNullOrEmpty(this.StrDocAndNurse.Trim())))
            {
                this.ShowMessageBox("抢救参与人员不能为空，请重新录入！", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
                return result;
            }

            if (this.EndDateTime < this.StartDateTime)
            {
                this.EndDateTime = this.StartDateTime;
                this.ShowMessageBox("抢救结束时间小于开始时间，请重新填写", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
                return result;
            }

            return result;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            // 保存手术取消记录
            bool result = this.SaveOperationRescue();
            // 退出抢救模式
            ExtendAppContext.Current.IsOperationRescuing = false;
            // 发送消息
            Messenger.Default.Send<object>(this, EnumMessageKey.IsOperationRescuing);
            return result ? SaveResult.Success : SaveResult.Fail;
        }

        /// <summary>
        /// 保存手术取消记录数据
        /// </summary>
        private bool SaveOperationRescue()
        {
            List<MED_OPERATION_RESCUE> list = CommonService.ClientInstance.GetOperationRescue(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            MED_OPERATION_RESCUE newRow = new MED_OPERATION_RESCUE();
            newRow.PATIENT_ID = this.CurPatientModel.PatientID;
            newRow.VISIT_ID = this.CurPatientModel.VisitID;
            newRow.OPER_ID = this.CurPatientModel.OperID;
            newRow.RESCUE_ID = list.Count + 1;
            newRow.OPER_STATUS_CODE = (int)this.CurPatientModel.OperStatusCode;
            newRow.START_DATE_TIME = this.StartDateTime;
            newRow.END_DATE_TIME = this.EndDateTime;
            newRow.REASON = this.StrReason;
            newRow.MEASURES = this.StrMeasure;
            newRow.RESULT = this.StrSuccessInfo;
            newRow.PARTICIPANTS = this.StrDocAndNurse;
            newRow.ENTERED_BY = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
            newRow.ModelStatus = ModelStatus.Add;
            list.Add(newRow);
            bool saveResult = CommonService.ClientInstance.SaveOperationRescue(list);
            return saveResult;
        }
    }
}
