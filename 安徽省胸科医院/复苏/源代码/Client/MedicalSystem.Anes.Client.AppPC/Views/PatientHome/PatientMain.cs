using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatientMain : BaseControl
    {
        CommonRepository commonRepository = new CommonRepository();

        string patientID = string.Empty;
        decimal visitID = 0;
        decimal operID = 0;

        public PatientMain(string _patientID, decimal _visitID, decimal _operID)
        {
            InitializeComponent();
            patientID = _patientID;
            visitID = _visitID;
            operID = _operID;
        }
        private void PatientMain_Load(object sender, EventArgs e)
        {
            initList();
            this.treeViewExtendList.SelectedNode = null;
            PatientTree patientTree = new PatientTree(patientID, visitID, operID);
            AddControl(patientTree);
        }


        private void initList()
        {
            TreeNode newNode = null;
            DateTime dtime = DateTime.MinValue;
            List<MED_EMR_ARCHIVE_DETIAL> list = commonRepository.GetEmrArchiveListByStatus(patientID, (int)visitID, operID.ToString()).Data;
            if (list != null && list.Count > 0)
            {
                foreach (MED_EMR_ARCHIVE_DETIAL item in list)
                {
                    if (dtime != item.ARCHIVE_DATE_TIME.Value.Date)
                    {
                        newNode = new TreeNode() { Text = item.ARCHIVE_DATE_TIME.Value.ToString("yyyy-MM-dd") + "麻醉首页", Tag = "首页" };

                        TreeNode tempNode = new TreeNode() { Text = item.MR_SUB_CLASS, Tag = item.EMR_FILE_NAME };
                        newNode.Nodes.Add(tempNode);
                        treeViewExtendList.Nodes.Add(newNode);
                        dtime = item.ARCHIVE_DATE_TIME.Value.Date;

                    }
                    else
                    {
                        TreeNode tempNode = new TreeNode() { Text = item.MR_SUB_CLASS, Tag = item.EMR_FILE_NAME };
                        newNode.Nodes.Add(tempNode);
                    }
                }
            }
            else
            {

            }


            treeViewExtendList.Nodes.Add(new TreeNode() { Text = "电子病历", Tag = "电子病历" });
            treeViewExtendList.Nodes.Add(new TreeNode() { Text = "检验查询", Tag = "检验查询" });
        }

        bool isfirst = true;
        private void treeViewExtendList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!isfirst)
            {
                if (e.Node.Tag != null)
                {
                    string tags = e.Node.Tag.ToString();
                    if (tags.Contains("首页"))
                    {
                        PatientTree patientTree = new PatientTree(patientID, visitID, operID);
                        AddControl(patientTree);
                    }
                    else if (tags.ToLower().Contains(".pdf"))
                    {
                        ReportView assayReport = new ReportView(ApplicationConfiguration.PDFServerUrl, tags, ApplicationConfiguration.PDFLocalUrl + tags);
                        AddControl(assayReport);
                    }
                    else if (tags.Contains("电子病历"))
                    {
                        AddControl(null);
                    }
                    else if (tags.Contains("检验查询"))
                    {
                        AssayReport assayReport = new AssayReport(patientID, visitID);
                        AddControl(assayReport);
                    }
                }
            }
            else
            {
                isfirst = false;
            }
        }

        private void AddControl(BaseView view)
        {
            panelBody.Controls.Clear();
            if (view != null)
            {
                panelBody.Controls.Add(view);
                view.Dock = DockStyle.Fill;
                view.BringToFront();
            }
        }

        private void PatientMain_Resize(object sender, EventArgs e)
        {
            treeViewExtendList.Width = panelList.Width - 15;
        }
    }
}
