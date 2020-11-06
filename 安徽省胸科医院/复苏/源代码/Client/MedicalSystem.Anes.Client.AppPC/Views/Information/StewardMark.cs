using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class StewardMark : UserControl
    {
        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        string _patientID = string.Empty;
        int _visitID = 0;
        int _operID = 0;
        public DialogResult result = DialogResult.Cancel;
        List<MED_STEWARD_MARK> stewardMarkList = null;
        int lblCount = 0;
        public StewardMark()
        {
            InitializeComponent();
        }
        public StewardMark(string patientID, int visitID, int operID)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            StewardMarkLoad();
        }
        private void StewardMarkLoad()
        {
            stewardMarkList = operationInfoRepository.GetStewardMarkList(_patientID, _visitID, _operID).Data;
            MED_STEWARD_MARK mark = new MED_STEWARD_MARK();
            mark.PATIENT_ID = _patientID;
            mark.VISIT_ID = _visitID;
            mark.OPER_ID = _operID;
            mark.MARK_COUNT = (stewardMarkList != null && stewardMarkList.Count > 0) ? stewardMarkList.Count + 1 : 1;
            stewardMarkList.Add(mark);
            lblCount = stewardMarkList.Count;
            for (int i = lblCount; i > 0; i--)
            {
                Label lbl = new Label();
                lbl.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
                lbl.Size = new System.Drawing.Size(127, 36);
                lbl.Visible = true;
                mark = stewardMarkList.Where(p => p.MARK_COUNT == i).FirstOrDefault();
                lbl.Text = "第" + i + "次： " + mark.TOTAL_MATK + " 分";
                lbl.Tag = i;
                if (lblCount == 1)
                {
                    lbl.Size = new System.Drawing.Size(210, 36);
                    lbl.Image = Resources.进程1_1;
                }
                else
                {
                    if (i == lblCount)
                    {
                        lbl.Size = new System.Drawing.Size(187, 36);
                        lbl.Image = Resources.进程2_3;
                    }
                    else if (i == 1)
                    {
                        lbl.Size = new System.Drawing.Size(210, 36);
                        if (lblCount == 2)
                        {
                            lbl.Image = Resources.进程1_5;
                        }
                        else
                        {
                            lbl.Image = Resources.进程1_4;
                        }
                        lbl.Image = Resources.进程1_4;
                    }
                    else if (i == lblCount - 1)
                    {
                        lbl.Size = new System.Drawing.Size(187, 36);
                        lbl.Image = Resources.进程2_5;
                    }
                    else
                    {

                        lbl.Size = new System.Drawing.Size(187, 36);
                        lbl.Image = Resources.进程2_4;
                    }
                }

                lbl.Click += lbl_Click;
                lbl.Dock = DockStyle.Left;
                panelTitle.Controls.Add(lbl);
            }
            MainInfoLoad(lblCount);
        }
        private void MainInfoLoad(int markCount)
        {
            MED_STEWARD_MARK mark = stewardMarkList.Where(p => p.MARK_COUNT == markCount).FirstOrDefault();
            Clear();
            foreach (RadioButton rbut in groupBoxConsciousness.Controls)
            {
                //清醒程度
                if (rbut.Name == "rbtns1_" + mark.CONSCIOUSNESS.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in groupBoxAirwary.Controls)
            {
                //肢体活动度
                if (rbut.Name == "rbtns3_" + mark.AIRWARY_PATENCY.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }


            foreach (RadioButton rbut in groupBoxPhysical.Controls)
            {
                //呼吸
                if (rbut.Name == "rbtns2_" + mark.PHYSICAL_ACTIVITY.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
        }
        public void Clear()
        {
            foreach (RadioButton rbut in groupBoxConsciousness.Controls)
            {
                rbut.Checked = false;
            }
            foreach (RadioButton rbut in groupBoxAirwary.Controls)
            {
                rbut.Checked = false;
            }
            foreach (RadioButton rbut in groupBoxPhysical.Controls)
            {
                rbut.Checked = false;
            }
        }
        private int getS1()
        {
            int score = 0;
            foreach (RadioButton rbtn in groupBoxConsciousness.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "对刺激无反应":
                            score = 0;
                            break;
                        case "对刺激有反应":
                            score = 1;
                            break;
                        case "完全苏醒":
                            score = 2;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }
        private int getS2()
        {
            int score = 0;
            foreach (RadioButton rbtn in groupBoxAirwary.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "呼吸道需要予以支持":
                            score = 0;
                            break;
                        case "不用支持可以维持呼吸道通畅":
                            score = 1;
                            break;
                        case "可按医师吩咐咳嗽":
                            score = 2;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }

        private int getS3()
        {
            int score = 0;
            foreach (RadioButton rbtn in groupBoxPhysical.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "肢体无活动":
                            score = 0;
                            break;
                        case "肢体无意识活动":
                            score = 1;
                            break;
                        case "肢体能作有意识的活动":
                            score = 2;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }

        private void lbl_Click(object sender, EventArgs e)
        {

            Label lblMark = sender as Label;
            int tag = Convert.ToInt32(lblMark.Tag);
            if (lblCount == 1)
                lblMark.Image = Resources.进程1_1;
            else
            {
                if (tag == lblCount)
                {
                    foreach (Label lbl in panelTitle.Controls)
                    {
                        if (lbl.Tag == lblMark.Tag)
                            lbl.Image = Resources.进程2_3;
                        else if (Convert.ToInt32(lbl.Tag) == 1)
                        {
                            if (lblCount == 2)
                                lbl.Image = Resources.进程1_5;
                            else
                                lbl.Image = Resources.进程1_4;
                        }
                        else if (Convert.ToInt32(lbl.Tag) == tag - 1)
                        {
                            lbl.Image = Resources.进程2_5;
                        }
                        else
                        {
                            lbl.Image = Resources.进程2_4;
                        }
                    }
                }
                else if (tag == 1)
                {
                    foreach (Label lbl in panelTitle.Controls)
                    {
                        if (lbl.Tag == lblMark.Tag)
                            lbl.Image = Resources.进程1_2;
                        else if (Convert.ToInt32(lbl.Tag) == lblCount)
                        {
                            lbl.Image = Resources.进程2_1;
                        }
                        else
                        {
                            lbl.Image = Resources.进程2_4;
                        }
                    }
                }
                else
                {
                    foreach (Label lbl in panelTitle.Controls)
                    {
                        if (lbl.Tag == lblMark.Tag)
                            lbl.Image = Resources.进程2_1;
                        else if (Convert.ToInt32(lbl.Tag) == lblCount)
                        {
                            lbl.Image = Resources.进程2_0;
                        }
                        else if (Convert.ToInt32(lbl.Tag) == 1)
                        {
                            if (tag == 2)
                                lbl.Image = Resources.进程1_5;
                            else
                                lbl.Image = Resources.进程1_4;
                        }
                        else if (Convert.ToInt32(lbl.Tag) == tag - 1)
                        {
                            lbl.Image = Resources.进程2_5;
                        }
                        else
                        {
                            lbl.Image = Resources.进程2_4;
                        }
                    }
                }
            }

            MainInfoLoad(Convert.ToInt32(lblMark.Tag));
        }

        private void btnNext_BtnClicked(object sender, EventArgs e)
        {
            stewardMarkList[stewardMarkList.Count - 1].CONSCIOUSNESS = getS1();
            stewardMarkList[stewardMarkList.Count - 1].AIRWARY_PATENCY = getS2();
            stewardMarkList[stewardMarkList.Count - 1].PHYSICAL_ACTIVITY = getS3();
            stewardMarkList[stewardMarkList.Count - 1].TOTAL_MATK = getS1() + getS2() + getS3();
            operationInfoRepository.SaveStewardMarkList(stewardMarkList);
            result = DialogResult.OK;
            ParentForm.DialogResult = DialogResult.OK;
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }
    }
}
