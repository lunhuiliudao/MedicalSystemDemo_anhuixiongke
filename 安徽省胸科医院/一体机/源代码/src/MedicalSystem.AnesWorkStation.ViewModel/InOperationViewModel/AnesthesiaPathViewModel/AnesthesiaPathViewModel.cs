//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AnesthesiaPathViewModel.cs
//功能描述(Description)：    麻醉路径ViewModel
//数据表(Tables)：		    MED_ANESTHESIA_EVENT_TEMPLET 
//                          MED_OPERATION_MASTER
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Wpf.Controls.TreeView;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.AnesthesiaPathViewModel
{
    public class AnesthesiaPathViewModel : BaseViewModel
    {
        #region 变量和构造函数

        private string _eventNo = "0";

        private List<MED_ANESTHESIA_EVENT_TEMPLET> anesEventTempletAll;
        private List<MED_ANESTHESIA_EVENT_TEMPLET> deleteTempletList = new List<MED_ANESTHESIA_EVENT_TEMPLET>();
        private bool isDeleteSaveEnable = false;
        private bool isPrivateTemplet = false;

        public bool IsPrivateTemplet
        {
            get { return this.isPrivateTemplet; }
            set
            {
                this.isPrivateTemplet = value;
                this.RaisePropertyChanged("IsPrivateTemplet");
            }
        }

        public bool IsDeleteSaveEnable
        {
            get { return this.isDeleteSaveEnable; }
            set
            {
                this.isDeleteSaveEnable = value;
                this.RaisePropertyChanged("IsDeleteSaveEnable");
            }
        }


        private TreeViewData _treeViewData;
        /// <summary>
        /// 模板分类列表
        /// </summary>
        public TreeViewData TreeViewData
        {
            get { return _treeViewData; }
            set
            {
                _treeViewData = value;
                RaisePropertyChanged("TreeViewData");
            }
        }

        private List<MED_ANESTHESIA_EVENT_TEMPLET> _anesEventTemplet;
        /// <summary>
        /// 麻醉路径内容
        /// </summary>
        public List<MED_ANESTHESIA_EVENT_TEMPLET> AnesEventTemplet
        {
            get { return _anesEventTemplet; }
            set
            {
                _anesEventTemplet = value;
                RaisePropertyChanged("AnesEventTemplet");
            }
        }

        private DateTime _applyTime;

        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set
            {
                _applyTime = value;
                RaisePropertyChanged("ApplyTime");
            }
        }

        private string _totalCount;
        /// <summary>
        /// 个数
        /// </summary>
        public string TotalCount
        {
            get { return _totalCount; }
            set
            {
                _totalCount = value;
                RaisePropertyChanged("TotalCount");
            }
        }


        #endregion

        public AnesthesiaPathViewModel()
        {
            anesEventTempletAll = AnesInfoService.ClientInstance.GetAnesEventTemplet();
            InitTreeList();
            var operMaster = AnesInfoService.ClientInstance.GetOperationMaster(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
            ApplyTime = operMaster.IN_DATE_TIME.Value;
        }

        protected override bool CheckDataChange()
        {
            bool result = false;
            if (this.anesEventTempletAll != null)
            {
                foreach (var item in this.anesEventTempletAll)
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

        public void DeleteTemplate(object obj)
        {
            if(obj != null && obj is MED_ANESTHESIA_EVENT_TEMPLET)
            {
                MED_ANESTHESIA_EVENT_TEMPLET row = obj as MED_ANESTHESIA_EVENT_TEMPLET;
                this.IsDeleteSaveEnable = true;
                row.ModelStatus = ModelStatus.Deleted;
                this.deleteTempletList.Add(row);
                this.anesEventTempletAll.Remove(row);
                this.AnesEventTemplet.Remove(row);
                this.AnesEventTemplet = new List<MED_ANESTHESIA_EVENT_TEMPLET>(this.AnesEventTemplet);
                TotalCount = "共" + AnesEventTemplet.Count + "条记录";
            }
        }

        /// <summary>
        /// 初始化模板列表
        /// </summary>
        private void InitTreeList()
        {
            if (null != this._treeViewData)
            {
                this.TreeViewData = null;
            }

            this.TreeViewData = new TreeViewData();

            var rn1 = new TreeNode() { Label = "麻醉事件模板", Level = 1 };
            var subNode1 = new TreeNode() { Label = "共用", Level = 2 };
            rn1.ChildNodes.Add(subNode1);
            var subNode2 = new TreeNode() { Label = "私有", Level = 2 };
            rn1.ChildNodes.Add(subNode2);

            var eventTempletRows = anesEventTempletAll.Where(x => x.CREATE_BY == "公用"
                || x.CREATE_BY == ExtendAppContext.Current.LoginUser.USER_JOB_ID &&
                (x.TEMPLET_CLASS == "0" || x.TEMPLET_CLASS == "2")).GroupBy(x => new { x.CREATE_BY, x.ANESTHESIA_METHOD })
                .Select(group => new { key = group.Key });
            foreach (var item in eventTempletRows)
            {
                var childNode = new TreeNode() { Label = item.key.ANESTHESIA_METHOD, Level = 3 };
                var subEventTempletRows = anesEventTempletAll.Where(x => x.CREATE_BY == item.key.CREATE_BY &&
                    x.ANESTHESIA_METHOD == item.key.ANESTHESIA_METHOD && (x.TEMPLET_CLASS == "0" || x.TEMPLET_CLASS == "2"))
                    .GroupBy(x => new { x.CREATE_BY, x.ANESTHESIA_METHOD, x.TEMPLET_NAME, x.TEMPLET_CLASS })
                    .Select(group => new { key = group.Key });
                foreach (var subitem in subEventTempletRows)
                {
                    var subChildNode = new TreeNode() { Label = subitem.key.TEMPLET_NAME, Level = 4, Tag = subitem.key, Parent = childNode };
                    childNode.ChildNodes.Add(subChildNode);
                }
                if (item.key.CREATE_BY == "公用")
                {
                    childNode.Parent = subNode1;
                    subNode1.ChildNodes.Add(childNode);
                }
                else
                {
                    childNode.Parent = subNode2;
                    subNode2.ChildNodes.Add(childNode);
                }
            }

            _treeViewData.RootNodes.Add(rn1);
            _totalCount = "共0条记录";
        }

        #region Commands
        public ICommand TreeViewItemClickCommand
        {
            get
            {
                return new RelayCommand<TreeNode>(key =>
                {
                    if (key.Tag == null)
                    {
                        AnesEventTemplet = new List<MED_ANESTHESIA_EVENT_TEMPLET>();
                    }
                    else
                    {
                        AnesEventTemplet = anesEventTempletAll.Where(x => x.CREATE_BY == key.Tag.CREATE_BY &&
                                           x.ANESTHESIA_METHOD == key.Tag.ANESTHESIA_METHOD
                                           && x.TEMPLET_NAME == key.Tag.TEMPLET_NAME
                                           && x.TEMPLET_CLASS == key.Tag.TEMPLET_CLASS).ToList();

                        if(key.Tag.CREATE_BY == "公用")
                        {
                            this.IsPrivateTemplet = false;
                        }
                        else
                        {
                            this.IsPrivateTemplet = true;
                        }
                    }
                    TotalCount = "共" + AnesEventTemplet.Count + "条记录";

                });
            }
        }

        public ICommand ResetCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    var message = new ShowContentWindowMessage("OperationMedNoteControl", "麻醉用药及事件");
                    message.Title = "麻醉用药及事件";
                    message.Height = 600;
                    message.Width = 750;
                    message.Args = new object[] { AnesEventTemplet, ApplyTime };
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    this.CloseContentWindow();
                });
            }
        }

        /// <summary>
        /// 保存删除的模板
        /// </summary>
        public ICommand DeleteSaveCommand
        {
            get
            {
                return new RelayCommand<object>(key =>
                {
                    this.ShowMessageBox("确认保存修改后的模板？", MessageBoxButton.YesNo, MessageBoxImage.Question, 
                        new Action<MessageBoxResult>((r) =>
                        {
                            if(r == MessageBoxResult.OK || r == MessageBoxResult.Yes)
                            {
                                AnesInfoService.ClientInstance.SaveAnesEventTemplet(this.deleteTempletList);
                                this.IsDeleteSaveEnable = false;
                            }
                        }));
                });
            }
        }

        /// <summary>
        /// 删除整个模板
        /// </summary>
        public ICommand TreeViewItemDeleteCommand
        {
            get
            {
                return new RelayCommand<TreeNode>(key =>
                {
                    this.ShowMessageBox("确认删除当前模板？",
                                        MessageBoxButton.YesNoCancel,
                                        MessageBoxImage.Question,
                                        new Action<MessageBoxResult>((r) =>
                                        {
                                            if (r == MessageBoxResult.Yes || r == MessageBoxResult.OK)
                                            {
                                                List<MED_ANESTHESIA_EVENT_TEMPLET> tempList = new List<MED_ANESTHESIA_EVENT_TEMPLET>(this.anesEventTempletAll);
                                                var deleteList = new List<MED_ANESTHESIA_EVENT_TEMPLET>();// 只删除需要删除的，提高速度
                                                tempList.ForEach(x =>
                                                {
                                                    if (x.ANESTHESIA_METHOD.Equals(key.Tag.ANESTHESIA_METHOD) &&
                                                        x.TEMPLET_NAME.Equals(key.Tag.TEMPLET_NAME) &&
                                                        x.TEMPLET_CLASS == "2" &&
                                                        x.CREATE_BY == key.Tag.CREATE_BY)
                                                    {
                                                        x.ModelStatus = ModelStatus.Deleted;
                                                        deleteList.Add(x);
                                                    }
                                                });

                                                if (AnesInfoService.ClientInstance.SaveAnesEventTemplet(deleteList))
                                                {
                                                    ShowMessageBox("删除成功！", MessageBoxButton.OK, MessageBoxImage.Information);
                                                    anesEventTempletAll = AnesInfoService.ClientInstance.GetAnesEventTemplet();
                                                    this.InitTreeList();
                                                    this.AnesEventTemplet = null;
                                                }
                                            }
                                        }));
                });
            }
        }

        #endregion
    }
}
