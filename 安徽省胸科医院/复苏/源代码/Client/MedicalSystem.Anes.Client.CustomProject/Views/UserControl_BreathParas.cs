using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class UserControl_BreathParas : UserControl
    {
        private string _code1, _code2, _code3;
        private DateTime _timePoint;
        private List<string> _list;
        public bool delBreathParas = false;

        public UserControl_BreathParas() : this(DateTime.Now, "", "", "") { }

        public UserControl_BreathParas(DateTime timePoint, string code1, string code2, string code3) : this(timePoint, code1, code2, code3, "", "", "") { }

        public UserControl_BreathParas(DateTime timePoint, string code1, string code2, string code3, string value1, string value2, string value3)
        {
            _timePoint = timePoint;
            _code1 = code1;
            _code2 = code2;
            _code3 = code3;
            InitializeComponent();
            dateEdit1.EditValue = _timePoint;
            if (!string.IsNullOrEmpty(value1))
            {
                txtCode1.Text = value1;
            }
            if (!string.IsNullOrEmpty(value2))
            {
                txtCode2.Text = value2;
            }
            if (!string.IsNullOrEmpty(value3))
            {
                txtCode3.Text = value3;
            }
        }

        public List<string> ResultList
        {
            get
            {
                return _list;
            }
        }

        private string GetCode(string code)
        {
            string result = code;

            if (ExtendApplicationContext.Current.CommDict.MonitorFuntionDict != null)
            {
                List<MED_MONITOR_FUNCTION_CODE> rows = ExtendApplicationContext.Current.CommDict.MonitorFuntionDict.Where(x => x.ITEM_CODE == code).ToList();
                if (rows != null && rows.Count > 0 && rows[0].ITEM_NAME != null)
                {
                    result = rows[0].ITEM_NAME;
                }
            }
            return result;
        }

        private void UserControl_BreathParas_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (!string.IsNullOrEmpty(_code1))
                {
                    lblCode1.Text = GetCode(_code1);
                }
                if (!string.IsNullOrEmpty(_code2))
                {
                    lblCode2.Text = GetCode(_code2);
                }
                if (!string.IsNullOrEmpty(_code3))
                {
                    lblCode3.Text = GetCode(_code3);
                }
                if (ParentForm != null)
                {
                    ParentForm.AcceptButton = btnOK;
                    ParentForm.CancelButton = btnCancel;
                }
                btnOK.Enabled = false;
            }
        }

        private void txtCode1_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = !string.IsNullOrEmpty(txtCode1.Text) || !string.IsNullOrEmpty(txtCode2.Text) || !string.IsNullOrEmpty(txtCode3.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _list = new List<string>(new string[] { txtCode1.Text, txtCode2.Text, txtCode3.Text });
        }

        private void BtnDele_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dateEdit1.Time.ToString()) && !string.IsNullOrEmpty(txtCode1.Text) && !string.IsNullOrEmpty(txtCode2.Text)
               && !string.IsNullOrEmpty(txtCode3.Text))
            {
                delBreathParas = true;
            }
        }
    }
}
