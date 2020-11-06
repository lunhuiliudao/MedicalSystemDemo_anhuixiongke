using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using System.Linq;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(true)]
    public partial class SelectMonitor : BaseView
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        public SelectMonitor(MED_PATIENT_CARD patientInfo, decimal eventNo, string roomNo, bool isSelect)
        {
            _patientInfo = patientInfo;
            _eventNo = eventNo;
            _roomNo = roomNo;
            InitializeComponent();
            this.panelSelect.Visible = isSelect;
            medDataGridView1.AutoGenerateColumns = false;
            MonitorLoad();
        }

        private MED_PATIENT_CARD _patientInfo;
        private decimal _eventNo;
        private string _roomNo;
        private List<MED_OPERATING_ROOM> _roomList;
        /// <summary>
        /// 监护仪表
        /// </summary>
        private List<MED_MONITOR_DICT> _monitorList;
        private void MonitorLoad()
        {
            List<MED_MONITOR_DICT> dict = comnDictRepository.GetMonitorDictList().Data;
            if (_eventNo != 1 && _patientInfo == null)
            {
                return;
            }
            if (!DesignMode)
            {
                _monitorList = dict.Where(p => p.WARD_TYPE == _eventNo && p.WARD_CODE == ExtendApplicationContext.Current.OperRoom && p.BED_NO == _roomNo).ToList();

                foreach (MED_MONITOR_DICT row in _monitorList)
                {
                    if (row.ITEM_TYPE.Equals("0")) row.MONITOR_TYPE = "监护仪";
                    else if (row.ITEM_TYPE.Equals("1")) row.MONITOR_TYPE = "麻醉机";
                }
                medDataGridView1.DataSource = _monitorList;
            }
            this.SetDefaultGridViewStyle(medDataGridView1);
        }
        private void SelectMonitor_Load(object sender, EventArgs e)
        {
            // MonitorLoad();
        }
        public bool Save()
        {
            bool returnData = true;
            foreach (MED_MONITOR_DICT row in _monitorList)
            {
                if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.PATIENT_ID != ExtendApplicationContext.Current.PatientContextExtend.PatientID)
                {
                    if (DialogResult.No == MessageBoxFormPC.Show("您选择的仪器" + row.MONITOR_LABEL + "正被病人 " + row.PATIENT_ID + " 使用， 是否强制使用此仪器？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        return false;
                }
                row.PATIENT_ID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
                row.VISIT_ID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
                row.OPER_ID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
                bool yes = false;
                if (!string.IsNullOrEmpty(row.DRIVER_PROG))
                {
                    string exeName = row.DRIVER_PROG;
                    if (!string.IsNullOrEmpty(exeName))
                    {
                        if (!exeName.ToLower().EndsWith(".exe"))
                        {
                            exeName = exeName + ".exe";
                        }
                        exeName = ExtendApplicationContext.Current.AppPath + exeName;
                        //exeName = Globals.AppPath + "runCaiji.bat";
                        if (System.IO.File.Exists(exeName))
                        {
                            ShellExecute(0, "Open", exeName, "", "", 0);
                            yes = true;
                        }
                        else
                        {
                            MessageBoxFormPC.Show("采集程序" + exeName + "不存在", MessageBoxIcon.Information);
                        }
                    }
                }
                if (!yes)
                {
                    MessageBoxFormPC.Show(row.MONITOR_LABEL + "仪器没启动", MessageBoxIcon.Information);
                    return false;
                }
            }
            returnData = comnDictRepository.SaveMonitorDictList(_monitorList).Data > 0 ? true : false;
            return returnData;
        }

        [DllImportAttribute("shell32.dll")]
        private static extern IntPtr ShellExecute(int hWnd, string Operation, string FileName, string Dir, string Parameters, int ShowCmd);

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void btnNext_BtnClicked(object sender, EventArgs e)
        {
            if (Save())
                ParentForm.DialogResult = DialogResult.OK;
        }
    }
}
