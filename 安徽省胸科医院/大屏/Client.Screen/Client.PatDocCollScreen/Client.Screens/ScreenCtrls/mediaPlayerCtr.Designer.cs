using MedicalSystem.MedScreen.Controls;

namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    partial class mediaPlayerCtr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mediaPlayerCtr));
            this.Listmemu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.隐藏播放控制HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mediaPlayArea = new customPnl();
            this.browserPPT = new System.Windows.Forms.WebBrowser();
            this.btnHideList = new System.Windows.Forms.Button();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.grpBoxContainer = new System.Windows.Forms.GroupBox();
            this.playList = new System.Windows.Forms.ListBox();
            this.leftMargin = new customPnl();
            this.rightMargin = new customPnl();
            this.bottomMargin = new customPnl();
            this.Listmemu.SuspendLayout();
            this.mediaPlayArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.grpBoxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Listmemu
            // 
            this.Listmemu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.播放ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.隐藏播放控制HToolStripMenuItem});
            this.Listmemu.Name = "Listmemu";
            this.Listmemu.Size = new System.Drawing.Size(198, 126);
            // 
            // 播放ToolStripMenuItem
            // 
            this.播放ToolStripMenuItem.Name = "播放ToolStripMenuItem";
            this.播放ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.播放ToolStripMenuItem.Text = "播放(&P)";
            this.播放ToolStripMenuItem.Click += new System.EventHandler(this.播放ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 6);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.添加ToolStripMenuItem.Text = "添加(&A)";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.删除ToolStripMenuItem.Text = "删除(&D)";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.清空ToolStripMenuItem.Text = "清空播放列表(&C)";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // 隐藏播放控制HToolStripMenuItem
            // 
            this.隐藏播放控制HToolStripMenuItem.Name = "隐藏播放控制HToolStripMenuItem";
            this.隐藏播放控制HToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.隐藏播放控制HToolStripMenuItem.Text = "隐藏(显示)播放控制(H)";
            this.隐藏播放控制HToolStripMenuItem.Click += new System.EventHandler(this.隐藏播放控制HToolStripMenuItem_Click);
            // 
            // mediaPlayArea
            // 
            this.mediaPlayArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mediaPlayArea.Controls.Add(this.browserPPT);
            this.mediaPlayArea.Controls.Add(this.btnHideList);
            this.mediaPlayArea.Controls.Add(this.mediaPlayer);
            this.mediaPlayArea.Controls.Add(this.grpBoxContainer);
            this.mediaPlayArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayArea.Location = new System.Drawing.Point(37, 0);
            this.mediaPlayArea.Name = "mediaPlayArea";
            this.mediaPlayArea.Size = new System.Drawing.Size(390, 321);
            this.mediaPlayArea.TabIndex = 6;
            // 
            // browserPPT
            // 
            this.browserPPT.Location = new System.Drawing.Point(127, 106);
            this.browserPPT.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserPPT.Name = "browserPPT";
            this.browserPPT.Size = new System.Drawing.Size(152, 112);
            this.browserPPT.TabIndex = 8;
            this.browserPPT.Visible = false;
            // 
            // btnHideList
            // 
            this.btnHideList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHideList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            this.btnHideList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHideList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHideList.Location = new System.Drawing.Point(285, 106);
            this.btnHideList.Name = "btnHideList";
            this.btnHideList.Size = new System.Drawing.Size(15, 42);
            this.btnHideList.TabIndex = 7;
            this.btnHideList.Text = ">";
            this.btnHideList.UseVisualStyleBackColor = false;
            this.btnHideList.Click += new System.EventHandler(this.btnHideList_Click);
            this.btnHideList.MouseHover += new System.EventHandler(this.btnHideList_Click);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(300, 321);
            this.mediaPlayer.TabIndex = 6;
            this.mediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.mediaPlayer_PlayStateChange);
            // 
            // grpBoxContainer
            // 
            this.grpBoxContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            this.grpBoxContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grpBoxContainer.Controls.Add(this.playList);
            this.grpBoxContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpBoxContainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpBoxContainer.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.grpBoxContainer.ForeColor = System.Drawing.Color.Black;
            this.grpBoxContainer.Location = new System.Drawing.Point(300, 0);
            this.grpBoxContainer.Name = "grpBoxContainer";
            this.grpBoxContainer.Size = new System.Drawing.Size(90, 321);
            this.grpBoxContainer.TabIndex = 5;
            this.grpBoxContainer.TabStop = false;
            this.grpBoxContainer.Text = "播放列表";
            // 
            // playList
            // 
            this.playList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            this.playList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playList.ContextMenuStrip = this.Listmemu;
            this.playList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playList.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.playList.ForeColor = System.Drawing.Color.Black;
            this.playList.FormattingEnabled = true;
            this.playList.ItemHeight = 19;
            this.playList.Items.AddRange(new object[] {
            "宣教视频",
            "欢迎视频",
            "医院文明建设"});
            this.playList.Location = new System.Drawing.Point(3, 21);
            this.playList.MultiColumn = true;
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(84, 297);
            this.playList.TabIndex = 0;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.playList_SelectedIndexChanged);
            this.playList.DoubleClick += new System.EventHandler(this.playList_DoubleClick);
            this.playList.MouseHover += new System.EventHandler(this.playList_MouseHover);
            // 
            // leftMargin
            // 
            this.leftMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftMargin.Location = new System.Drawing.Point(0, 0);
            this.leftMargin.Name = "leftMargin";
            this.leftMargin.Size = new System.Drawing.Size(37, 321);
            this.leftMargin.TabIndex = 5;
            // 
            // rightMargin
            // 
            this.rightMargin.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightMargin.Location = new System.Drawing.Point(427, 0);
            this.rightMargin.Name = "rightMargin";
            this.rightMargin.Size = new System.Drawing.Size(10, 321);
            this.rightMargin.TabIndex = 4;
            // 
            // bottomMargin
            // 
            this.bottomMargin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomMargin.Location = new System.Drawing.Point(0, 321);
            this.bottomMargin.Name = "bottomMargin";
            this.bottomMargin.Size = new System.Drawing.Size(437, 10);
            this.bottomMargin.TabIndex = 2;
            // 
            // mediaPlayerCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mediaPlayArea);
            this.Controls.Add(this.leftMargin);
            this.Controls.Add(this.rightMargin);
            this.Controls.Add(this.bottomMargin);
            this.Name = "mediaPlayerCtr";
            this.Size = new System.Drawing.Size(437, 331);
            this.Load += new System.EventHandler(this.mediaPlayerCtr_Load);
            this.Listmemu.ResumeLayout(false);
            this.mediaPlayArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.grpBoxContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private customPnl bottomMargin;
        private customPnl leftMargin;
        private customPnl rightMargin;
        private customPnl mediaPlayArea;
        private System.Windows.Forms.GroupBox grpBoxContainer;
        private System.Windows.Forms.ListBox playList;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.ContextMenuStrip Listmemu;
        private System.Windows.Forms.ToolStripMenuItem 播放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button btnHideList;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem 隐藏播放控制HToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.WebBrowser browserPPT;
    }
}
