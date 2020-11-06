//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      PatConfirmControl.xaml.cs
//功能描述(Description)：    核对患者信息
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 15:32:06
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using MedicalSystem.Services;
using MedicalSystem.UsbKeyBoard;
using System;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class PatConfirmControlViewModel : BaseViewModel
    {
        private PatientModel paramaterData;                                           // 传入参数
        private int type = 1;                                                    // 1-术前 2-术中 3-术后
        private string _name;
        private string _sex;
        private string _age;
        private string _inpNo;
        private string _bedNo;
        private string _deptCodeName;
        private string _operationName;
        private string _tips;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.RaisePropertyChanged("Name");
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                this.RaisePropertyChanged("Sex");
            }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                this.RaisePropertyChanged("Age");
            }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string InpNo
        {
            get { return _inpNo; }
            set
            {
                _inpNo = value;
                this.RaisePropertyChanged("InpNo");
            }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo
        {

            get { return _bedNo; }
            set
            {
                _bedNo = value;
                this.RaisePropertyChanged("BedNo");
            }
        }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptCodeName
        {
            get { return _deptCodeName; }
            set
            {
                _deptCodeName = value;
                this.RaisePropertyChanged("DeptCodeName");
            }
        }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OperationName
        {
            get { return _operationName; }
            set
            {
                _operationName = value;
                this.RaisePropertyChanged("OperationName");
            }
        }
        /// <summary>
        ///浮标提示信息
        /// </summary>
        public string Tips
        {
            get { return _tips; }
            set
            {
                _tips = value;
                this.RaisePropertyChanged("Tips");
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            if ((int)paramaterData.OperStatusCode >= 35)
            {
                type = 3;
                Tips = "当前患者无手术申请，是否开始急诊登记";
            }
            else if ((int)paramaterData.OperStatusCode > 0 && (int)paramaterData.OperStatusCode < 35)
            {
                type = 2;
                Tips = "当前患者正在" + paramaterData.OperRoomNo + "号手术间进行手术，不能进行后续操作";
            }
            else
            {
                type = 1;
                Tips = "当前患者即将开始入室流程，请确认";
            }
            Name = paramaterData.Name;
            Sex = paramaterData.Sex;
            Age = paramaterData.Age;
            InpNo = paramaterData.InpNo;
            BedNo = paramaterData.BedNo;
            DeptCodeName = paramaterData.DeptCodeName;
            OperationName = paramaterData.OperationName;
        }

        /// <summary>
        /// 获取窗口传参
        /// </summary>
        public override void OnViewLoaded()
        {
            try
            {
                paramaterData = Args[0] as PatientModel;
            }
            catch (Exception ex)
            {
                Logger.Error("患者确认异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// 取消并关闭
        /// </summary>
        public ICommand BtnCancelCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }
        /// <summary>
        ///确认并保存
        /// </summary>
        public ICommand BtnOKCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    if (type == 1)
                    {
                        ExtendAppContext.Current.PatientInformationExtend = paramaterData.Med_Pat_Info;
                        Messenger.Default.Send<AppCodeMessage>(new AppCodeMessage() { AppCode = AppCode.InOperRoom });
                    }
                    else if (type == 2)
                    {
                        this.CloseContentWindow();
                    }
                    else if (type == 3)
                    {
                        Messenger.Default.Send<AppCodeMessage>(new AppCodeMessage() { AppCode = AppCode.Emergency });
                    }
                    this.CloseContentWindow();
                });
            }
        }


        public override void OnViewUnLoaded()
        {
            //关闭窗口只卸载键盘消息，不做清空AppCode操作
            UnRegisterKeyBoardMessage();
        }

    }
}
