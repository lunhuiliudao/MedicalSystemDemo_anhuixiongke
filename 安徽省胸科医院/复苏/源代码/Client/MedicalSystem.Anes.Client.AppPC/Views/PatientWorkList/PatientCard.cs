using System;
using System.Windows.Forms;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using Medicalsystem.Anes.Framework.Utilities;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatientCard : BaseControl
    {

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        public PatientCard()
        {
            InitializeComponent();


            this.SetStyle(ControlStyles.DoubleBuffer |
      ControlStyles.UserPaint |
      ControlStyles.AllPaintingInWmPaint,
      true);
            this.UpdateStyles();


        }
        public PatientCard(MED_PATIENT_CARD patientInformation)
            : this()
        {
            _patCard = patientInformation;
        }
        private MED_PATIENT_CARD _patCard = null;
        public MED_PATIENT_CARD PatCard
        {
            get
            {
                return _patCard;
            }
            set
            {
                _patCard = value;
            }
        }
        public void CancelFocus()
        {
            Selected = false;
        }
        public void RefreshCard()
        {
            ClearCard();
            if (_patCard != null)
            {
                CardVisible(true);
                lbRoomSequence.Text = _patCard.OPER_ROOM_NO;
                if (!string.IsNullOrEmpty(_patCard.SEQUENCE.ToString()))
                {
                    lbRoomSequence.Text = _patCard.OPER_ROOM_NO + "-" + Convert.ToInt16(_patCard.SEQUENCE).ToString();
                }
                lbName.Text = _patCard.NAME;

                if (_patCard.SEX == "男")
                {
                    pictureBoxSex.Image = Resources.男;
                }
                else if (_patCard.SEX == "女")
                {
                    pictureBoxSex.Image = Resources.女;
                }
                string strlbAge = string.Empty;
                if (!string.IsNullOrEmpty(_patCard.DATE_OF_BIRTH.ToString()) && !string.IsNullOrEmpty(_patCard.SCHEDULED_DATE_TIME.ToString()))
                {
                    strlbAge = DateDiff.CalAge(_patCard.DATE_OF_BIRTH.Value, _patCard.SCHEDULED_DATE_TIME.Value);
                }
                lbAgeInpNo.Text = strlbAge;


                if (_patCard.OPER_STATUS_CODE < 5)//术前
                {
                    this.BackgroundImage = Resources.card_术前;
                }
                else if (_patCard.OPER_STATUS_CODE >= 5 && _patCard.OPER_STATUS_CODE < 35)//术中
                {
                    this.BackgroundImage = Resources.card_术中;
                }
                else if (_patCard.OPER_STATUS_CODE >= 35)//术后
                {
                    this.BackgroundImage = Resources.card_术后;
                }
                if (_patCard.START_DATE_TIME.HasValue)
                {
                    if (((TimeSpan)(accountRepository.GetServerTime().Data - _patCard.START_DATE_TIME)).TotalDays > 1)
                    {
                        lbOperationStartDate.Text = _patCard.START_DATE_TIME.Value.ToString("HH:mm");
                        lblAddDay.Visible = true;
                    }
                    else
                    {
                        lbOperationStartDate.Text = _patCard.START_DATE_TIME.Value.ToString("HH:mm");
                        lblAddDay.Visible = false;
                    }
                }
                else
                {
                    if (_patCard.SCHEDULED_DATE_TIME.HasValue)
                    {
                        if (((TimeSpan)(accountRepository.GetServerTime().Data - _patCard.SCHEDULED_DATE_TIME)).TotalDays > 1)
                        {
                            lbOperationStartDate.Text = _patCard.SCHEDULED_DATE_TIME.Value.ToString("HH:mm");
                            lblAddDay.Visible = true;
                        }
                        else
                        {
                            lbOperationStartDate.Text = _patCard.SCHEDULED_DATE_TIME.Value.ToString("HH:mm");
                            lblAddDay.Visible = false;
                        }
                    }
                    else
                    {
                        lbOperationStartDate.Text = string.Empty;
                        lblAddDay.Visible = false;
                    }
                }
                string DEPT_CODE = string.Empty;
                if (!string.IsNullOrEmpty(_patCard.DEPT_CODE))
                {
                    MED_DEPT_DICT deptDict = comnDictRepository.GetDeptDict(_patCard.DEPT_CODE).Data;
                    DEPT_CODE = deptDict == null ? _patCard.DEPT_CODE : deptDict.DEPT_NAME;
                }

                labelInfo.Text = _patCard.INP_NO; labelDeptName.Text = DEPT_CODE; labelBedNo.Text = _patCard.BED_NO + " 床";

                lbOperationName.Text = _patCard.OPERATION_NAME;

                string strlbSurgeon = string.Empty;
                if (!string.IsNullOrEmpty(_patCard.SURGEON))
                {
                    MED_HIS_USERS hisUsers = comnDictRepository.GetHisUsersList(_patCard.SURGEON).Data;
                    strlbSurgeon = hisUsers == null ? _patCard.SURGEON : hisUsers.USER_NAME;
                }

                string strlbAnesDoctor = string.Empty;
                if (!string.IsNullOrEmpty(_patCard.ANES_DOCTOR))
                {
                    MED_HIS_USERS hisUsers = comnDictRepository.GetHisUsersList(_patCard.ANES_DOCTOR).Data;
                    strlbAnesDoctor = hisUsers == null ? _patCard.ANES_DOCTOR : hisUsers.USER_NAME;
                }

                string strlbAnesAss = string.Empty;
                if (!string.IsNullOrEmpty(_patCard.FIRST_ANES_ASSISTANT))
                {
                    MED_HIS_USERS hisUsers = comnDictRepository.GetHisUsersList(_patCard.FIRST_ANES_ASSISTANT).Data;
                    strlbAnesAss = hisUsers == null ? _patCard.FIRST_ANES_ASSISTANT : hisUsers.USER_NAME;
                }

                lbSurgeon.Text = string.Format("术者：{0}  麻醉：{1} {2}", strlbSurgeon, strlbAnesDoctor, strlbAnesAss);

                this.lbAnesMethod.Text = _patCard.ANES_METHOD;
                this.lblOperScal.Text = !string.IsNullOrEmpty(_patCard.OPER_SCALE) ? _patCard.OPER_SCALE + " 级" : "";
                this.lblOperPost.Text = _patCard.OPER_POSITION;


                switch (_patCard.ASA_GRADE)
                {
                    case "Ⅰ":
                    case "1":
                    case "一":
                        pictureBoxOPER_SCALE.Image = Resources.一级;
                        break;
                    case "Ⅱ":
                    case "2":
                    case "二":
                        pictureBoxOPER_SCALE.Image = Resources.二级;
                        break;
                    case "Ⅲ":
                    case "3":
                    case "三":
                        pictureBoxOPER_SCALE.Image = Resources.三级;
                        break;
                    case "Ⅳ":
                    case "4":
                    case "四":
                        pictureBoxOPER_SCALE.Image = Resources.四级;
                        break;
                }
                if (_patCard.EMERGENCY_IND == 1)
                    pictureBoxJZ.Visible = true;
                if (_patCard.RADIATE_IND == 2)
                    pictureBoxFS.Visible = true;
                if (_patCard.ISOLATION_IND == 2)
                    pictureBoxGL.Visible = true;
            }
            else
            {
                CardVisible(false);
                this.BackgroundImage = Resources.card_blank;
            }

            //INFECTED_IND
        }

        private void ClearCard()
        {
            lbRoomSequence.Text = "";
            lbName.Text = "";
            lbAgeInpNo.Text = "";
            lbOperationStartDate.Text = "";
            lbOperationName.Text = "";
            lbSurgeon.Text = "术者：  麻醉：";
            this.lbAnesMethod.Text = "";
            this.lblOperScal.Text = "";
            this.lblOperPost.Text = "";
        }

        private void CardVisible(bool isVisible)
        {
            labelInfo.Visible = isVisible;
            labelDeptName.Visible = isVisible;
            labelBedNo.Visible = isVisible;
            pictureBoxSex.Visible = isVisible;
            pictureBoxOPER_SCALE.Visible = isVisible;
            lbRoomSequence.Visible = isVisible;
            lblAddDay.Visible = isVisible;
            lbName.Visible = isVisible;
            lbAgeInpNo.Visible = isVisible;
            lbOperationStartDate.Visible = isVisible;
            lbOperationName.Visible = isVisible;
            lbSurgeon.Visible = isVisible;
            this.lbAnesMethod.Visible = isVisible;
            this.lblOperScal.Visible = isVisible;
            this.lblOperPost.Visible = isVisible;
        }

        private int _selectNum = 0;
        public int SelectNum
        {
            get
            {
                return _selectNum;
            }
            set
            {
                _selectNum = value;
            }
        }

        private bool _selected = false;
        public bool Selected
        {
            set
            {
                _selected = value;
                if (value)//选中
                {
                    SetSelect(true);
                }
                else
                {
                    SetSelect(false);
                }
            }
            get
            {
                return _selected;
            }
        }

        private void SetSelect(bool flag)
        {
            panelTop.Visible = flag;
            panelBotton.Visible = flag;
            panelRight.Visible = flag;
            panelLeft.Visible = flag;

        }


        public event EventHandler DoubleClicked;
        public event EventHandler Clicked;
        public event EventHandler MouseEntered;

        private void PatientCard_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
            {
                Clicked(this, EventArgs.Empty);
                Selected = true;
            }
            else
                Selected = false;
            this.Focus();
        }

        private void PatientCard_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClicked != null && _patCard != null)
                DoubleClicked(this, EventArgs.Empty);
        }

        private void PatientCard_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEntered != null && _patCard != null)
                MouseEntered(this, EventArgs.Empty);
        }


        private void PatientCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (_patCard != null)
            {
                PatientCard_Click(null, null);
                MED_PATIENT_CARD patientCard = _patCard;

                if (e.Clicks == 2)
                {
                    DoubleClicked(this, EventArgs.Empty);
                }
                else
                {
                    if (patientCard == null) return;
                    this.DoDragDrop(this, DragDropEffects.Copy);
                }
            }
        }
    }
}
