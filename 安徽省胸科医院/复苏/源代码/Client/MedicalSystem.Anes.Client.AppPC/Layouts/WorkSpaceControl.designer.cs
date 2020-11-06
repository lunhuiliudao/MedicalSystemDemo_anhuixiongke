namespace MedicalSystem.Anes.Client.AppPC
{
    partial class WorkSpaceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkSpaceControl));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelTopEvent = new System.Windows.Forms.Panel();
            this.panelVitalSign = new System.Windows.Forms.Label();
            this.panelAnesEvent = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelControlContainter = new System.Windows.Forms.Panel();
            this.panelProcess = new System.Windows.Forms.Panel();
            this.toolBarsControl1 = new MedicalSystem.Anes.Client.AppPC.ToolBarsControl();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblDocTtile = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panelMIAOBIAN = new System.Windows.Forms.Panel();
            this.panelControlEvent = new System.Windows.Forms.Panel();
            this.panelControlSelector = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRescue = new System.Windows.Forms.Panel();
            this.lblRescue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.panelTopEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelProcess.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panelMIAOBIAN.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelRescue.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideSpeed = 10;
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // panelTopEvent
            // 
            this.panelTopEvent.BackColor = System.Drawing.Color.White;
            this.panelTopEvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTopEvent.BackgroundImage")));
            this.panelTopEvent.Controls.Add(this.panelVitalSign);
            this.panelTopEvent.Controls.Add(this.panelAnesEvent);
            this.panelTopEvent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopEvent.Location = new System.Drawing.Point(0, 0);
            this.panelTopEvent.Name = "panelTopEvent";
            this.panelTopEvent.Size = new System.Drawing.Size(792, 40);
            this.panelTopEvent.TabIndex = 6;
            // 
            // panelVitalSign
            // 
            this.panelVitalSign.BackColor = System.Drawing.Color.Transparent;
            this.panelVitalSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVitalSign.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.panelVitalSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(166)))));
            this.panelVitalSign.Location = new System.Drawing.Point(396, 0);
            this.panelVitalSign.Name = "panelVitalSign";
            this.panelVitalSign.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.panelVitalSign.Size = new System.Drawing.Size(396, 40);
            this.panelVitalSign.TabIndex = 100;
            this.panelVitalSign.Text = "体征数据";
            this.panelVitalSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.panelVitalSign.Click += new System.EventHandler(this.panelVitalSign_Click);
            // 
            // panelAnesEvent
            // 
            this.panelAnesEvent.BackColor = System.Drawing.Color.Transparent;
            this.panelAnesEvent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAnesEvent.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.panelAnesEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.panelAnesEvent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelAnesEvent.Location = new System.Drawing.Point(0, 0);
            this.panelAnesEvent.Name = "panelAnesEvent";
            this.panelAnesEvent.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.panelAnesEvent.Size = new System.Drawing.Size(396, 40);
            this.panelAnesEvent.TabIndex = 99;
            this.panelAnesEvent.Text = "麻醉事件";
            this.panelAnesEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.panelAnesEvent.Click += new System.EventHandler(this.panelAnesEvent_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panelControlContainter);
            this.splitContainer1.Panel1.Controls.Add(this.panelProcess);
            this.splitContainer1.Panel1.Controls.Add(this.panelTitle);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.panelMIAOBIAN);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 40, 0);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1155, 434);
            this.splitContainer1.SplitterDistance = 635;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 5;
            // 
            // panelControlContainter
            // 
            this.panelControlContainter.BackColor = System.Drawing.Color.White;
            this.panelControlContainter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlContainter.Location = new System.Drawing.Point(0, 87);
            this.panelControlContainter.Name = "panelControlContainter";
            this.panelControlContainter.Padding = new System.Windows.Forms.Padding(4);
            this.panelControlContainter.Size = new System.Drawing.Size(1145, 347);
            this.panelControlContainter.TabIndex = 0;
            // 
            // panelProcess
            // 
            this.panelProcess.Controls.Add(this.toolBarsControl1);
            this.panelProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProcess.Location = new System.Drawing.Point(0, 28);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(1145, 59);
            this.panelProcess.TabIndex = 8;
            this.panelProcess.Visible = false;
            // 
            // toolBarsControl1
            // 
            this.toolBarsControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolBarsControl1.BackgroundImage")));
            this.toolBarsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarsControl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarsControl1.MainFormRef = null;
            this.toolBarsControl1.Name = "toolBarsControl1";
            this.toolBarsControl1.Size = new System.Drawing.Size(1145, 59);
            this.toolBarsControl1.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTitle.BackgroundImage")));
            this.panelTitle.Controls.Add(this.lblDocTtile);
            this.panelTitle.Controls.Add(this.pictureBox6);
            this.panelTitle.Controls.Add(this.pictureBox7);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1145, 28);
            this.panelTitle.TabIndex = 92;
            this.panelTitle.Visible = false;
            // 
            // lblDocTtile
            // 
            this.lblDocTtile.BackColor = System.Drawing.Color.Transparent;
            this.lblDocTtile.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDocTtile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDocTtile.Image = ((System.Drawing.Image)(resources.GetObject("lblDocTtile.Image")));
            this.lblDocTtile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDocTtile.Location = new System.Drawing.Point(4, 0);
            this.lblDocTtile.Name = "lblDocTtile";
            this.lblDocTtile.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblDocTtile.Size = new System.Drawing.Size(92, 28);
            this.lblDocTtile.TabIndex = 97;
            this.lblDocTtile.Text = "麻醉记录单";
            this.lblDocTtile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(0, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(4, 28);
            this.pictureBox6.TabIndex = 90;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(1141, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(4, 28);
            this.pictureBox7.TabIndex = 98;
            this.pictureBox7.TabStop = false;
            // 
            // panelMIAOBIAN
            // 
            this.panelMIAOBIAN.BackColor = System.Drawing.Color.Transparent;
            this.panelMIAOBIAN.Controls.Add(this.panelControlEvent);
            this.panelMIAOBIAN.Controls.Add(this.panelControlSelector);
            this.panelMIAOBIAN.Controls.Add(this.panel2);
            this.panelMIAOBIAN.Controls.Add(this.panel4);
            this.panelMIAOBIAN.Controls.Add(this.panel5);
            this.panelMIAOBIAN.Controls.Add(this.panel3);
            this.panelMIAOBIAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMIAOBIAN.Location = new System.Drawing.Point(10, 40);
            this.panelMIAOBIAN.Name = "panelMIAOBIAN";
            this.panelMIAOBIAN.Size = new System.Drawing.Size(46, 60);
            this.panelMIAOBIAN.TabIndex = 1;
            // 
            // panelControlEvent
            // 
            this.panelControlEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(233)))), ((int)(((byte)(250)))));
            this.panelControlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlEvent.Location = new System.Drawing.Point(1, 222);
            this.panelControlEvent.Name = "panelControlEvent";
            this.panelControlEvent.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.panelControlEvent.Size = new System.Drawing.Size(44, -163);
            this.panelControlEvent.TabIndex = 7;
            // 
            // panelControlSelector
            // 
            this.panelControlSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(233)))), ((int)(((byte)(250)))));
            this.panelControlSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlSelector.Location = new System.Drawing.Point(1, 2);
            this.panelControlSelector.Name = "panelControlSelector";
            this.panelControlSelector.Padding = new System.Windows.Forms.Padding(4);
            this.panelControlSelector.Size = new System.Drawing.Size(44, 220);
            this.panelControlSelector.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(173)))), ((int)(((byte)(204)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 1);
            this.panel2.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(173)))), ((int)(((byte)(204)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(45, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 58);
            this.panel4.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(173)))), ((int)(((byte)(204)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 58);
            this.panel5.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(46, 2);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelRescue);
            this.panel1.Controls.Add(this.panelTopEvent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(46, 40);
            this.panel1.TabIndex = 101;
            // 
            // panelRescue
            // 
            this.panelRescue.BackColor = System.Drawing.Color.White;
            this.panelRescue.Controls.Add(this.lblRescue);
            this.panelRescue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRescue.Location = new System.Drawing.Point(792, 0);
            this.panelRescue.Name = "panelRescue";
            this.panelRescue.Size = new System.Drawing.Size(0, 40);
            this.panelRescue.TabIndex = 102;
            // 
            // lblRescue
            // 
            this.lblRescue.BackColor = System.Drawing.Color.Transparent;
            this.lblRescue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRescue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRescue.Image = ((System.Drawing.Image)(resources.GetObject("lblRescue.Image")));
            this.lblRescue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRescue.Location = new System.Drawing.Point(-122, 0);
            this.lblRescue.Name = "lblRescue";
            this.lblRescue.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblRescue.Size = new System.Drawing.Size(122, 40);
            this.lblRescue.TabIndex = 99;
            this.lblRescue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRescue.Visible = false;
            this.lblRescue.Click += new System.EventHandler(this.lblRescue_Click);
            this.lblRescue.MouseLeave += new System.EventHandler(this.lblRescue_MouseLeave);
            this.lblRescue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblRescue_MouseMove);
            // 
            // WorkSpaceControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkSpaceControl";
            this.Size = new System.Drawing.Size(1155, 434);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.panelTopEvent.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelProcess.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panelMIAOBIAN.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelRescue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private System.Windows.Forms.Panel panelTopEvent;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelControlEvent;
        private System.Windows.Forms.Panel panelControlSelector;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblDocTtile;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panelProcess;
        public ToolBarsControl toolBarsControl1;
        private System.Windows.Forms.Panel panelControlContainter;
        private System.Windows.Forms.Label panelVitalSign;
        private System.Windows.Forms.Label panelAnesEvent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelRescue;
        private System.Windows.Forms.Label lblRescue;
        private System.Windows.Forms.Panel panelMIAOBIAN;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}
