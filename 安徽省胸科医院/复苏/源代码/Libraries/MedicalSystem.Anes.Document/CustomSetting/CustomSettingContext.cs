using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    public class CustomSettingContext
    {
        private bool _IsCheckInfoShowDialog = false;
        /// <summary>
        /// 病历病程 是否窗体显示，True为窗体显示，False为直接调用
        /// </summary>
        public bool IsCheckInfoShowDialog
        {
            get { return _IsCheckInfoShowDialog; }
            set { _IsCheckInfoShowDialog = value; }
        }
        private bool _IsHisCheckInfo = false;
        /// <summary>
        /// 检查结果 是否窗体显示，True为窗体显示，False为直接调用
        /// </summary>
        public bool IsHisCheckInfo
        {
            get { return _IsHisCheckInfo; }
            set { _IsHisCheckInfo = value; }
        }

        private bool _IsShowAnesthesiaEventsEditor = true;
        /// <summary>
        /// 是否显示事件编辑
        /// </summary>
        public bool IsShowAnesthesiaEventsEditor
        {
            get { return _IsShowAnesthesiaEventsEditor; }
            set { _IsShowAnesthesiaEventsEditor = value; }
        }

        private bool _IsShowPatMonitorEditor = true;
        /// <summary>
        /// 是否显示采集数据编辑
        /// </summary>
        public bool IsShowPatMonitorEditor
        {
            get { return _IsShowPatMonitorEditor; }
            set { _IsShowPatMonitorEditor = value; }
        }

        private bool _IsAddPacuSpecialItems = false;
        /// <summary>
        /// 是否自动添加复苏瞳孔采集项
        /// </summary>
        public bool IsAddPacuSpecialItems
        {
            get { return _IsAddPacuSpecialItems; }
            set { _IsAddPacuSpecialItems = value; }
        }

        private List<string> _customTempletFlagNames = new List<string>();
        /// <summary>
        /// 客户化自定义文书模板标识列表
        /// </summary>
        public List<string> CustomTempletFlagNames
        {
            get { return _customTempletFlagNames; }
            set { _customTempletFlagNames = value; }
        }

        private bool _isShowDevDateTimeEditor = false;
        /// <summary>
        /// 是否在文书中切换使用Dev时间日期控件
        /// </summary>
        public bool IsShowDevDateTimeEditor
        {
            get { return _isShowDevDateTimeEditor; }
            set { _isShowDevDateTimeEditor = value; }
        }


        private bool _isSyncScheduleInfo = true;
        /// <summary>
        /// 是否在文书中同步手术申请
        /// </summary>
        public bool IsSyncScheduleInfo
        {
            get { return _isSyncScheduleInfo; }
            set { _isSyncScheduleInfo = value; }
        }


        // 是否在术中登记中显示增加项目
        private bool _isShowAddProjAtResigister = true;
        public bool IsShowAddProjAtResigister
        {
            get { return _isShowAddProjAtResigister; }
            set { _isShowAddProjAtResigister = value; }
        }


        private bool _isShowUnDonePatientListView = false;
        /// <summary>
        /// 程序登入后是否弹出显示术中患者列表
        /// </summary>
        public bool IsShowUnDonePatientListView
        {
            get { return _isShowUnDonePatientListView; }
            set { _isShowUnDonePatientListView = value; }
        }




        private bool _isCheckDocCompelete = false;
        /// <summary>
        /// 程序登入后是否要检查文书流程完整功能
        /// </summary>
        public bool IsCheckDocCompelete
        {
            get { return _isCheckDocCompelete; }
            set { _isCheckDocCompelete = value; }
        }
    }
}
