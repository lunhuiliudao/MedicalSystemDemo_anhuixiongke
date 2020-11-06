//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      BloodGasAnalysisViewModel.cs
//功能描述(Description)：    血气ViewModel
//数据表(Tables)：		    MED_BLOOD_GAS_MASTER
//                          MED_BLOOD_GAS_DETAIL_SHOW
//                          MED_BLOOD_GAS_DETAIL
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.BloodGasAnalysisViewModel
{
    public class BloodGasAnalysisViewModel : BaseViewModel
    {
        private string eventNo = "0";                                                                             // 代表麻醉（0） 还是 复苏（1）
        private MED_PAT_INFO medPatInfo = null;                                                                   // 当前检验信息的患者信息
        private List<MED_BLOOD_GAS_MASTER> medBloodGasMaster = new List<MED_BLOOD_GAS_MASTER>();                  // 血气分析主表
        private List<MED_BLOOD_GAS_DETAIL_SHOW> medBloodGasDetailShow = new List<MED_BLOOD_GAS_DETAIL_SHOW>();    // 血气分析明细表
        private ICommand showDetailCommand = null;                                                                // 根据选中的主信息显示对应的明细信息
        private ICommand addMasterCommand = null;                                                                 // 增加血气分析主表数据
        private ICommand saveDetailCommand = null;                                                                // 保存血气分析明细数据
        private bool addButtonIsEnabled = true;                                                                   // 添加血气按钮是否可用，在添加一次后，按钮禁止使用，只有保存后才可继续使用
        private MED_BLOOD_GAS_MASTER insertBloodGasMaster = null;                                                 // 新增的主表信息
        private bool delButtonIsEnabled = true;                                                                   // 删除血气按钮是否可用
        private ICommand delMasterCommand = null;                                                                 // 删除血气分析主表数据
        private ICommand editMasterCommand = null;                                                                // 编辑血气分析主表数据
        private bool editButtonIsEnabled = true;
        private DateTime? outDateTime;                                                                            // 出手术室时间，用于检验血气时间 

        /// <summary>
        /// 血气分析主表
        /// </summary>
        public List<MED_BLOOD_GAS_MASTER> MedBloodGasMaster
        {
            get { return this.medBloodGasMaster; }
            set
            {
                this.medBloodGasMaster = value;
                this.RaisePropertyChanged("MedBloodGasMaster");
            }
        }

        /// <summary>
        /// 血气分析明细表
        /// </summary>
        public List<MED_BLOOD_GAS_DETAIL_SHOW> MedBloodGasDetailShow
        {
            get { return this.medBloodGasDetailShow; }
            set
            {
                this.medBloodGasDetailShow = value;
                this.RaisePropertyChanged("MedBloodGasDetailShow");
            }
        }

        /// <summary>
        /// 根据选中的主信息显示对应的明细信息
        /// </summary>
        public ICommand ShowDetailCommand
        {
            get { return this.showDetailCommand; }
            set { this.showDetailCommand = value; }
        }

        /// <summary>
        /// // 增加血气分析主表数据
        /// </summary>
        public ICommand AddMasterCommand
        {
            get { return this.addMasterCommand; }
            set { this.addMasterCommand = value; }
        }

        /// <summary>
        /// 保存血气分析明细数据
        /// </summary>
        public ICommand SaveDetailCommand
        {
            get { return this.saveDetailCommand; }
            set { this.saveDetailCommand = value; }
        }

        /// <summary>
        /// 添加血气按钮是否可用，在添加一次后，按钮禁止使用，只有保存后才可继续使用
        /// </summary>
        public bool AddButtonIsEnabled
        {
            get { return this.addButtonIsEnabled; }
            set
            {
                this.addButtonIsEnabled = value;
                this.RaisePropertyChanged("AddButtonIsEnabled");
            }
        }

        /// <summary>
        /// 删除按钮是否可用
        /// </summary>
        public bool DelButtonIsEnabled
        {
            get { return this.delButtonIsEnabled; }
            set
            {
                this.delButtonIsEnabled = value;
                this.RaisePropertyChanged("DelButtonIsEnabled");
            }
        }

        /// <summary>
        /// 删除血气主表命令
        /// </summary>
        public ICommand DelMasterCommand
        {
            get { return this.delMasterCommand; }
            set { this.delMasterCommand = value; }
        }

        /// <summary>
        /// 编辑血气主表命令
        /// </summary>
        public ICommand EditMasterCommand
        {
            get { return this.editMasterCommand; }
            set { this.editMasterCommand = value; }
        }

        public bool EditButtonIsEnabled
        {
            get { return this.editButtonIsEnabled; }
            set
            {
                this.editButtonIsEnabled = value;
                this.RaisePropertyChanged("EditButtonIsEnabled");
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patModel">患者信息实体</param>
        /// <param name="eventNo">软件类型：麻醉=0，复苏=1</param>
        public BloodGasAnalysisViewModel(MED_PAT_INFO medPatInfo, string eventNo)
        {
            this.outDateTime = medPatInfo.OUT_DATE_TIME;// 获取患者当前的出手术室时间
            this.eventNo = eventNo;
            this.medPatInfo = medPatInfo;
            this.RegisterCommand();
            this.RefreshMasterData();
            this.DelButtonIsEnabled = this.MedBloodGasMaster.Count > 0;
            this.EditButtonIsEnabled = this.MedBloodGasMaster.Count > 0;
        }

        /// <summary>
        /// 载入窗口，用作接受参数
        /// </summary>
        public override void OnViewLoaded()
        {
            KeyBoardStateCache.AppCodeStack.Push("BloodGasAnalysisControl");
        }

        /// <summary>
        /// 卸载窗口
        /// </summary>
        public override void OnViewUnLoaded()
        {
            List<string> tempStackList = KeyBoardStateCache.AppCodeStack.ToList();
            tempStackList.Remove("BloodGasAnalysisControl");

            // 去除所有
            while (KeyBoardStateCache.AppCodeStack.Count > 0)
            {
                KeyBoardStateCache.AppCodeStack.Pop();
            }

            // 重新插入
            tempStackList.ForEach(x =>
            {
                KeyBoardStateCache.AppCodeStack.Push(x);
            });

            Messenger.Default.Unregister<dynamic>(this);
            UnRegisterKeyBoardMessage();
        }

        /// <summary>
        /// 注册命令信息
        /// </summary>
        private void RegisterCommand()
        {
            // 切换血气分析明细信息
            this.ShowDetailCommand = new RelayCommand<object>(par =>
            {
                // 在新增血气状态下不能切换
                if (this.AddButtonIsEnabled)
                {
                    MED_BLOOD_GAS_MASTER tempMaster = par as MED_BLOOD_GAS_MASTER;
                    if (null != tempMaster)
                    {
                        this.RefreshDetailData(tempMaster.DETAIL_ID);
                    }
                }
            });

            // 新增血气分析项
            this.AddMasterCommand = new RelayCommand<object>(par =>
            {
                var message = new ShowContentWindowMessage("AddBloodGasMaster", "新增血气分析记录");
                message.Height = 250;
                message.Width = 300;
                Messenger.Default.Send<ShowContentWindowMessage>(message);
            });

            // 增加血气成功后刷新左侧列表信息
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshBloodGasMaster, msg =>
            {
                if (null != msg && msg is MED_BLOOD_GAS_MASTER)
                {
                    // 添加按钮不可用
                    this.AddButtonIsEnabled = false;
                    this.DelButtonIsEnabled = false;
                    this.EditButtonIsEnabled = true;

                    // 将新添加的血气主信息添加到数据源
                    this.insertBloodGasMaster = msg as MED_BLOOD_GAS_MASTER;
                    List<MED_BLOOD_GAS_MASTER> tempMasterList = new List<MED_BLOOD_GAS_MASTER>(this.MedBloodGasMaster);

                    MED_BLOOD_GAS_MASTER tmpItem = tempMasterList.Find(x => x.DETAIL_ID == insertBloodGasMaster.DETAIL_ID);
                    if (tmpItem != null)
                    {
                        tempMasterList.Remove(tmpItem);
                    }

                    tempMasterList.Add(this.insertBloodGasMaster);
                    this.MedBloodGasMaster = tempMasterList;

                    // 新增明细项
                    this.InsertBloodGasDetail(this.insertBloodGasMaster);

                    // 刷新界面
                    Messenger.Default.Send<object>(this.insertBloodGasMaster, EnumMessageKey.RefreshBloodGasMasterSelection);
                }
            });


            // 保存血气分析明细
            this.SaveDetailCommand = new RelayCommand<object>(par =>
            {
                this.PublicKeyBoardMessage(KeyCode.AppCode.Save);
            });

            // 删除血气主表数据
            this.DelMasterCommand = new RelayCommand<object>(par =>
            {
                if (par != null && par is MED_BLOOD_GAS_MASTER)
                {
                    this.ShowMessageBox("确认删除选中项？", MessageBoxButton.YesNo, MessageBoxImage.Question, new Action<MessageBoxResult>((mbr) =>
                    {
                        if (mbr == MessageBoxResult.OK)
                        {
                            TransactionParamsters tp = TransactionParamsters.Create();
                            MED_BLOOD_GAS_MASTER tempMaster = par as MED_BLOOD_GAS_MASTER;
                            tempMaster.ModelStatus = ModelStatus.Deleted;
                            tp.Append(tempMaster);

                            // 不修改EXT表的内容
                            //List<MED_BLOOD_GAS_DETAIL_EXT> detailList = AnesInfoService.ClientInstance.GetBloodGasDetailExtList(tempMaster.DETAIL_ID);
                            //foreach (MED_BLOOD_GAS_DETAIL_EXT item in detailList)
                            //{
                            //    item.ModelStatus = ModelStatus.Deleted;
                            //}
                            //
                            //tp.Append(detailList);

                            CommonService.ClientInstance.UpdateByTransaction(tp.ToString());

                            // 刷新主表数据
                            this.RefreshMasterData();
                            this.ShowMessageBox("删除成功！", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }));
                }
                else
                {
                    this.ShowMessageBox("请选中数据行再执行删除！", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });

            // 编辑血气主表数据
            this.EditMasterCommand = new RelayCommand<object>(par =>
            {
                if (par != null && par is MED_BLOOD_GAS_MASTER)
                {
                    var message = new ShowContentWindowMessage("AddBloodGasMaster", "新增血气分析记录");
                    message.Height = 250;
                    message.Width = 300;
                    message.Args = new object[] { par };
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                }
            });
        }

        protected override SaveResult SaveData()
        {
            // 保存主表数据
            if (this.insertBloodGasMaster != null)
            {
                this.insertBloodGasMaster = null;
            }

            // 保存明细数据
            List<MED_BLOOD_GAS_DETAIL_EXT> tempDetailList = new List<MED_BLOOD_GAS_DETAIL_EXT>();
            foreach (MED_BLOOD_GAS_DETAIL_SHOW item in this.MedBloodGasDetailShow)
            {
                MED_BLOOD_GAS_DETAIL_EXT tempDetail = new MED_BLOOD_GAS_DETAIL_EXT();
                tempDetail.DETAIL_ID = item.DETAIL_ID;
                tempDetail.BLG_CODE = item.BLG_CODE;
                tempDetail.BLG_VALUE = item.BLG_VALUE;
                tempDetail.OPERATOR = item.OPERATOR;
                tempDetail.ABNORMAL_INDICATOR = item.ABNORMAL_INDICATOR;
                tempDetailList.Add(tempDetail);
            }

            // NURSE_MEMO2为空时则显示，不为空是则不显示
            //this.MedBloodGasMaster.ForEach(x =>
            //{
            //    x.NURSE_MEMO2 = "";
            //});

            if (this.outDateTime != null)// 检验血气是否超过了出室时间
            {
                List<MED_BLOOD_GAS_MASTER> errorGasMasters = this.MedBloodGasMaster.FindAll(x => x.RECORD_DATE > this.outDateTime);
                if (errorGasMasters.Count > 0)
                {
                    this.ShowMessageBox("血气时间有误，超过出室时间！", MessageBoxButton.OK, MessageBoxImage.Information);
                    return SaveResult.Fail;
                }
            }

            bool result = CommonService.ClientInstance.UpdateByTransaction(TransactionParamsters.Create(this.MedBloodGasMaster, tempDetailList).ToString());

            this.AddButtonIsEnabled = true;
            this.DelButtonIsEnabled = true;
            this.EditButtonIsEnabled = true;

            return result ? SaveResult.Success : SaveResult.Fail;
        }

        /// <summary>
        /// 检查是否有更新数据
        /// </summary>
        protected override bool CheckDataChange()
        {
            bool result = false;
            if (this.MedBloodGasMaster != null)
            {
                foreach (var item in this.MedBloodGasMaster)
                {
                    if (item.ModelStatus != ModelStatus.Default)
                    {
                        result = true;
                        break;
                    }
                }
            }

            if (!result && null != this.MedBloodGasDetailShow)
            {
                foreach (var item in this.MedBloodGasDetailShow)
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
        /// 检查页面数据是否完整
        /// </summary>
        protected override bool CheckData()
        {
            return true;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveBloodGasMasterAndDetail()
        {
            // 保存主表数据
            if (this.insertBloodGasMaster != null)
            {
                this.insertBloodGasMaster = null;
            }

            // 保存明细数据（以EXT表为主）
            List<MED_BLOOD_GAS_DETAIL_EXT> tempDetailList = new List<MED_BLOOD_GAS_DETAIL_EXT>();
            foreach (MED_BLOOD_GAS_DETAIL_SHOW item in this.MedBloodGasDetailShow)
            {
                MED_BLOOD_GAS_DETAIL_EXT tempDetail = new MED_BLOOD_GAS_DETAIL_EXT();
                tempDetail.DETAIL_ID = item.DETAIL_ID;
                tempDetail.BLG_CODE = item.BLG_CODE;
                tempDetail.BLG_VALUE = item.BLG_VALUE;
                tempDetail.OPERATOR = item.OPERATOR;
                tempDetail.ABNORMAL_INDICATOR = item.ABNORMAL_INDICATOR;
                tempDetailList.Add(tempDetail);
            }
            if (this.outDateTime != null)// 检验血气是否超过了出室时间
            {
                List<MED_BLOOD_GAS_MASTER> errorGasMasters = this.MedBloodGasMaster.FindAll(x => x.RECORD_DATE > this.outDateTime);
                if (errorGasMasters.Count > 0)
                {
                    this.ShowMessageBox("血气时间有误，超过出室时间！", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            CommonService.ClientInstance.UpdateByTransaction(TransactionParamsters.Create(this.MedBloodGasMaster, tempDetailList).ToString());

            this.ShowMessageBox("保存成功！", MessageBoxButton.OK, MessageBoxImage.Information);

            this.CloseContentWindow();

            this.AddButtonIsEnabled = true;
            this.DelButtonIsEnabled = true;
            this.EditButtonIsEnabled = true;
        }

        /// <summary>
        /// 新增明细项
        /// </summary>
        private void InsertBloodGasDetail(MED_BLOOD_GAS_MASTER tempNewMaster)
        {
            // 添加默认的血气项
            List<MED_BLOOD_GAS_DETAIL_SHOW> tempNewDetailList = new List<MED_BLOOD_GAS_DETAIL_SHOW>();
            foreach (MED_BLOOD_GAS_DICT tempDict in ApplicationModel.Instance.AllDictList.BloodGasDictList)
            {
                if (tempDict.BLG_STATUS.Equals("1"))
                {
                    MED_BLOOD_GAS_DETAIL_SHOW tempNewDetailShow = new MED_BLOOD_GAS_DETAIL_SHOW();
                    tempNewDetailShow.ROWNUM = tempNewDetailList.Count + 1;
                    tempNewDetailShow.DETAIL_ID = tempNewMaster.DETAIL_ID;
                    tempNewDetailShow.BLG_CODE = tempDict.BLG_CODE;
                    tempNewDetailShow.BLG_VALUE = string.Empty;
                    tempNewDetailShow.OPERATOR = tempNewMaster.OPERATOR;
                    tempNewDetailShow.OP_DATE = DateTime.Now;
                    tempNewDetailShow.BLG_NAME = tempDict.BLG_NAME;
                    tempNewDetailShow.BLG_SHOWID = tempDict.BLG_SHOWID;
                    tempNewDetailShow.BLG_UNIT = tempDict.BLG_UNIT;
                    tempNewDetailShow.BLG_REFER_VALUE = tempDict.BLG_REFER_VALUE;
                    tempNewDetailList.Add(tempNewDetailShow);
                }
            }

            this.MedBloodGasDetailShow = tempNewDetailList;
        }

        /// <summary>
        /// 刷新主表数据
        /// </summary>
        private void RefreshMasterData()
        {
            // 获取血气分析主表
            this.MedBloodGasMaster = AnesInfoService.ClientInstance.GetBloodGasMasterList(this.medPatInfo.PATIENT_ID, this.medPatInfo.VISIT_ID, this.medPatInfo.OPER_ID);
            // 默认选中第一行
            if (this.MedBloodGasMaster.Count > 0)
            {
                this.RefreshDetailData(this.MedBloodGasMaster[0].DETAIL_ID);
            }
        }

        /// <summary>
        /// 根据主表的DetailID获取对应的明细数据
        /// </summary>
        private void RefreshDetailData(string strDetailId)
        {
            //this.MedBloodGasDetailShow = AnesInfoService.ClientInstance.GetBloodGasDetailShowList(strDetailId);
            this.MedBloodGasDetailShow = this.GetDetailShowList(strDetailId);// 获取血气明细的新方法

        }
        /// <summary>
        /// 获取明细项（血气主要由MED_BLOOD_GAS_DETAIL_EXT表来取得）
        /// </summary>
        private List<MED_BLOOD_GAS_DETAIL_SHOW> GetDetailShowList(string strDetailId)
        {
            List<MED_BLOOD_GAS_DETAIL_SHOW> originList = AnesInfoService.ClientInstance.GetBloodGasDetailShowList(strDetailId);

            List<MED_BLOOD_GAS_DETAIL_SHOW> extList = AnesInfoService.ClientInstance.GetBloodGasDetailExtShowList(strDetailId);

            List<MED_BLOOD_GAS_DETAIL_SHOW> result = new List<MED_BLOOD_GAS_DETAIL_SHOW>(extList);

            originList.ForEach(x =>
            {
                if (null == extList.FirstOrDefault(row => row.DETAIL_ID.Equals(x.DETAIL_ID) &&
                                                    row.BLG_CODE.Equals(x.BLG_CODE)))
                {
                    result.Add(x);
                }
            });

            return result;
        }
    }
}
