using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using System.Runtime.InteropServices;
using MedicalSystem.Anes.Client.FrameWork;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ReportView : BaseView
    {

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="SerIPAddr">服务器地址</param>
        /// <param name="RemoteFileName">文件名</param>
        /// <param name="protocol">0写数据库1不写数据库2参数RemoteFileName带路径上传不写数据库</param>
        /// <param name="LocalFileName">客户端存在的文件具体地址</param>
        /// <param name="append">是否覆盖1覆盖0不能覆盖</param>
        /// <returns></returns>
        [DllImport("EMRFSRV.dll")]
        public static extern int getfile(string SerIPAddr, string RemoteFileName, string LocalFileName, int protocol, int append);
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="SerIPAddr">服务器地址</param>
        /// <param name="LocalFileName">客户端文件存在的具体地址</param>
        /// <param name="RemoteFileName">文件名</param>
        /// <param name="protocol">0 1 参数LocalFileName使用格式名称 2参数LocalFileName带路径文件名称</param>
        /// <param name="append">是否覆盖1覆盖0不能覆盖</param>
        /// <returns></returns>
        [DllImport("EMRFSRV.dll")]
        public static extern int putfile(string SerIPAddr, string LocalFileName, string RemoteFileName, int protocol, int append);


        /// <summary>
        /// 查看文件
        /// </summary>
        /// <param name="SerIPAddr">服务器地址</param>
        /// <param name="RemoteFileName">文件名</param>
        /// <param name="LocalFileName">客户端存在的文件具体地址</param>

        public ReportView(string SerIPAddr, string RemoteFileName, string LocalFileName)
        {
            InitializeComponent();

            int result = getfile(SerIPAddr, RemoteFileName, LocalFileName, 1, 1);

            if (result == 0)
            {
                this.pdfDocumentViewer1.LoadFromFile(LocalFileName);
            }
        }

        private void ReportView_Load(object sender, EventArgs e)
        {

        }

        private void tsGotoPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int soucePage = this.pdfDocumentViewer1.CurrentPageNumber;
            int targetPage = this.tsGotoPage.SelectedIndex + 1;
            if (soucePage != targetPage)
            {
                this.pdfDocumentViewer1.GoToPage(targetPage);
            }
        }

        private void tsFirstPage_Click(object sender, EventArgs e)
        {
            if (this.pdfDocumentViewer1.PageCount > 0)
            {
                int currentPage = this.pdfDocumentViewer1.CurrentPageNumber;
                if (currentPage != 1)
                {
                    this.pdfDocumentViewer1.GoToFirstPage();
                }
                else
                {
                    MessageBoxFormPC.Show("已经是首页了。", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }

            }
        }

        private void tsPreview_Click(object sender, EventArgs e)
        {
            if (this.pdfDocumentViewer1.PageCount > 0)
            {

                int currentPage = this.pdfDocumentViewer1.CurrentPageNumber;

                if (currentPage > 1)
                {
                    this.pdfDocumentViewer1.GoToPreviousPage();
                }
                else
                {
                    MessageBoxFormPC.Show("已经是首页了。", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }

        private void tsNext_Click(object sender, EventArgs e)
        {
            if (this.pdfDocumentViewer1.PageCount > 0)
            {
                int currentPage = this.pdfDocumentViewer1.CurrentPageNumber;
                int totalPage = this.pdfDocumentViewer1.PageCount;
                if (currentPage < totalPage)
                {
                    this.pdfDocumentViewer1.GoToNextPage();

                }
                else
                {
                    MessageBoxFormPC.Show("已经是最后一页了。", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }

        private void tsEndPage_Click(object sender, EventArgs e)
        {
            if (this.pdfDocumentViewer1.PageCount > 0)
            {
                int currentPage = this.pdfDocumentViewer1.CurrentPageNumber;
                int totalPage = this.pdfDocumentViewer1.PageCount;
                if (currentPage != totalPage)
                {
                    this.pdfDocumentViewer1.GoToLastPage();
                }
                else
                {
                    MessageBoxFormPC.Show("已经是最后一页了。", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }

        private void pdfDocumentViewer1_PdfLoaded(object sender, EventArgs args)
        {
            this.tsGotoPage.Items.Clear();
            int totalPage = this.pdfDocumentViewer1.PageCount;

            for (int i = 1; i <= totalPage; i++)
            {
                this.tsGotoPage.Items.Add(i.ToString());
            }
            this.tsGotoPage.SelectedIndex = 0;
        }
    }
}
