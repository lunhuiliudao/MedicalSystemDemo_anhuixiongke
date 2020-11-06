using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ChangePacuRoom : UserControl
    {

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        string _patientID = string.Empty;
        int _visitID = 0;
        int _operID = 0;
        string newRoomNo = "";
        string oldRoomNo = "";
        public DialogResult result = DialogResult.Cancel;

        public ChangePacuRoom()
        {
            InitializeComponent();
            _patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            _visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            _operID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            ContextMenu emptyMenu = new System.Windows.Forms.ContextMenu();
            txtPacuNo.Properties.ContextMenu = emptyMenu;
        }

        public ChangePacuRoom(string patientID, int visitID, int operID)
        {
            InitializeComponent();
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            ContextMenu emptyMenu = new System.Windows.Forms.ContextMenu();
            txtPacuNo.Properties.ContextMenu = emptyMenu;
        }

        public bool SetMonitorDictPatient(string wardType, string wardCode, string oldRoomNo, string newRoomNo, string patientID, int visitID, int operID)
        {
            if (!string.IsNullOrEmpty(wardCode) && !string.IsNullOrEmpty(oldRoomNo) && !string.IsNullOrEmpty(newRoomNo))
            {
                List<MED_MONITOR_DICT> monitorTable = comnDictRepository.GetMonitorDictList(wardType).Data;
                if (monitorTable != null && monitorTable.Count > 0)
                {
                    monitorTable.ForEach(row =>
                    {
                        if (!string.IsNullOrEmpty(row.WARD_CODE) && !string.IsNullOrEmpty(row.BED_NO)
                            && row.WARD_CODE.Equals(wardCode) && row.BED_NO.Equals(newRoomNo))
                        {
                            if (string.IsNullOrEmpty(patientID))
                            {
                                row.PATIENT_ID = patientID;
                                row.VISIT_ID = null;
                                row.OPER_ID = null;
                            }
                            else
                            {
                                row.PATIENT_ID = patientID;
                                row.VISIT_ID = visitID;
                                row.OPER_ID = operID;
                            }
                        }
                        else if (!string.IsNullOrEmpty(row.WARD_CODE) && !string.IsNullOrEmpty(row.BED_NO)
                            && row.WARD_CODE.Equals(wardCode) && row.BED_NO.Equals(oldRoomNo))
                        {
                            row.PATIENT_ID = null;
                            row.VISIT_ID = null;
                            row.OPER_ID = null;
                        }
                    });
                    if (comnDictRepository.SaveMonitorDictList(monitorTable).Data > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ChangePacuRoom_Load(object sender, EventArgs e)
        {
            List<MED_OPERATING_ROOM> operatingRoomList = comnDictRepository.GetOperatingRoomList("1").Data;
            MED_OPERATING_ROOM operatingRoom = operatingRoomList.Find(x => x.PATIENT_ID == _patientID
                   && x.VISIT_ID == _visitID && x.OPER_ID == _operID);
            if (operatingRoom != null)
            {
                lblCurrentRoom.Text = operatingRoom.ROOM_NO;
                oldRoomNo = operatingRoom.ROOM_NO;
            }
        }

        private void btnSave_BtnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPacuNo.Text))
            {
                MessageBoxFormPC.Show("复苏床位为必填项目！",
             "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            newRoomNo = txtPacuNo.Text;

            List<MED_OPERATING_ROOM> operatingRoomList = comnDictRepository.GetOperatingRoomList("1").Data;
            MED_OPERATING_ROOM newOperatingRoom = operatingRoomList.Find(x => x.ROOM_NO == newRoomNo);

            //MED_OPERATING_ROOM newOperatingRoom = comnDictRepository.GetOperatingRoomByRoomNo("1", newRoomNo).Data;

            bool isUpdate = true;
            if (newOperatingRoom != null)
            {
                newOperatingRoom.PATIENT_ID = _patientID;
                newOperatingRoom.VISIT_ID = _visitID;
                newOperatingRoom.OPER_ID = _operID;

                isUpdate = new OperatingRoomRepository().SetOperatingRoomPatient(operatingRoomList, newRoomNo, ExtendApplicationContext.Current.OperRoom, _patientID, _visitID, _operID);
            }

            if (isUpdate)
            {
                List<MED_OPERATING_ROOM> RoomList = comnDictRepository.GetOperatingRoomList("1").Data;

                MED_OPERATING_ROOM operatingRoom = RoomList.Find(x => x.PATIENT_ID == _patientID
                    && x.VISIT_ID == _visitID && x.OPER_ID == _operID && x.ROOM_NO == oldRoomNo);

                if (operatingRoom != null)
                {
                    operatingRoom.PATIENT_ID = null;
                    operatingRoom.VISIT_ID = null;
                    operatingRoom.OPER_ID = null;
                    comnDictRepository.SaveOperatingRoom(operatingRoom);
                }
                SetMonitorDictPatient("1", ExtendApplicationContext.Current.OperRoom, oldRoomNo, newRoomNo, _patientID, _visitID, _operID);
                result = DialogResult.OK;
                ParentForm.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBoxFormPC.Show("床位被占用，请重新选择",
                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }
    }
}
