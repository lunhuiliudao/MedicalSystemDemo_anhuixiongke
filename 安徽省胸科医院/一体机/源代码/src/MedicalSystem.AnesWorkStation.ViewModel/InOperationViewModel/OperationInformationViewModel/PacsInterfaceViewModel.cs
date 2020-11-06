//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationScreenViewModel.cs
//功能描述(Description)：    家属大屏交互界面
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 14:45:43
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStationCoordination.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class PacsInterfaceViewModel : BaseViewModel
    {
        private ICommand btnCancelCommand = null;                                                       // 取消按钮命令
        private ICommand btnOKCommand = null;                                                           // 确定按钮命令
        private PatientModel curPatientModel = null;                                                    // 当前选中的患者信息
        private List<PacsNoAndType> pacsNoAndTypeList = null;                                           // 获取的检验编号列表

        public List<PacsNoAndType> PacsNoAndTypeList
        {
            get { return this.pacsNoAndTypeList; }
            set
            {
                this.pacsNoAndTypeList = value;
                this.RaisePropertyChanged("PacsNoAndTypeList");
            }
        }

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
        /// 左侧事件按钮双击事件
        /// </summary>
        public ICommand LeftEventDoubleClick
        {
            get
            {
                return new RelayCommand<PacsNoAndType>(data =>
                {
                    if (null != data)
                    {
                        string no = data.RepNo;
                        string lb = data.RepLb;
                        string strAddress = string.Format(@"http://192.168.6.245/TechReportWeb/ReportHtml/RisResult_Tview.aspx?HospitalCode=9999&repno={0}&reptypeno={1}", no, lb);
                        Process.Start(strAddress);
                    }
                    else
                    {
                        ShowMessageBox("术后患者或非当前手术间患者，无法修改。", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                });
            }
        }


        /// <summary>
        /// 构造方法
        /// </summary>
        public PacsInterfaceViewModel(MED_PAT_INFO patModel)
        {
            if (patModel != null)
            {
                this.CurPatientModel = PatientModel.CreateModel(patModel);
                this.GetSyncPacsNoAndType();
                // 注册按钮命令
                this.RegisterCommand();
            }
        }

        /// <summary>
        /// 获取家属呼叫分类信息
        /// </summary>
        private void GetSyncPacsNoAndType()
        {
            string str = SyncInfoService.ClientInstance.SyncPACSNoAndType(this.CurPatientModel.InpNo);
            if (!string.IsNullOrEmpty(str))
            {
                List<PacsNoAndType> list = new List<PacsNoAndType>();
                string[] arr = str.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    string[] modelArr = arr[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (modelArr.Length == 2)
                    {
                        PacsNoAndType pnt = new PacsNoAndType { RepNo = modelArr[0], RepLb = modelArr[1] };
                        list.Add(pnt);
                    }
                }

                this.PacsNoAndTypeList = list;
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
                this.CloseContentWindow();
            });
        }
    }

    public class PacsNoAndType : ObservableObject
    {
        private string repno;                  // 检查编号
        private string replb;                  // 检查类别

        /// <summary>
        /// 检查编号
        /// </summary>
        public string RepNo
        {
            get { return this.repno; }
            set
            {
                this.repno = value;
                this.RaisePropertyChanged("RepNo");
            }
        }

        /// <summary>
        /// 检查类别
        /// </summary>
        public string RepLb
        {
            get { return this.replb; }
            set
            {
                this.replb = value;
                this.RaisePropertyChanged("RepLb");
            }
        }
    }
}
