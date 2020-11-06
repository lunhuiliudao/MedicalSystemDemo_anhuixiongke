using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public struct EventTempletDetail
    {
        public string TempletClass;
        public string Name;
        public string AnesMethod;
        public string Owner;
        public bool IsApplyDosage;

        public DateTime StartTime;
    }

    [ToolboxItem(false)]
    public partial class SetNewEventTemplet : BaseView
    {
        CommonRepository commonRepository = new CommonRepository();

        public object DialogResultData;
        DataTable _anesMethodTableDataTable;
        public SetNewEventTemplet()
        {
            InitializeComponent();
            btnOK.Enabled = false;
            checkEdit1.Checked = true;
            btnOK.Visible = true;
            btnCancel.Visible = true;
        }

        private void SetNewEventTemplet_Load(object sender, EventArgs e)
        {
            _anesMethodTableDataTable = ModelHelper<MED_ANESTHESIA_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.AnesMethodDict);

        }

        private void textEdit1_DoubleClick(object sender, EventArgs e)
        {
            Dialog.SelectFromDataTable(_anesMethodTableDataTable, "ANAESTHESIA_NAME", sender as Control, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
            DialogResultData = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                MessageBoxFormPC.Show("模板名不能为空！", "提示信息");
                return;
            }
            List<MED_ANESTHESIA_EVENT_TEMPLET> anesthesiaEventTempletDataTable = commonRepository.GetAnesEventTemplet(textEdit2.Text.Trim()).Data;
            if (anesthesiaEventTempletDataTable != null && anesthesiaEventTempletDataTable.Count > 0)
            {
                MessageBoxFormPC.Show("模板名已存在！", "提示信息");
                return;
            }
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.OK;
                EventTempletDetail templet = new EventTempletDetail();
                templet.AnesMethod = string.IsNullOrEmpty(textEdit1.Text.Trim()) ? "通用" : textEdit1.Text.Trim();
                templet.Name = textEdit2.Text;
                templet.Owner = checkEdit1.Checked ? ExtendApplicationContext.Current.LoginUser.USER_JOB_ID : "公用";
                DialogResultData = templet;
            }
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }
    }
}
