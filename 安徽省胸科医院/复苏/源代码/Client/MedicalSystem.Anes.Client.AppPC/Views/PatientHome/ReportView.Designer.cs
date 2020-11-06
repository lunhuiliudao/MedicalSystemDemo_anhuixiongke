namespace MedicalSystem.Anes.Client.AppPC
{
    partial class ReportView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsFirstPage = new System.Windows.Forms.ToolStripButton();
            this.tsPreview = new System.Windows.Forms.ToolStripButton();
            this.tsNext = new System.Windows.Forms.ToolStripButton();
            this.tsEndPage = new System.Windows.Forms.ToolStripButton();
            this.tsGotoPage = new System.Windows.Forms.ToolStripComboBox();
            this.pdfDocumentViewer1 = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFirstPage,
            this.tsPreview,
            this.tsNext,
            this.tsEndPage,
            this.tsGotoPage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1126, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsFirstPage
            // 
            this.tsFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("tsFirstPage.Image")));
            this.tsFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFirstPage.Name = "tsFirstPage";
            this.tsFirstPage.Size = new System.Drawing.Size(36, 22);
            this.tsFirstPage.Text = "首页";
            this.tsFirstPage.Click += new System.EventHandler(this.tsFirstPage_Click);
            // 
            // tsPreview
            // 
            this.tsPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsPreview.Image")));
            this.tsPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPreview.Name = "tsPreview";
            this.tsPreview.Size = new System.Drawing.Size(48, 22);
            this.tsPreview.Text = "上一页";
            this.tsPreview.Click += new System.EventHandler(this.tsPreview_Click);
            // 
            // tsNext
            // 
            this.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsNext.Image = ((System.Drawing.Image)(resources.GetObject("tsNext.Image")));
            this.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNext.Name = "tsNext";
            this.tsNext.Size = new System.Drawing.Size(48, 22);
            this.tsNext.Text = "下一页";
            this.tsNext.Click += new System.EventHandler(this.tsNext_Click);
            // 
            // tsEndPage
            // 
            this.tsEndPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsEndPage.Image = ((System.Drawing.Image)(resources.GetObject("tsEndPage.Image")));
            this.tsEndPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEndPage.Name = "tsEndPage";
            this.tsEndPage.Size = new System.Drawing.Size(36, 22);
            this.tsEndPage.Text = "尾页";
            this.tsEndPage.Click += new System.EventHandler(this.tsEndPage_Click);
            // 
            // tsGotoPage
            // 
            this.tsGotoPage.Name = "tsGotoPage";
            this.tsGotoPage.Size = new System.Drawing.Size(121, 25);
            this.tsGotoPage.SelectedIndexChanged += new System.EventHandler(this.tsGotoPage_SelectedIndexChanged);
            // 
            // pdfDocumentViewer1
            // 
            this.pdfDocumentViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.pdfDocumentViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pdfDocumentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfDocumentViewer1.Location = new System.Drawing.Point(0, 25);
            this.pdfDocumentViewer1.MultiPagesThreshold = 60;
            this.pdfDocumentViewer1.Name = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.Size = new System.Drawing.Size(1126, 716);
            this.pdfDocumentViewer1.TabIndex = 2;
            this.pdfDocumentViewer1.Text = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.Threshold = 60;
            this.pdfDocumentViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            this.pdfDocumentViewer1.PdfLoaded += new Spire.PdfViewer.DocumentOpenedEventHandler(this.pdfDocumentViewer1_PdfLoaded);
            // 
            // ReportView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pdfDocumentViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(1126, 741);
            this.Load += new System.EventHandler(this.ReportView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsFirstPage;
        private System.Windows.Forms.ToolStripButton tsPreview;
        private System.Windows.Forms.ToolStripButton tsNext;
        private System.Windows.Forms.ToolStripButton tsEndPage;
        private System.Windows.Forms.ToolStripComboBox tsGotoPage;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfDocumentViewer1;
    }
}
