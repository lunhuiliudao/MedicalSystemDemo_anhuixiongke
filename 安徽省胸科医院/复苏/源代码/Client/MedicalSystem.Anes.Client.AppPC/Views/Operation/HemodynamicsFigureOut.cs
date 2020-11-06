using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using DevExpress.XtraEditors;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class HemodynamicsFigureOut : BaseView
    {
        public HemodynamicsFigureOut()
        {
            InitializeComponent();
            radioGroupType.SelectedIndex = 0;
            Caption = "血流动力学";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void devtxtHeight_Leave(object sender, EventArgs e)
        {
            if (sender is TextEdit)
            {
                TextEdit TempTextEdit = sender as TextEdit;
                decimal Result;
                if (!string.IsNullOrEmpty(TempTextEdit.Text.Trim()))
                {
                    if (!decimal.TryParse(TempTextEdit.Text, out Result))
                    {
                        //errorProvider1.SetError(TempTextEdit, "请输入数值型文本.");
                    }
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            decimal Height, Weight, HR, CO, CVPm, PAWP, ABPs, PAPs, ABPd, PAPd, ABPm, PAPm;
            decimal BSA = 0;
            #region 校验是否为数值及是否为0

            this.dxErrorProvider1.ClearErrors();
            bool isValid = true;
            if (devtxtHeight.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtHeight, "身高应大于零!");
                isValid = false;
            }
            Height = devtxtHeight.Value;

            if (devtxtWeight.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtWeight, "体重应大于零!");
                isValid = false;
            }
            Weight = devtxtWeight.Value;

            if (devtxtHR.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtHR, "HR应大于零!");
                isValid = false;
            }
            HR = devtxtHR.Value;


            if (devtxtCO.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtCO, "C.O.应大于零!");
                isValid = false;
            }
            CO = devtxtCO.Value;

            if (devtxtCVPm.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtCVPm, "CVPm应大于零!");
                isValid = false;
            }
            CVPm = devtxtCVPm.Value;

            if (devtxtPAWP.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtPAWP, "PAWP应大于零!");
                isValid = false;
            }
            PAWP = devtxtPAWP.Value;

            if (devtxtABPs.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtABPs, "ABPs应大于零!");
                isValid = false;
            }
            ABPs = devtxtABPs.Value;

            if (devtxtPAPs.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtPAPs, "PAPs应大于零!");
                isValid = false;
            }
            PAPs = devtxtPAPs.Value;

            if (devtxtABPd.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtABPd, "ABPd应大于零!");
                isValid = false;
            }
            ABPd = devtxtABPd.Value;

            if (devtxtPAPd.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtPAPd, "PAPd应大于零!");
                isValid = false;
            }
            PAPd = devtxtPAPd.Value;

            if (devtxtABPm.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtABPm, "ABPm应大于零!");
                isValid = false;
            }
            ABPm = devtxtABPm.Value;

            if (devtxtPAPm.Value <= decimal.Zero)
            {
                this.dxErrorProvider1.SetError(devtxtPAPm, "PAPm应大于零!");
                isValid = false;
            }
            PAPm = devtxtPAPm.Value;

            if (isValid == false)
                return;

            #endregion
            switch (radioGroupType.Text)
            {
                case "男":
                    BSA = 0.00607m * Height + 0.0127m * Weight - 0.0689m;
                    break;
                case "女":
                    BSA = 0.0586m * Height + 0.0126m * Weight - 0.0461m;
                    break;
                case "儿童":
                    BSA = 0.0061m * Height + 0.0128m * Weight - 0.1529m;
                    break;
            }
            devtxtBSA.Text = BSA.ToString("0.00");
            devtxtSV.Text = (CO / HR * 1000m).ToString("0.0");
            devtxtCI.Text = (CO / BSA).ToString("0.00");
            devtxtSI.Text = (CO / BSA / HR * 1000m).ToString("0.0");
            devtxtSVR.Text = ((ABPm - CVPm) / CO * 80).ToString("0");
            devtxtSVRI.Text = ((ABPm - CVPm) / CO * BSA * 80).ToString("0");
            devtxtPVR.Text = ((PAPm - PAWP) / CO * 80).ToString("0");
            devtxtPVRI.Text = ((PAPm - PAWP) / CO * BSA * 80).ToString("0");
            devtxtLVSW.Text = ((ABPm - PAWP) * CO / HR * 13.6m).ToString("0.0");
            devtxtLVSWI.Text = ((ABPm - PAWP) * CO / HR / BSA * 13.6m).ToString("0.0");
            devtxtLCW.Text = ((ABPm - PAWP) * CO * 13.6m / 1000).ToString("0.00");
            devtxtLCWI.Text = ((ABPm - PAWP) * CO / BSA * 13.6m / 1000).ToString("0.00");
            devtxtRVSW.Text = ((PAPm - CVPm) * CO / HR * 13.6m).ToString("0.0");
            devtxtRVSWI.Text = ((PAPm - CVPm) * CO * 13.6m / HR / BSA).ToString("0.0");
            devtxtRCW.Text = ((PAPm - CVPm) * CO * 13.6m / 1000).ToString("0.00");
            devtxtRCWI.Text = ((PAPm - CVPm) * CO * 13.6m / BSA / 1000).ToString("0.00");
        }

        private void devtxtHeight_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null && Convert.ToDecimal(e.NewValue) > decimal.Zero)
            {
                this.dxErrorProvider1.SetError(sender as Control, string.Empty);
            }
            else
            {
                this.dxErrorProvider1.SetError(sender as Control, "值必须大于零!");
            }
        }

        private void HemodynamicsFigureOut_Load(object sender, EventArgs e)
        {
            devtxtHeight.Focus();
        }
    }
}
