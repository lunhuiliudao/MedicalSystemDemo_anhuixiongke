namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PatientMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientMain));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.panelList = new System.Windows.Forms.Panel();
            this.treeViewExtendList = new MedicalSystem.Anes.Client.FrameWork.TreeViewExtend(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.Color.Silver;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerMain.Panel1.Controls.Add(this.panel2);
            this.splitContainerMain.Panel1.Controls.Add(this.medScrollbar1);
            this.splitContainerMain.Panel1.Controls.Add(this.panelList);
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(10, 20, 5, 10);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerMain.Panel2.Controls.Add(this.panelBody);
            this.splitContainerMain.Panel2.Controls.Add(this.panel1);
            this.splitContainerMain.Panel2.Padding = new System.Windows.Forms.Padding(20, 20, 15, 10);
            this.splitContainerMain.Size = new System.Drawing.Size(1187, 856);
            this.splitContainerMain.SplitterDistance = 289;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 0;
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 826;
            this.medScrollbar1.Location = new System.Drawing.Point(268, 21);
            this.medScrollbar1.Maximum = 829;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 824);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 3;
            this.medScrollbar1.ThisControl = this.panelList;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // panelList
            // 
            this.panelList.AutoScroll = true;
            this.panelList.Controls.Add(this.treeViewExtendList);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(10, 20);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panelList.Size = new System.Drawing.Size(274, 826);
            this.panelList.TabIndex = 2;
            // 
            // treeViewExtendList
            // 
            this.treeViewExtendList.BackColor = System.Drawing.Color.White;
            this.treeViewExtendList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewExtendList.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewExtendList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeViewExtendList.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeViewExtendList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.treeViewExtendList.FullRowSelect = true;
            this.treeViewExtendList.HideSelection = false;
            this.treeViewExtendList.HotTracking = true;
            this.treeViewExtendList.ItemHeight = 30;
            this.treeViewExtendList.Location = new System.Drawing.Point(0, 15);
            this.treeViewExtendList.Name = "treeViewExtendList";
            this.treeViewExtendList.Size = new System.Drawing.Size(262, 811);
            this.treeViewExtendList.TabIndex = 0;
            this.treeViewExtendList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewExtendList_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(184)))), ((int)(((byte)(230)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 3);
            this.panel2.TabIndex = 121;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(184)))), ((int)(((byte)(230)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 3);
            this.panel1.TabIndex = 121;
            // 
            // panelBody
            // 
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(20, 23);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(862, 823);
            this.panelBody.TabIndex = 122;
            // 
            // PatientMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "PatientMain";
            this.Size = new System.Drawing.Size(1187, 856);
            this.Load += new System.EventHandler(this.PatientMain_Load);
            this.Resize += new System.EventHandler(this.PatientMain_Resize);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelList;
        private FrameWork.TreeViewExtend treeViewExtendList;
        private Document.Controls.MedScrollbar medScrollbar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBody;
    }
}
