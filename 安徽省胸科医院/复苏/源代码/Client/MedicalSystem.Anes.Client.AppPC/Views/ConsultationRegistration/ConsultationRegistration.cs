using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC.Views.ConsultationRegistration
{
    public partial class ConsultationRegistration : UserControl
    {
        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        private bool bPatientID_Change = false;
        public bool ResultData = false;
        public ConsultationRegistration()
        {
            InitializeComponent();
        }
        private void ConsultationRegistration_Load(object sender, EventArgs e)
        {
            txtInp_no.Focus();
        }

        private void txtInp_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)32))
            {
                e.Handled = true;
            }
            if (e.KeyChar.Equals((char)13))
            {
                if (txtInp_no.Text.Trim() != string.Empty)
                {
                    SyncPatientByInpNo(txtInp_no.Text.Trim());
                }
            }
        }

        private void txtInp_no_Leave(object sender, EventArgs e)
        {
            //如果没有改变，直接返回
            if (!bPatientID_Change) return;
            bPatientID_Change = false;
            SyncPatientByInpNo(txtInp_no.Text.Trim());
        }
        private void SyncPatientByInpNo(string inpNo)
        {
            if (ExtendApplicationContext.Current.IsSync)
            {
                string ret = "";
                ret = syncInfoRepository.SyncPatientInfoAndInHospitalByInpNo(inpNo).Data;
                if (!string.IsNullOrEmpty(ret))
                {
                    MessageBoxFormPC.Show(ret);
                }
            }
            btnSave.Enabled = true;
            if (inpNo != "")
            {
                List<MED_PAT_VISIT> patVisitList = operationInfoRepository.GetPatVisitListByInpNo(inpNo).Data;
                dtScheduledTime.EditValue = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                if (patVisitList != null && patVisitList.Count > 0)
                {
                    MED_PAT_VISIT patRow = patVisitList[0];
                    txtPatientID.Text = patRow.PATIENT_ID;
                    MED_PAT_MASTER_INDEX patMaster = operationInfoRepository.GetPatMasterIndex(patRow.PATIENT_ID).Data;
                    txtPatName.Text = patMaster.NAME;
                    txtPatSex.Text = patMaster.SEX;
                    if (patMaster.DATE_OF_BIRTH.HasValue)
                    {
                        dtBirthDay.EditValue = patMaster.DATE_OF_BIRTH.Value;
                    }
                    else
                    {
                        dtBirthDay.EditValue = null;
                    }
                }
                MED_PATS_IN_HOSPITAL patsHospital = operationInfoRepository.GetPatsInHospital(inpNo).Data;
                if (patsHospital != null)
                {
                    txtBedNo.Text = patsHospital.BED_NO;
                    txtDeptCode.SetData(patsHospital.DEPT_CODE);
                    if (txtDeptCode.Data != null)
                    {
                        List<MED_DEPT_DICT> dataTable = ExtendApplicationContext.Current.CommDict.DeptDict.Where(x => x.DEPT_CODE == patsHospital.DEPT_CODE).ToList();
                        if (dataTable != null && dataTable.Count > 0)
                        {
                            txtDeptCode.Text = dataTable[0].DEPT_NAME;
                        }
                    }
                    txtConcultation.Text = patsHospital.DIAGNOSIS;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<MED_CONSULTATION_REGISTRATION> consRegList = operationInfoRepository.GetConsultationListByID(txtPatientID.Text).Data;
            MED_CONSULTATION_REGISTRATION conRow = new MED_CONSULTATION_REGISTRATION();
            if (consRegList != null)
            {
                conRow.PATIENT_ID = txtPatientID.Text;
                conRow.VISIT_ID = 1;
                List<MED_PAT_VISIT> patVisitList = operationInfoRepository.GetPatVisitList(txtPatientID.Text).Data;
                if (patVisitList != null && patVisitList.Count > 0)
                {
                    conRow.VISIT_ID = Convert.ToInt32(patVisitList[0].GetValue("VISIT_ID"));
                }
                conRow.OPER_ID = 0;
                foreach (MED_CONSULTATION_REGISTRATION row in consRegList)
                {
                    if (row.VISIT_ID > conRow.VISIT_ID)
                    {
                        conRow.VISIT_ID = row.VISIT_ID;
                        conRow.OPER_ID = row.OPER_ID;
                    }
                    else if (row.VISIT_ID == conRow.VISIT_ID)
                    {
                        if (row.OPER_ID > conRow.OPER_ID)
                        {
                            conRow.OPER_ID = row.OPER_ID;
                        }
                    }
                }
                conRow.OPER_ID += 1;
                if (txtBedNo.Text.Trim() != "") conRow.BED_NO = txtBedNo.Text.Trim();
                if (txtDeptCode.Text.Trim() != "") conRow.DEPT_CODE = txtDeptCode.Data.ToString().Trim();
                if (txtConcultation.Text.Trim() != "") conRow.CONSULTATION_REASON = txtConcultation.Text.Trim();
                if (dtScheduledTime.EditValue != null && ((DateTime)dtScheduledTime.EditValue) != DateTime.MinValue) conRow.CONSULTATION_DATE_TIME = (DateTime)dtScheduledTime.EditValue;
                if (txtAnesthesiaMethod.Text.Trim() != "") conRow.ANES_METHOD = txtAnesthesiaMethod.Text.Trim();
                if (txtAnesDoctor1.Data != null && txtAnesDoctor1.Data.ToString().Trim() != "") conRow.ANES_DOCTOR = txtAnesDoctor1.Data.ToString().Trim();
                if (txtAnesDoctor2.Data != null && txtAnesDoctor2.Data.ToString().Trim() != "") conRow.FIRST_ANES_ASSISTANT = txtAnesDoctor2.Data.ToString().Trim();
                if (txtConsultationOther.Text.Trim() != "") conRow.CONSULTATION_OTHER = txtConsultationOther.Text;
                if (txtConsultationOpinions.Text.Trim() != "") conRow.CONSULTATION_OPINIONS = txtConsultationOpinions.Text;

            }
            try
            {
                if (operationInfoRepository.SaveConsultationData(conRow).Data > 0)
                    MessageQueue.AddMessage("会诊数据保存成功!", Color.Black);
                ResultData = true;
                ParentForm.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
    }
}
