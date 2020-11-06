//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      CallAVControlViewModel.cs
//功能描述(Description)：    
//数据表(Tables)：		     
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/7/5 14:11:01
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MedicalSystem.AnesWorkStation.Model.CoordinationModel;


namespace MedicalSystem.AnesWorkStation.ViewModel.CoordinationViewModel
{
    public class CallAVControlViewModel : ViewModelBase
    {
        private CallStatus _CallStatus = CallStatus.Called;

        /// <summary>
        /// 状态
        /// </summary>
        public CallStatus CallStatus
        {
            get { return _CallStatus; }
            set
            {
                _CallStatus = value;
                RaisePropertyChanged("CallStatus");
            }
        }
        
        private string _RoomNo = "手术间";
        public string RoomNo
        {
            get { return _RoomNo; }
            set
            {
                _RoomNo = value;
                RaisePropertyChanged("RoomNo");
            }
        }
        private string _UserName = "医生";
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        private ICommand callOK;
        /// <summary>
        /// 接收
        /// </summary>
        public ICommand CallOK
        {
            get { return this.callOK; }
            set { this.callOK = value; }
        }

        private ICommand callExit;
        /// <summary>
        /// 拒绝
        /// </summary>
        public ICommand CallExit
        {
            get { return this.callExit; }
            set { this.callExit = value; }
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        private void RegisterMessage()
        {
            this.CallOK = new RelayCommand<object>(key =>
            {
                this.Call(true);
            });
            this.CallExit = new RelayCommand<object>(key =>
            {
                this.Call(false);
            });
        }


        private void Call(bool isCall)
        {
            if (isCall)//接听
            {
                CallStatus = CallStatus.Calling;



            }
            else//挂断
            {
                CallStatus = CallStatus.Free;

            }

        }

        /// <summary>
        /// 初始化在线客户端
        /// </summary>
        public CallAVControlViewModel()
        {
            if (!this.IsInDesignMode)
            {
                this.RegisterMessage();
            }
        }

    }
}
