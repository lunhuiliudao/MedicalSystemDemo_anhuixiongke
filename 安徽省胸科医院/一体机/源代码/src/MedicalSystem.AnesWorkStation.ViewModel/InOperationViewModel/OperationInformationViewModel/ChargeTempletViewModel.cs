using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Wpf.Controls.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    /// <summary>
    /// 麻醉计费模板的ViewModel
    /// </summary>
    public class ChargeTempletViewModel : BaseViewModel
    {
        private List<MED_ANES_BILL_TEMPLET> _billTempletList = null;//收费模板表
        private List<MED_BILL_TEMPLET_MASTER> _templetList = null;// 模板名称列表
        private List<MED_ANES_BILL_TEMPLET> _anesBillList = null; //当前选中模板
        private List<MED_BILL_ITEM_CLASS_DICT> _billDict = null;
        private List<MED_BILL_TEMPLET_MASTER> _templetAllList = null;
        private ICommand templateCommon = null;//套用模板
        private ICommand cannelTemplateCommon = null;//取消套用模板

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
        /// <summary>
        ///收费模板表
        /// </summary>
        public List<MED_ANES_BILL_TEMPLET> BillTempletList
        {
            get { return this._billTempletList; }
            set
            {
                this._billTempletList = value;
                this.RaisePropertyChanged("BillTempletList");
            }
        }
        public List<MED_ANES_BILL_TEMPLET> AnesBillList
        {
            get { return this._anesBillList; }
            set
            {
                this._anesBillList = value;
                this.RaisePropertyChanged("AnesBillList");
            }
        }
        /// <summary>
        ///模板名称列表
        /// </summary>
        public List<MED_BILL_TEMPLET_MASTER> TempletList
        {
            get { return this._templetList; }
            set
            {
                this._templetList = value;
                this.RaisePropertyChanged("TempletList");
            }
        }


        /// <summary>
        /// 套用模板
        /// </summary>
        public ICommand TemplateCommon
        {
            get { return this.templateCommon; }
            set { this.templateCommon = value; }
        }
        /// <summary>
        /// 取消套用模板
        /// </summary>
        public ICommand CannelTemplateCommon
        {
            get { return this.cannelTemplateCommon; }
            set { this.cannelTemplateCommon = value; }
        }
        /// <summary>
        /// 保存返回值
        /// </summary>
        SaveResult saveResult = SaveResult.Fail;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ChargeTempletViewModel()
        {
            this.RegisterCommand();
            _billTempletList = ChargeInfoService.ClientInstance.GetBillTempletList();
            InitTreeList();
            _billDict = ApplicationModel.Instance.AllDictList.BillItemClassDictList;
            _templetAllList = ChargeInfoService.ClientInstance.GetTempletMaster();
            if (_billTempletList != null && _billTempletList.Count > 0 && _templetAllList != null && _templetAllList.Count > 0)
            {
                _anesBillList = _billTempletList.Where(x => x.TEMPLET == _templetAllList[0].TEMPLET).ToList();
                foreach (MED_ANES_BILL_TEMPLET row in _anesBillList)
                {
                    if (!string.IsNullOrEmpty(row.ITEM_CLASS) && string.IsNullOrEmpty(row.ITEM_CLASS_NAME))
                    {
                        row.ITEM_CLASS_NAME = _billDict.Where(x => x.BILL_CLASS_CODE == row.ITEM_CLASS).FirstOrDefault().BILL_CLASS_NAME;
                        row.ITEM_SPEC = row.ITEM_SPEC + row.UNITS;
                    }
                }
            }
            AnesBillList = _anesBillList;
            TempletList = _templetAllList;
        }
        /// <summary>
        /// 初始化模板列表
        /// </summary>
        private void InitTreeList()
        {
            _treeViewData = new TreeViewData();
            var rn1 = new TreeNode() { Label = "收费模板", Level = 1 };
            var childNode = new TreeNode();
            foreach (var item in _billTempletList)
            {
                if (childNode.Label == null || !childNode.Label.Equals(item.ANESTHESIA_METHOD))
                    childNode = new TreeNode() { Label = item.ANESTHESIA_METHOD, Level = 2 };
                else continue;

                var subEventTempletRows = _billTempletList.Where(x => x.ANESTHESIA_METHOD == item.ANESTHESIA_METHOD)
                    .GroupBy(x => new { x.ANESTHESIA_METHOD, x.TEMPLET })
                    .Select(group => new { key = group.Key });
                foreach (var subitem in subEventTempletRows)
                {
                    var subChildNode = new TreeNode() { Label = subitem.key.TEMPLET, Level = 3, Tag = subitem.key };
                    childNode.ChildNodes.Add(subChildNode);
                }
                rn1.ChildNodes.Add(childNode);
            }

            _treeViewData.RootNodes.Add(rn1);
        }
        /// <summary>
        /// 注册命令信息
        /// </summary>
        private void RegisterCommand()
        {
            this.TemplateCommon = new RelayCommand<List<MED_ANES_BILL_TEMPLET>>(par =>
            {
                this.Result = AnesBillList;
                this.CloseContentWindow();
            });
            this.CannelTemplateCommon = new RelayCommand<object>(par =>
            {
                this.CloseContentWindow();
            });
        }
        /// <summary>
        /// 套用模板
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            this.Result = "";
            Messenger.Default.Send<object>(this.Result, "BtnSureCommand");
            return SaveResult.CancelMessageBox;
        }
        public void TemplateSelectionChanged(string templet)
        {
            _anesBillList = _billTempletList.Where(x => x.TEMPLET == templet).ToList();
            foreach (MED_ANES_BILL_TEMPLET row in _anesBillList)
            {
                if (!string.IsNullOrEmpty(row.ITEM_CLASS) && string.IsNullOrEmpty(row.ITEM_CLASS_NAME))
                {
                    row.ITEM_CLASS_NAME = _billDict.Where(x => x.BILL_CLASS_CODE == row.ITEM_CLASS).FirstOrDefault().BILL_CLASS_NAME;
                    row.ITEM_SPEC = row.ITEM_SPEC + row.UNITS;
                }
            }
            AnesBillList = _anesBillList;
        }

        public ICommand TreeViewItemClickCommand
        {
            get
            {
                return new RelayCommand<TreeNode>(key =>
                {
                    if (key.Tag == null)
                    {
                        AnesBillList = new List<MED_ANES_BILL_TEMPLET>();
                    }
                    else
                    {
                        _anesBillList = _billTempletList.Where(x => x.ANESTHESIA_METHOD == key.Tag.ANESTHESIA_METHOD
                                           && x.TEMPLET == key.Tag.TEMPLET).ToList();
                        foreach (MED_ANES_BILL_TEMPLET row in _anesBillList)
                        {
                            if (!string.IsNullOrEmpty(row.ITEM_CLASS) && string.IsNullOrEmpty(row.ITEM_CLASS_NAME))
                            {
                                row.ITEM_CLASS_NAME = _billDict.Where(x => x.BILL_CLASS_CODE == row.ITEM_CLASS).FirstOrDefault().BILL_CLASS_NAME;
                                row.ITEM_SPEC = row.ITEM_SPEC + row.UNITS;
                            }
                        }
                        AnesBillList = _anesBillList;
                    }
                });
            }
        }
    }
}
