using DevExpress.XtraEditors;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    public class DataTemplate
    {
        CommonRepository commonRepository = new CommonRepository();

        private BaseDoc _baseDoc;
        private List<MedGridView> _gridViews = new List<MedGridView>();
        private MedGridView _currentGridView;
        private List<MRichTextBox> _mRichTextBoxs = new List<MRichTextBox>();
        private MRichTextBox _currentMRichTextBox;
        public DataTemplate(BaseDoc baseDoc)
        {
            _baseDoc = baseDoc;
            _mRichTextBoxs = _baseDoc.ReportViewer.GetControls<MRichTextBox>();
            if (_mRichTextBoxs != null && _mRichTextBoxs.Count > 0)
            {
                foreach (MRichTextBox richBox in _mRichTextBoxs)
                {
                    richBox.Enter += new EventHandler(richBox_Enter);
                }
            }
            _gridViews = _baseDoc.ReportViewer.GetControls<MedGridView>();
            if (_gridViews != null && _gridViews.Count > 0)
            {
                foreach (MedGridView grid in _gridViews)
                {
                    grid.Enter += new EventHandler(grid_Enter);
                }
            }
        }

        void richBox_Enter(object sender, EventArgs e)
        {
            _currentGridView = null;
            _currentMRichTextBox = sender as MRichTextBox;
        }

        private void grid_Enter(object sender, EventArgs e)
        {
            _currentMRichTextBox = null;
            _currentGridView = sender as MedGridView;
        }

        /// <summary>
        /// 保存整体模板
        /// </summary>
        /// <returns></returns>
        public bool SaveModel()
        {
            bool isSaved = false;

            return isSaved;
        }

        /// <summary>
        /// 保存整个文书的模板
        /// </summary>
        /// <returns></returns>
        public bool SaveAllDataModel(DataTable TotalModelDT)
        {
            TotalModelDT.TableName = "TOTALMODEL";
            bool isSaved = false;
            SetNewDocumentTemplet newDocumentTemplet = new SetNewDocumentTemplet();
            XtraForm xtraForm = GetDialogForm("保存整体模板", newDocumentTemplet);
            xtraForm.Size = new Size(634, 160);
            if (xtraForm.ShowDialog() == DialogResult.OK && newDocumentTemplet.DialogResultData != null)
            {
                MED_DOCUMENT_TEMPLET row = newDocumentTemplet.DialogResultData;
                row.DOCUMENT_NAME = Path.GetFileNameWithoutExtension(_baseDoc.ReportName);
                row.ISJUBU = 0;
                MemoryStream stream = new MemoryStream();
                TotalModelDT.WriteXml(stream);
                stream.Position = 0;
                row.TEMPLET_VALUE = FileHelper.StreamToBytes(stream);
                stream.Close();
                stream.Dispose();
                isSaved = SaveModel(row);
            }
            else
            {
                MessageBoxFormPC.Show("除患者基本信息外其他信息为空—请填写后再保存模板", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isSaved;
        }

        private bool SaveModel(MED_DOCUMENT_TEMPLET row)
        {
            if (commonRepository.SaveDocumentTemplet(row).Data > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void SetQingdianViewData(string templetGuid, bool isAdd)
        {
            if (string.IsNullOrEmpty(templetGuid)) return;
            List<MED_QIXIE_TEMPLET_DETAIL> qiXieTempletDetail = commonRepository.GetQiXieTempletDetail(templetGuid).Data;
            if (qiXieTempletDetail != null && qiXieTempletDetail.Count > 0)
            {
                int gridRowCount = _currentGridView.LinesPerPage;
                if (!isAdd)
                {
                    _currentGridView.Rows.Clear();
                    for (int i = 0; i < gridRowCount; i++)
                    {
                        _currentGridView.Rows.Add();
                        _currentGridView.Rows[i].Tag = i;
                    }
                }
                foreach (MED_QIXIE_TEMPLET_DETAIL prow in qiXieTempletDetail)
                {
                    bool isOK = false;
                    for (int i = 0; i < _currentGridView.MedGridViewColumns.Count; i++)
                    {
                        if (_currentGridView.MedGridViewColumns[i].HeaderText == _currentGridView.MedGridViewColumns[0].HeaderText)
                        {
                            for (int j = 0; j < _currentGridView.RowCount; j++)
                            {
                                if (_currentGridView[i, j].Value == null || (_currentGridView[i, j].Value != null && string.IsNullOrEmpty(_currentGridView[i, j].Value.ToString().Trim())))
                                {
                                    _currentGridView[i, j].Value = prow.ITEM_NAME;
                                    _currentGridView[i, j].Tag = prow.ITEM_NAME;
                                    if (!string.IsNullOrEmpty(prow.ITEM_NAME) && (i + 1) < _currentGridView.MedGridViewColumns.Count)
                                    {
                                        _currentGridView[i + 1, j].Value = prow.ITEM_VALUE;
                                        _currentGridView[i + 1, j].Tag = _currentGridView[i + 1, j].Value;
                                    }
                                    isOK = true;
                                    break;
                                }
                                else if (_currentGridView[i, j].Value != null && _currentGridView[i, j].Value.ToString().Trim().Equals(prow.ITEM_NAME))
                                {
                                    if (!string.IsNullOrEmpty(prow.ITEM_VALUE) && !string.IsNullOrEmpty(prow.ITEM_VALUE.Trim()) && (i + 1) < _currentGridView.MedGridViewColumns.Count)
                                    {
                                        _currentGridView[i + 1, j].Value = _currentGridView[i + 1, j].Value == null ? prow.ITEM_VALUE : _currentGridView[i + 1, j].Value.ToString().Trim() + "+" + prow.ITEM_VALUE;
                                        _currentGridView[i + 1, j].Tag = _currentGridView[i + 1, j].Value;
                                    }
                                    isOK = true;
                                    break;
                                }
                            }
                            if (isOK)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private XtraForm GetDialogForm(string text, UserControl view)
        {
            XtraForm xtraForm = new XtraForm();
            xtraForm.Text = text;
            xtraForm.Controls.Add(view);
            view.Dock = DockStyle.Fill;
            xtraForm.Size = new Size(800, 600);
            xtraForm.StartPosition = FormStartPosition.CenterScreen;
            xtraForm.MaximizeBox = false;
            return xtraForm;
        }

        /// <summary>
        /// 应用模板
        /// </summary>
        /// <returns></returns>
        public bool ApplyModel()
        {
            bool isApplyed = false;
            if (_currentGridView == null && _currentMRichTextBox == null)
            {
                Dialog.MessageBox("请选择被套用控件");
                return false;
            }
            if (_currentGridView != null)
            {
                if (_currentGridView.TempletFlag == DocTempletType.QiXieQingDian)
                {
                    QiXieQingDianTemplet qiXieQingDianTemplet = new QiXieQingDianTemplet();
                    qiXieQingDianTemplet.IsApply = true;
                    XtraForm xtraForm = GetDialogForm("套用模板", qiXieQingDianTemplet);
                    if (xtraForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(qiXieQingDianTemplet.DialogResultData))
                    {
                        SetQingdianViewData(qiXieQingDianTemplet.DialogResultData, qiXieQingDianTemplet.IsAddTempletData);
                        isApplyed = true;
                    }
                }
            }
            else if (_currentMRichTextBox != null)
            {
                if (_currentMRichTextBox.TempletFlag != DocTempletType.None)
                {
                    DocumentTemplet documentTemplet = null;
                    if (_currentMRichTextBox.TempletFlag == DocTempletType.Other && !string.IsNullOrEmpty(_currentMRichTextBox.OtherTempletFlagString))
                    {
                        documentTemplet = new DocumentTemplet(_currentMRichTextBox.OtherTempletFlagString.Trim(), ExtendAppContext.Current.EventNo);
                    }
                    else
                    {
                        documentTemplet = new DocumentTemplet(_currentMRichTextBox.TempletFlag, ExtendAppContext.Current.EventNo);
                    }
                    XtraForm xtraForm = GetDialogForm("套用模板", documentTemplet);
                    if (xtraForm.ShowDialog() == DialogResult.OK)
                    {
                        _currentMRichTextBox.Text = documentTemplet.DialogResultData;
                        isApplyed = true;
                    }
                }
            }
            return isApplyed;
        }
        /// <summary>
        /// 应用整体模板
        /// </summary>
        /// <returns></returns>
        public DataTable ApplyAllDataModel()
        {
            if (_currentGridView == null)
            {
                DocumentTemplet documentTemplet = new DocumentTemplet(DocTempletType.ALL, Path.GetFileNameWithoutExtension(_baseDoc.ReportName), ExtendAppContext.Current.EventNo);
                XtraForm xtraForm = GetDialogForm("套用模板", documentTemplet);
                if (xtraForm.ShowDialog() == DialogResult.OK)
                {
                    DataTable TotalModelDT = documentTemplet.DialogResultDataTable;
                    return TotalModelDT;
                }
            }
            else
            {
                if (_currentGridView != null)
                {
                    if (_currentGridView.TempletFlag == DocTempletType.QiXieQingDian)
                    {
                        QiXieQingDianTemplet qiXieQingDianTemplet = new QiXieQingDianTemplet();
                        qiXieQingDianTemplet.IsApply = true;
                        XtraForm xtraForm = GetDialogForm("套用模板", qiXieQingDianTemplet);
                        if (xtraForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(qiXieQingDianTemplet.DialogResultData))
                        {
                            SetQingdianViewData(qiXieQingDianTemplet.DialogResultData, qiXieQingDianTemplet.IsAddTempletData);
                            return null;
                        }
                    }
                }
                else if (_currentMRichTextBox != null)
                {
                    if (_currentMRichTextBox.TempletFlag != DocTempletType.None)
                    {
                        DocumentTemplet documentTemplet = null;
                        if (_currentMRichTextBox.TempletFlag == DocTempletType.Other && !string.IsNullOrEmpty(_currentMRichTextBox.OtherTempletFlagString))
                        {
                            documentTemplet = new DocumentTemplet(_currentMRichTextBox.OtherTempletFlagString.Trim(), ExtendAppContext.Current.EventNo);
                        }
                        else
                        {
                            documentTemplet = new DocumentTemplet(_currentMRichTextBox.TempletFlag, ExtendAppContext.Current.EventNo);
                        }
                        XtraForm xtraForm = GetDialogForm("套用模板", documentTemplet);
                        if (xtraForm.ShowDialog() == DialogResult.OK)
                        {
                            _currentMRichTextBox.Text = documentTemplet.DialogResultData;
                            return null;
                        }
                    }
                }
            }
            return null;
        }
    }
}
