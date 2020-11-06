using System.Collections.Generic;
using System.Windows.Forms;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatientInfoSureControl : BaseView
    {
        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();


        private List<MED_PATIENT_CARD> _patientCard = null;
        private MED_PATIENT_CARD _selectPatientCard = null;

        public MED_PATIENT_CARD SelectPatientCard
        {
            get { return _selectPatientCard; }
            set { _selectPatientCard = value; }
        }
        public DialogResult result = DialogResult.Cancel;
        public PatientInfoSureControl()
        {
            InitializeComponent();
            dgPatientInfo.AutoGenerateColumns = false;
        }
        public PatientInfoSureControl(List<MED_PATIENT_CARD> patientCard)
            : this()
        {
            _patientCard = patientCard;
            this.SetDefaultGridViewStyle(dgPatientInfo);
            PatientInfoLoad();
        }
        private void PatientInfoLoad()
        {
            if (_patientCard != null && _patientCard.Count > 0)
            {
                foreach (MED_PATIENT_CARD row in _patientCard)
                {
                    if (row.EMERGENCY_IND == 1) row.EMERGENCY_NAME = "急诊";
                    else row.EMERGENCY_NAME = "择期";
                }
            }
            dgPatientInfo.DataSource = _patientCard;
        }
        private void dgPatientInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPatientInfo.CurrentCell != null)
            {
                string patientID = dgPatientInfo.Rows[e.RowIndex].Cells["ColumnPatientID"].Value.ToString();
                int visitID = (int)dgPatientInfo.Rows[e.RowIndex].Cells["ColumnVisitID"].Value;
                int operID = (int)dgPatientInfo.Rows[e.RowIndex].Cells["ColumnOperID"].Value;
                ExtendApplicationContext.Current.PatientContextExtend.PatientID = patientID;
                ExtendApplicationContext.Current.PatientContextExtend.VisitID = visitID;
                ExtendApplicationContext.Current.PatientContextExtend.OperID = operID;
                _selectPatientCard = patientInfoRepository.GetPatCard(patientID, visitID, operID).Data;
                result = DialogResult.OK;
                ParentForm.DialogResult = DialogResult.OK;
            }
        }
    }
}
