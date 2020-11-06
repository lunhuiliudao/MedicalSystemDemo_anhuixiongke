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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class OperationScreenViewModel : BaseViewModel
    {
        private ICommand btnCancelCommand = null;                                                       // 取消按钮命令
        private ICommand btnOKCommand = null;                                                           // 确定按钮命令
        private PatientModel curPatientModel = null;                                                    // 当前选中的患者信息
        private string strOtherMesInfo = string.Empty;                                                  // 其他事项信息
        private RichTextBox rtbOtherMesInfo = null;                                                     // 界面中的其他事项富文本框，由于不能直接绑定，所以把控件传到VM中
        private List<OperationCanceledTypeModel> allOperScreenTypeList = new List<OperationCanceledTypeModel>();  // 所有家属呼叫分类信息

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
        /// 所有家属呼叫分类信息
        /// </summary>
        public List<OperationCanceledTypeModel> AllOperScreenTypeList
        {
            get { return this.allOperScreenTypeList; }
            set
            {
                this.allOperScreenTypeList = value;
                this.RaisePropertyChanged("AllOperScreenTypeList");
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationScreenViewModel(MED_PAT_INFO patModel, RichTextBox rtb)
        {
            if (patModel != null)
            {
                this.CurPatientModel = PatientModel.CreateModel(patModel);
                this.rtbOtherMesInfo = rtb;
                // 设置列表信息
                this.ResetOperScreenTypeList("家属呼叫");
                // 注册按钮命令
                this.RegisterCommand();
            }
        }

        /// <summary>
        /// 获取家属呼叫分类信息
        /// </summary>
        private void ResetOperScreenTypeList(string itemClass)
        {
            List<MED_ANESTHESIA_INPUT_DICT> tempList = ApplicationModel.Instance.AllDictList.AnesthesiaInputDictList.Where(x => x.ITEM_CLASS.Equals(itemClass)).ToList();
            List<OperationCanceledTypeModel> tempOperScreenList = new List<OperationCanceledTypeModel>();
            if (null != tempList && tempList.Count > 0)
            {
                foreach (MED_ANESTHESIA_INPUT_DICT item in tempList)
                {
                    tempOperScreenList.Add(new OperationCanceledTypeModel(false, item.ITEM_CLASS, item.ITEM_NAME));
                }
            }
            this.AllOperScreenTypeList = tempOperScreenList;
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

            if (null != this.rtbOtherMesInfo)
            {
                TextRange tr = new TextRange(this.rtbOtherMesInfo.Document.ContentStart, this.rtbOtherMesInfo.Document.ContentEnd);
                this.strOtherMesInfo = tr.Text;
            }

            // 其他事项和常用事项其他一个必须有值
            if (this.allOperScreenTypeList.Where(x => x.IsChecked).ToList().Count == 0 &&
               (this.strOtherMesInfo.Trim().Equals("\r\n") || string.IsNullOrEmpty(this.strOtherMesInfo.Trim())))
            {
                this.ShowMessageBox("呼叫信息不能为空，请重新录入！", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            // 保存大屏信息
            bool result = this.SaveOperationScreenMsgInfo();
            return result ? SaveResult.Success : SaveResult.Fail;
        }

        /// <summary>
        /// 保存大屏呼叫的信息到数据库
        /// </summary>
        private bool SaveOperationScreenMsgInfo()
        {
            bool result = true;
            List<MED_SCREEN_MSG> list = new List<MED_SCREEN_MSG>();

            foreach (OperationCanceledTypeModel item in this.AllOperScreenTypeList)
            {
                if (item.IsChecked)
                {
                    MED_SCREEN_MSG newRow = new MED_SCREEN_MSG();
                    newRow.ID = ExtendAppContext.Current.LoginUser.USER_JOB_ID + "_" + Guid.NewGuid().ToString();
                    newRow.MSG = string.Format("{0}患者家属请注意：{1}", this.CurPatientModel.Name, item.ItemName);
                    newRow.INSERT_TIME = DateTime.Now;
                    newRow.COUNTS = 3;
                    newRow.STATUS = 1;
                    newRow.USER_ID = "紧急公告";
                    newRow.TYPE = 2;
                    newRow.DEPT_CODE = ExtendAppContext.Current.OperDeptCode;
                    newRow.ModelStatus = ModelStatus.Add;
                    list.Add(newRow);
                }
            }

            // 如果其他事项包含信息，则也写入列表
            if (!this.strOtherMesInfo.Trim().Equals("\r\n") && !string.IsNullOrEmpty(this.strOtherMesInfo.Trim()))
            {
                MED_SCREEN_MSG newRow = new MED_SCREEN_MSG();
                new Guid().ToString();
                newRow.ID = ExtendAppContext.Current.LoginUser.USER_JOB_ID + "_" + Guid.NewGuid().ToString();
                newRow.MSG = string.Format("{0}患者家属请注意：{1}", this.CurPatientModel.Name, this.strOtherMesInfo.Trim());
                newRow.INSERT_TIME = DateTime.Now;
                newRow.COUNTS = 3;
                newRow.STATUS = 1;
                newRow.USER_ID = "紧急公告";
                newRow.TYPE = 2;
                newRow.DEPT_CODE = ExtendAppContext.Current.OperDeptCode;
                newRow.ModelStatus = ModelStatus.Add;
                list.Add(newRow);
            }
            result = CommonService.ClientInstance.SaveOperationScreen(list);
            foreach (MED_SCREEN_MSG msg in list)
            {
                string msgStr = msg.ID + "@" + msg.MSG + "@" + msg.COUNTS;

                TransMessageModel tempTransMsgModel = new TransMessageModel(EnumAppType.Screen,
                                                                           EnumMessageType.Broadcase,
                                                                           EnumFunctionType.OperationScreen,
                                                                           msgStr
                                                                           );
                TransMessageManager.Instance.SendMsg(tempTransMsgModel);
            }

            return true;
        }
    }
}
