//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AddBloodGasMasterViewModel.cs
//功能描述(Description)：    血气类型设置界面ViewModel
//数据表(Tables)：		    MED_HIS_USERS， MED_HIS_USERS
//                          MED_PAT_INFO，MED_BLOOD_GAS_MASTER
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.BloodGasAnalysisViewModel
{

    public class AddBloodGasMasterViewModel : BaseViewModel
    {
        private MED_PAT_INFO curPatInfo = null;                                                      // 患者信息
        private List<MED_HIS_USERS> medHisUsers = null;                                              // 人员字典
        private DateTime insertDateTime = DateTime.Now;                                              // 插入血气记录的时间
        private string operatorID;

        private bool _normalMode = true;

        private dynamic paramaterData;

        /// <summary>
        /// 人员字典
        /// </summary>
        public List<MED_HIS_USERS> MedHisUsers
        {
            get { return this.medHisUsers; }
            set
            {
                this.medHisUsers = value;
                this.RaisePropertyChanged("MedHisUsers");
            }
        }

        /// <summary>
        /// 插入血气记录的时间
        /// </summary>
        public DateTime InsertDateTime
        {
            get { return this.insertDateTime; }
            set
            {
                this.insertDateTime = value;
                this.RaisePropertyChanged("InsertDateTime");
            }
        }

        public string OperatorID
        {
            get { return this.operatorID; }
            set
            {
                this.operatorID = value;
                this.RaisePropertyChanged("OperatorID");
            }
        }

        public bool NormalMode
        {
            get { return _normalMode; }
            set
            {
                _normalMode = value;
                RaisePropertyChanged("NormalMode");
            }
        }


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
        /// 构造方法
        /// </summary>
        public AddBloodGasMasterViewModel(MED_PAT_INFO curPatInfo)
        {
            this.curPatInfo = curPatInfo;
            this.medHisUsers = ApplicationModel.Instance.AllDictList.HisUsersList;
        }

        /// <summary>
        /// 血气功能的内部界面无需重置
        /// </summary>
        public override void ResetCurntOpenForm()
        {
        }

        public override void LoadData()
        {
            this.OperatorID = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
            if (paramaterData != null)
            {
                this.InsertDateTime = paramaterData.RECORD_DATE;
                this.OperatorID = paramaterData.OPERATOR;
                this.NormalMode = paramaterData.NURSE_MEMO1 == "动脉" ? true : false;
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void AddBloodGasMasterRecord(object operatorUserID, string strType)
        {
            if (null == operatorUserID || string.IsNullOrEmpty(operatorUserID.ToString()))
            {
                this.ShowMessageBox("操作者不能为空，请重新选择！", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (this.InsertDateTime > this.curPatInfo.OUT_DATE_TIME && this.curPatInfo.OUT_DATE_TIME != null)// 检验血气的填写时间是否超过了出室时间
            {
                this.ShowMessageBox("血气时间有误，超过了出室时间！", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (paramaterData != null)
                {
                    MED_BLOOD_GAS_MASTER tmpItem = paramaterData as MED_BLOOD_GAS_MASTER;
                    tmpItem.RECORD_DATE = this.InsertDateTime;
                    tmpItem.NURSE_MEMO1 = strType;
                    tmpItem.OPERATOR = operatorUserID.ToString();
                    Messenger.Default.Send<object>(tmpItem, EnumMessageKey.RefreshBloodGasMaster);
                }
                else
                {
                    MED_BLOOD_GAS_MASTER newMaster = new MED_BLOOD_GAS_MASTER();
                    newMaster.DETAIL_ID = this.InsertDateTime.ToString("yyyy-MM-dd HH:mm") + "|" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                    newMaster.PATIENT_ID = this.curPatInfo.PATIENT_ID;
                    newMaster.VISIT_ID = this.curPatInfo.VISIT_ID;
                    newMaster.OPER_ID = this.curPatInfo.OPER_ID;
                    newMaster.RECORD_DATE = this.InsertDateTime;
                    newMaster.NURSE_MEMO1 = strType;
                    newMaster.NURSE_MEMO2 = "ok@";
                    newMaster.OP_DATE = DateTime.Now;
                    newMaster.OPERATOR = operatorUserID.ToString();
                    newMaster.ModelStatus = ModelStatus.Add;
                    // 刷新血气主表信息
                    Messenger.Default.Send<object>(newMaster, EnumMessageKey.RefreshBloodGasMaster);
                }
                this.CloseContentWindow();
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public void CancelAddBloodGasMasterRecord()
        {
            this.CloseContentWindow();
        }
    }
}
