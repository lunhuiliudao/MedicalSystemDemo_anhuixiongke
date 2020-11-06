using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class AnesShiftRegisteListControl : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();



        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _shiftDuty;
        private List<MED_SHIFT_INFO> shitInfoList = null;
        private List<MED_OPERATION_SHIFT_RECORD> shiftRecordList = null;
        private List<MED_HIS_USERS> _hisUsersList = null;
        private MED_OPERATION_MASTER _operMaster = null;
        public AnesShiftRegisteListControl()
        {
            InitializeComponent();
        }
        public AnesShiftRegisteListControl(string shiftDuty)
            : this()
        {
            _shiftDuty = shiftDuty;
            Caption = shiftDuty;
            _patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            _visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            _operID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            dateEditStart.DateTime = accountRepository.GetServerTime().Data;
        }

        private void AnesShiftRegisteListControl_Load(object sender, EventArgs e)
        {
            this.SetDefaultGridViewStyle(dgControlShitRegister);
            _hisUsersList = ExtendApplicationContext.Current.CommDict.HisUsersDict;
            if (_shiftDuty.Equals("麻醉交班"))
                _hisUsersList = _hisUsersList.Where(p => p.USER_DEPT_CODE == ExtendApplicationContext.Current.AnesthesiaWardCode).ToList();
            else if (_shiftDuty.Equals("护士交班"))
                _hisUsersList = _hisUsersList.Where(p => p.USER_DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
            _operMaster = operationInfoRepository.GetOperMaster(_patientID, _visitID, _operID).Data;
            string[] dutyList = new string[] { "" };
            shitInfoList = new List<MED_SHIFT_INFO>();
            if (_shiftDuty.Equals("麻醉交班"))
            {
                dutyList = new string[] { "主麻", "麻醉助手1", "麻醉助手2", "麻醉助手3", "麻醉助手4", "灌注医生", "灌注医生助手1" };
                foreach (string duty in dutyList)
                {
                    MED_SHIFT_INFO shiftInfo = new MED_SHIFT_INFO();
                    shiftInfo.DUTY_NAME = duty;
                    shiftRecordList = operationInfoRepository.GetShiftRecordList(_patientID, _visitID, _operID, duty).Data.ToList();
                    if (shiftRecordList != null && shiftRecordList.Count > 0)
                    {
                        shiftRecordList = shiftRecordList.OrderByDescending(p => p.START_DATE_TIME).ToList();
                        shiftInfo.DUTY_OFFICER = BindControls(shiftRecordList[0].SHIFT_PERSON);
                        shiftInfo.START_TIME = shiftRecordList[0].END_DATE_TIME;
                    }
                    else
                    {
                        shiftInfo.START_TIME = _operMaster.ANES_START_TIME.HasValue ? _operMaster.ANES_START_TIME : accountRepository.GetServerTime().Data;
                        switch (duty)
                        {
                            case "主麻":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.ANES_DOCTOR);
                                break;
                            case "麻醉助手1":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FIRST_ANES_ASSISTANT);
                                break;
                            case "麻醉助手2":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.SECOND_ANES_ASSISTANT);
                                break;
                            case "麻醉助手3":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.THIRD_ANES_ASSISTANT);
                                break;
                            case "麻醉助手4":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FOURTH_ANES_ASSISTANT);
                                break;
                            case "灌注医生":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.CPB_DOCTOR);
                                break;
                            case "灌注医生助手1":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FIRST_CPB_ASSISTANT);
                                break;
                            default:
                                break;
                        }
                    }
                    shitInfoList.Add(shiftInfo);
                }
            }
            else if (_shiftDuty.Equals("护士交班"))
            {
                dutyList = new string[] { "第一台上护士", "第二台上护士", "第三台上护士", "第四台上护士", "第一供应护士", "第二供应护士", "第三供应护士", "第四供应护士" };
                foreach (string duty in dutyList)
                {
                    MED_SHIFT_INFO shiftInfo = new MED_SHIFT_INFO();
                    shiftInfo.DUTY_NAME = duty;
                    shiftRecordList = operationInfoRepository.GetShiftRecordList(_patientID, _visitID, _operID, duty).Data.ToList();
                    if (shiftRecordList != null && shiftRecordList.Count > 0)
                    {
                        shiftRecordList = shiftRecordList.OrderByDescending(p => p.START_DATE_TIME).ToList();
                        shiftInfo.DUTY_OFFICER = BindControls(shiftRecordList[0].SHIFT_PERSON);
                        shiftInfo.START_TIME = shiftRecordList[0].END_DATE_TIME;
                    }
                    else
                    {
                        shiftInfo.START_TIME = _operMaster.IN_DATE_TIME.HasValue ? _operMaster.IN_DATE_TIME : accountRepository.GetServerTime().Data;
                        switch (duty)
                        {
                            case "第一台上护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FIRST_OPER_NURSE);
                                break;
                            case "第二台上护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.SECOND_OPER_NURSE);
                                break;
                            case "第三台上护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.THIRD_OPER_NURSE);
                                break;
                            case "第四台上护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FOURTH_OPER_NURSE);
                                break;
                            case "第一供应护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FIRST_SUPPLY_NURSE);
                                break;
                            case "第二供应护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.SECOND_SUPPLY_NURSE);
                                break;
                            case "第三供应护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.THIRD_SUPPLY_NURSE);
                                break;
                            case "第四供应护士":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FOURTH_SUPPLY_NURSE);
                                break;
                            default:
                                break;
                        }
                    }
                    shitInfoList.Add(shiftInfo);
                }
            }
            else if (_shiftDuty.Equals("手术交班"))
            {
                dutyList = new string[] { "术者", "第一手术助理", "第二手术助理", "第三手术助理", "第四手术助理" };
                foreach (string duty in dutyList)
                {
                    MED_SHIFT_INFO shiftInfo = new MED_SHIFT_INFO();
                    shiftInfo.DUTY_NAME = duty;
                    shiftRecordList = operationInfoRepository.GetShiftRecordList(_patientID, _visitID, _operID, duty).Data.ToList();
                    if (shiftRecordList != null && shiftRecordList.Count > 0)
                    {
                        shiftRecordList = shiftRecordList.OrderByDescending(p => p.START_DATE_TIME).ToList();
                        shiftInfo.DUTY_OFFICER = BindControls(shiftRecordList[0].SHIFT_PERSON);
                        shiftInfo.START_TIME = shiftRecordList[0].END_DATE_TIME;
                    }
                    else
                    {
                        shiftInfo.START_TIME = _operMaster.START_DATE_TIME.HasValue ? _operMaster.START_DATE_TIME : accountRepository.GetServerTime().Data;
                        switch (duty)
                        {
                            case "术者":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.SURGEON);
                                break;
                            case "第一手术助理":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FIRST_OPER_ASSISTANT);
                                break;
                            case "第二手术助理":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.SECOND_OPER_ASSISTANT);
                                break;
                            case "第三手术助理":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.THIRD_OPER_ASSISTANT);
                                break;
                            case "第四手术助理":
                                shiftInfo.DUTY_OFFICER = BindControls(_operMaster.FOURTH_OPER_ASSISTANT);
                                break;
                            default:
                                break;
                        }
                    }
                    shitInfoList.Add(shiftInfo);
                }
            }
            dgControlShitRegister.DataSource = shitInfoList;
        }
        public string BindControls(string code)
        {
            string value = code;
            List<MED_HIS_USERS> hisUserList = ExtendApplicationContext.Current.CommDict.HisUsersDict;
            foreach (MED_HIS_USERS user in hisUserList)
            {
                if (user.USER_JOB_ID == code) { value = user.USER_NAME; break; }
            }
            return value;
        }
        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            if (shitInfoList != null && shitInfoList.Count > 0)
            {
                foreach (MED_SHIFT_INFO info in shitInfoList)
                {
                    if (!string.IsNullOrEmpty(info.SUCCESSION_ID))
                    {
                        MED_OPERATION_SHIFT_RECORD record = new MED_OPERATION_SHIFT_RECORD();
                        record.PATIENT_ID = _patientID;
                        record.VISIT_ID = _visitID;
                        record.OPER_ID = _visitID;
                        record.SHIFT_DUTY = info.DUTY_NAME;
                        record.PERSON = info.DUTY_OFFICER;
                        record.SHIFT_PERSON = info.SUCCESSION_ID;
                        record.START_DATE_TIME = info.START_TIME.Value;
                        record.END_DATE_TIME = dateEditStart.DateTime;
                        record.SHIFT_DATE_TIME = accountRepository.GetServerTime().Data;
                        shiftRecordList.Add(record);
                    }
                }
                operationInfoRepository.SaveShiftRecordList(shiftRecordList);
            }
            ParentForm.DialogResult = DialogResult.OK;
        }

        private void buttonColor1_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void dgControlShitRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgControlShitRegister.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            if (dgControlShitRegister.Columns[e.ColumnIndex].Name.Equals("ColumnDuty"))
            {
                Rectangle rect = dgControlShitRegister.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Dialog.ShowCustomSelection(_hisUsersList, "USER_NAME", dgControlShitRegister, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate(object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dgControlShitRegister.CurrentCell.Value = _hisUsersList[index].USER_NAME;
                            dgControlShitRegister.CurrentRow.Cells["Column2"].Value = _hisUsersList[index].USER_JOB_ID;
                            dgControlShitRegister.EndEdit();
                        }
                    }));
            }
        }
    }
}
