namespace MedicalSystem.Anes.Document.Documents
{
    partial class BaseDoc
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDoc));
            this.ToolBarLayoutPanel = new System.Windows.Forms.Panel();
            this.downMenuDoc = new MedicalSystem.Anes.Document.Controls.DownMenuDoc();
            this.PreviousPageButton = new System.Windows.Forms.PictureBox();
            this.NextPageButton = new System.Windows.Forms.PictureBox();
            this.btnMultiPrint = new System.Windows.Forms.PictureBox();
            this.PrintButton = new System.Windows.Forms.PictureBox();
            this.pictureBoxYuLan = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.PictureBox();
            this.SaveDataTemplate = new System.Windows.Forms.PictureBox();
            this.ApplyDataTemplate = new System.Windows.Forms.PictureBox();
            this.pictureBoxSuoFang = new System.Windows.Forms.PictureBox();
            this.DesignButton = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelDoc = new System.Windows.Forms.Panel();
            this.MedReportView = new MedicalSystem.Anes.Document.Controls.MedReportView();
            this.panelTabControl = new System.Windows.Forms.Panel();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.ToolBarLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousPageButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextPageButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMultiPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYuLan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveDataTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDataTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuoFang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesignButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelDoc.SuspendLayout();
            this.panelTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBarLayoutPanel
            // 
            this.ToolBarLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(200)))), ((int)(((byte)(217)))));
            this.ToolBarLayoutPanel.Controls.Add(this.PreviousPageButton);
            this.ToolBarLayoutPanel.Controls.Add(this.NextPageButton);
            this.ToolBarLayoutPanel.Controls.Add(this.btnMultiPrint);
            this.ToolBarLayoutPanel.Controls.Add(this.PrintButton);
            this.ToolBarLayoutPanel.Controls.Add(this.pictureBoxYuLan);
            this.ToolBarLayoutPanel.Controls.Add(this.button2);
            this.ToolBarLayoutPanel.Controls.Add(this.SaveButton);
            this.ToolBarLayoutPanel.Controls.Add(this.SaveDataTemplate);
            this.ToolBarLayoutPanel.Controls.Add(this.ApplyDataTemplate);
            this.ToolBarLayoutPanel.Controls.Add(this.pictureBoxSuoFang);
            this.ToolBarLayoutPanel.Controls.Add(this.DesignButton);
            this.ToolBarLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBarLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolBarLayoutPanel.Name = "ToolBarLayoutPanel";
            this.ToolBarLayoutPanel.Size = new System.Drawing.Size(927, 48);
            this.ToolBarLayoutPanel.TabIndex = 1;
            // 
            // downMenuDoc
            // 
            this.downMenuDoc.BackColor = System.Drawing.Color.Transparent;
            this.downMenuDoc.Dock = System.Windows.Forms.DockStyle.Right;
            this.downMenuDoc.Items = ((System.Collections.Generic.List<string>)(resources.GetObject("downMenuDoc.Items")));
            this.downMenuDoc.Location = new System.Drawing.Point(898, 0);
            this.downMenuDoc.Name = "downMenuDoc";
            this.downMenuDoc.SelectIndex = -1;
            this.downMenuDoc.Size = new System.Drawing.Size(29, 30);
            this.downMenuDoc.TabIndex = 11;
            this.downMenuDoc.Tags = 0;
            this.downMenuDoc.Visible = false;
            this.downMenuDoc.ItemClick += new MedicalSystem.Anes.Document.Controls.DownMenuDoc.ItemClickEvent(this.downMenuDoc_ItemClick);
            // 
            // PreviousPageButton
            // 
            this.PreviousPageButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PreviousPageButton.Image = global::MedicalSystem.Anes.Document.Properties.Resources.上页1;
            this.PreviousPageButton.Location = new System.Drawing.Point(791, 0);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(68, 48);
            this.PreviousPageButton.TabIndex = 10;
            this.PreviousPageButton.TabStop = false;
            this.PreviousPageButton.Tag = "上页";
            // 
            // NextPageButton
            // 
            this.NextPageButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.NextPageButton.Image = global::MedicalSystem.Anes.Document.Properties.Resources.下页1;
            this.NextPageButton.Location = new System.Drawing.Point(859, 0);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(68, 48);
            this.NextPageButton.TabIndex = 9;
            this.NextPageButton.TabStop = false;
            this.NextPageButton.Tag = "下页";
            // 
            // btnMultiPrint
            // 
            this.btnMultiPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMultiPrint.Image = global::MedicalSystem.Anes.Document.Properties.Resources.集中打印1;
            this.btnMultiPrint.Location = new System.Drawing.Point(544, 0);
            this.btnMultiPrint.Name = "btnMultiPrint";
            this.btnMultiPrint.Size = new System.Drawing.Size(68, 48);
            this.btnMultiPrint.TabIndex = 8;
            this.btnMultiPrint.TabStop = false;
            this.btnMultiPrint.Tag = "集中打印";
            // 
            // PrintButton
            // 
            this.PrintButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.PrintButton.Image = global::MedicalSystem.Anes.Document.Properties.Resources.打印1;
            this.PrintButton.Location = new System.Drawing.Point(476, 0);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(68, 48);
            this.PrintButton.TabIndex = 7;
            this.PrintButton.TabStop = false;
            this.PrintButton.Tag = "打印";
            // 
            // pictureBoxYuLan
            // 
            this.pictureBoxYuLan.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxYuLan.Image = global::MedicalSystem.Anes.Document.Properties.Resources.预览1;
            this.pictureBoxYuLan.Location = new System.Drawing.Point(408, 0);
            this.pictureBoxYuLan.Name = "pictureBoxYuLan";
            this.pictureBoxYuLan.Size = new System.Drawing.Size(68, 48);
            this.pictureBoxYuLan.TabIndex = 6;
            this.pictureBoxYuLan.TabStop = false;
            this.pictureBoxYuLan.Tag = "预览";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Image = global::MedicalSystem.Anes.Document.Properties.Resources.归档1;
            this.button2.Location = new System.Drawing.Point(340, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 48);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Tag = "归档";
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaveButton.Image = global::MedicalSystem.Anes.Document.Properties.Resources.保存1;
            this.SaveButton.Location = new System.Drawing.Point(272, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(68, 48);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.TabStop = false;
            this.SaveButton.Tag = "保存";
            // 
            // SaveDataTemplate
            // 
            this.SaveDataTemplate.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaveDataTemplate.Image = global::MedicalSystem.Anes.Document.Properties.Resources.保存模版1;
            this.SaveDataTemplate.Location = new System.Drawing.Point(204, 0);
            this.SaveDataTemplate.Name = "SaveDataTemplate";
            this.SaveDataTemplate.Size = new System.Drawing.Size(68, 48);
            this.SaveDataTemplate.TabIndex = 3;
            this.SaveDataTemplate.TabStop = false;
            this.SaveDataTemplate.Tag = "保存模板";
            // 
            // ApplyDataTemplate
            // 
            this.ApplyDataTemplate.Dock = System.Windows.Forms.DockStyle.Left;
            this.ApplyDataTemplate.Image = global::MedicalSystem.Anes.Document.Properties.Resources.调用模版1;
            this.ApplyDataTemplate.Location = new System.Drawing.Point(136, 0);
            this.ApplyDataTemplate.Name = "ApplyDataTemplate";
            this.ApplyDataTemplate.Size = new System.Drawing.Size(68, 48);
            this.ApplyDataTemplate.TabIndex = 2;
            this.ApplyDataTemplate.TabStop = false;
            this.ApplyDataTemplate.Tag = "调用模板";
            // 
            // pictureBoxSuoFang
            // 
            this.pictureBoxSuoFang.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxSuoFang.Image = global::MedicalSystem.Anes.Document.Properties.Resources.缩放1;
            this.pictureBoxSuoFang.Location = new System.Drawing.Point(68, 0);
            this.pictureBoxSuoFang.Name = "pictureBoxSuoFang";
            this.pictureBoxSuoFang.Size = new System.Drawing.Size(68, 48);
            this.pictureBoxSuoFang.TabIndex = 1;
            this.pictureBoxSuoFang.TabStop = false;
            this.pictureBoxSuoFang.Tag = "缩放";
            // 
            // DesignButton
            // 
            this.DesignButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.DesignButton.Image = global::MedicalSystem.Anes.Document.Properties.Resources.配置1;
            this.DesignButton.Location = new System.Drawing.Point(0, 0);
            this.DesignButton.Name = "DesignButton";
            this.DesignButton.Size = new System.Drawing.Size(68, 48);
            this.DesignButton.TabIndex = 0;
            this.DesignButton.TabStop = false;
            this.DesignButton.Tag = "配置";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelDoc
            // 
            this.panelDoc.Controls.Add(this.MedReportView);
            this.panelDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDoc.Location = new System.Drawing.Point(0, 78);
            this.panelDoc.Name = "panelDoc";
            this.panelDoc.Size = new System.Drawing.Size(927, 346);
            this.panelDoc.TabIndex = 1;
            // 
            // MedReportView
            // 
            this.MedReportView.BackColor = System.Drawing.SystemColors.Control;
            this.MedReportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MedReportView.Location = new System.Drawing.Point(0, 0);
            this.MedReportView.Name = "MedReportView";
            this.MedReportView.Padding = new System.Windows.Forms.Padding(10);
            this.MedReportView.Size = new System.Drawing.Size(927, 346);
            this.MedReportView.TabIndex = 0;
            this.MedReportView.Load += new System.EventHandler(this.MedReportView_Load);
            this.MedReportView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MedReportView_MouseDown);
            // 
            // panelTabControl
            // 
            this.panelTabControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTabControl.Controls.Add(this.downMenuDoc);
            this.panelTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTabControl.Location = new System.Drawing.Point(0, 48);
            this.panelTabControl.Name = "panelTabControl";
            this.panelTabControl.Size = new System.Drawing.Size(927, 30);
            this.panelTabControl.TabIndex = 2;
            this.panelTabControl.Visible = false;
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 10;
            this.medScrollbar1.Location = new System.Drawing.Point(911, 79);
            this.medScrollbar1.Maximum = 100;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 344);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 2;
            this.medScrollbar1.ThisControl = this.panelDoc;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // BaseDoc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.medScrollbar1);
            this.Controls.Add(this.panelDoc);
            this.Controls.Add(this.panelTabControl);
            this.Controls.Add(this.ToolBarLayoutPanel);
            this.Name = "BaseDoc";
            this.Size = new System.Drawing.Size(927, 424);
            this.Resize += new System.EventHandler(this.BaseDoc_Resize);
            this.ToolBarLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviousPageButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextPageButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMultiPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYuLan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveDataTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDataTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuoFang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesignButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelDoc.ResumeLayout(false);
            this.panelTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel ToolBarLayoutPanel;
        protected System.Windows.Forms.PictureBox btnMultiPrint;
        protected System.Windows.Forms.PictureBox PrintButton;
        protected System.Windows.Forms.PictureBox pictureBoxYuLan;
        protected System.Windows.Forms.PictureBox button2;
        protected System.Windows.Forms.PictureBox SaveButton;
        protected System.Windows.Forms.PictureBox SaveDataTemplate;
        protected System.Windows.Forms.PictureBox ApplyDataTemplate;
        protected System.Windows.Forms.PictureBox pictureBoxSuoFang;
        protected System.Windows.Forms.PictureBox DesignButton;
        protected System.Windows.Forms.PictureBox PreviousPageButton;
        protected System.Windows.Forms.PictureBox NextPageButton;
        private Controls.MedReportView MedReportView;
        //  private Client.FrameWork.MedScrollbar medScrollbar1;
        private System.Windows.Forms.Panel panelDoc;
        private System.Windows.Forms.Panel panelTabControl;
        private Controls.MedScrollbar medScrollbar1;
        private Controls.DownMenuDoc downMenuDoc;

    }
}
