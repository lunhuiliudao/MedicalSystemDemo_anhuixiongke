namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PatientStatusContrl
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.popupMenuStatus = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemOperationSatusManager = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemToAnesEnd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTurnToRoom = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTurnToICU = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTrunToPACU = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDictTurnToPACU = new DevExpress.XtraBars.BarButtonItem();
            this.barManagerStatus = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(681, 61);
            this.panelMain.TabIndex = 5;
            // 
            // popupMenuStatus
            // 
            this.popupMenuStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemOperationSatusManager),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemToAnesEnd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemTurnToRoom),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemTurnToICU),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemTrunToPACU),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDictTurnToPACU)});
            this.popupMenuStatus.Manager = this.barManagerStatus;
            this.popupMenuStatus.Name = "popupMenuStatus";
            // 
            // barButtonItemOperationSatusManager
            // 
            this.barButtonItemOperationSatusManager.Caption = "转到状态【入手术室】";
            this.barButtonItemOperationSatusManager.Id = 13;
            this.barButtonItemOperationSatusManager.Name = "barButtonItemOperationSatusManager";
            this.barButtonItemOperationSatusManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemToAnesEnd
            // 
            this.barButtonItemToAnesEnd.Caption = "转到状态【麻醉结束】";
            this.barButtonItemToAnesEnd.Id = 17;
            this.barButtonItemToAnesEnd.Name = "barButtonItemToAnesEnd";
            this.barButtonItemToAnesEnd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemTurnToRoom
            // 
            this.barButtonItemTurnToRoom.Caption = "转入病房";
            this.barButtonItemTurnToRoom.Id = 15;
            this.barButtonItemTurnToRoom.Name = "barButtonItemTurnToRoom";
            this.barButtonItemTurnToRoom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemTurnToICU
            // 
            this.barButtonItemTurnToICU.Caption = "转入ICU";
            this.barButtonItemTurnToICU.Id = 18;
            this.barButtonItemTurnToICU.Name = "barButtonItemTurnToICU";
            this.barButtonItemTurnToICU.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemTrunToPACU
            // 
            this.barButtonItemTrunToPACU.Caption = "进复苏室";
            this.barButtonItemTrunToPACU.Id = 16;
            this.barButtonItemTrunToPACU.Name = "barButtonItemTrunToPACU";
            this.barButtonItemTrunToPACU.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barButtonItemDictTurnToPACU
            // 
            this.barButtonItemDictTurnToPACU.Caption = "进PACU室";
            this.barButtonItemDictTurnToPACU.Id = 19;
            this.barButtonItemDictTurnToPACU.Name = "barButtonItemDictTurnToPACU";
            this.barButtonItemDictTurnToPACU.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOperationSatusManager_ItemClick);
            // 
            // barManagerStatus
            // 
            this.barManagerStatus.DockControls.Add(this.barDockControlTop);
            this.barManagerStatus.DockControls.Add(this.barDockControlBottom);
            this.barManagerStatus.DockControls.Add(this.barDockControlLeft);
            this.barManagerStatus.DockControls.Add(this.barDockControlRight);
            this.barManagerStatus.Form = this;
            this.barManagerStatus.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemOperationSatusManager,
            this.barButtonItemTurnToRoom,
            this.barButtonItemTurnToICU,
            this.barButtonItemTrunToPACU,
            this.barButtonItemToAnesEnd,
            this.barButtonItemDictTurnToPACU});
            this.barManagerStatus.MaxItemId = 20;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(681, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 61);
            this.barDockControlBottom.Size = new System.Drawing.Size(681, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 61);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(681, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 61);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PatientStatusContrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PatientStatusContrl";
            this.Size = new System.Drawing.Size(681, 61);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private DevExpress.XtraBars.PopupMenu popupMenuStatus;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOperationSatusManager;
        private DevExpress.XtraBars.BarButtonItem barButtonItemToAnesEnd;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTurnToRoom;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTurnToICU;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTrunToPACU;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDictTurnToPACU;
        private DevExpress.XtraBars.BarManager barManagerStatus;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
