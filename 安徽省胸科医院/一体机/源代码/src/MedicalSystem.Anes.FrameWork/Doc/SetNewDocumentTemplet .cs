using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Model;

namespace MedicalSystem.Anes.Document.Documents
{
    [ToolboxItem(false)]
    public partial class SetNewDocumentTemplet : UserControl
    {
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
            _operationDictDataTable = new ModelHandler<MED_OPERATION_DICT>().FillDataTable(ApplicationModel.Instance.AllDictList.OperationDictList);//new ModelHandler<MED_OPERATION_DICT>().FillDataTable(ExtendAppContext.Current.CommDict.OperationNameDict);
            Dialog.SelectFromDataTable(_operationDictDataTable, "OPER_NAME", sender as Control, false);
        }

        private void SetNewDocumentTemplet_Load(object sender, EventArgs e)
        {
            //_operationDictDataTable = new ModelHandler<MED_OPERATION_DICT>().FillDataTable(ExtendAppContext.Current.CommDict.OperationNameDict);
            _operationDictDataTable = new ModelHandler<MED_OPERATION_DICT>().FillDataTable(ApplicationModel.Instance.AllDictList.OperationDictList);
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
            List<MED_DOCUMENT_TEMPLET> documentTempletDataTable = CommonService.ClientInstance.GetDocumentTemplet().Where(x => x.TEMPLET_NAME == textEdit2.Text.Trim()).ToList();

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
                row.USER_ID = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                row.EVENT_NO = ExtendAppContext.Current.EventNo;
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
