using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(false)]
    public partial class SetNewDocumentTemplet : UserControl
    {
        CommonRepository commonRepository = new CommonRepository();


        public MED_DOCUMENT_TEMPLET DialogResultData;

        DataTable _operationDictDataTable;
        public SetNewDocumentTemplet()
        {
            InitializeComponent();
            btnOK.Enabled = false;
            checkEdit1.Checked = true;
            btnOK.Visible = true;
            btnCancel.Visible = true;
        }

        private void textEdit1_DoubleClick(object sender, EventArgs e)
        {
            _operationDictDataTable = ModelHelper<MED_OPERATION_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.OperationNameDict);
            Dialog.SelectFromDataTable(_operationDictDataTable, "OPER_NAME", sender as Control, false);
        }

        private void SetNewDocumentTemplet_Load(object sender, EventArgs e)
        {
            _operationDictDataTable = ModelHelper<MED_OPERATION_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.OperationNameDict);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
                DialogResultData = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                MessageBoxFormPC.Show("模板名不能为空！", "提示信息");
                return;
            }
            List<MED_DOCUMENT_TEMPLET> documentTempletDataTable = commonRepository.GetDocumentTemplet().Data.Where(x => x.TEMPLET_NAME == textEdit2.Text.Trim()).ToList();

            if (documentTempletDataTable.Count > 0)
            {
                MessageBoxFormPC.Show("模板名已存在！", "提示信息");
                return;
            }
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.OK;
                MED_DOCUMENT_TEMPLET row = new MED_DOCUMENT_TEMPLET();
                row.TEMPLET_GUID = Guid.NewGuid().ToString();
                row.CLASS_NAME = string.IsNullOrEmpty(textEdit1.Text.Trim()) ? "通用" : textEdit1.Text.Trim();
                row.TEMPLET_NAME = textEdit2.Text.Trim();
                row.USER_ID = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                row.EVENT_NO = ExtendApplicationContext.Current.EventNo;
                row.ISPRIVATE = checkEdit1.Checked ? 1 : 0;
                DialogResultData = row;
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
