using MedicalSystem.MedScreen.Controls;
namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    partial class OperScheduleScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperScheduleScreen));
            this.dateTime = new System.Windows.Forms.Timer(this.components);
            this.timerRefreshPage = new System.Windows.Forms.Timer(this.components);
            this.msgTimer = new System.Windows.Forms.Timer(this.components);
            this.AreaPnlContainer = new customPnl();
            this.screenPnlNormal = new customPnl();
            this.normalPnlContainer = new customPnl();
            this.normalContentArea = new customPnl();
            this.normalContentTitle = new customPnl();
            this.normalPnlTop = new customPnl();
            this.screenPnl12 = new customPnl();
            this.screenPnlSequence = new customPnl();
            this.seqPnlContainer = new customPnl();
            this.seqContentArea = new customPnl();
            this.seqContentTitle = new customPnl();
            this.seqPnlTop = new customPnl();
            this.screenPnl13 = new customPnl();
            this.screenBottomPnl = new customPnl();
            this.screenTopPnl = new customPnl();
            this.screenPnlTime = new customPnl();
            this.screenPnlLabel = new customPnl();
            this.AreaPnlContainer.SuspendLayout();
            this.screenPnlNormal.SuspendLayout();
            this.normalPnlContainer.SuspendLayout();
            this.normalPnlTop.SuspendLayout();
            this.screenPnlSequence.SuspendLayout();
            this.seqPnlContainer.SuspendLayout();
            this.seqPnlTop.SuspendLayout();
            this.screenTopPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTime
            // 
            this.dateTime.Interval = 60000;
            this.dateTime.Tick += new System.EventHandler(this.dateTime_Tick);
            // 
            // timerRefreshPage
            // 
            this.timerRefreshPage.Interval = 60000;
            this.timerRefreshPage.Tick += new System.EventHandler(this.timerRefreshPage_Tick);
            // 
            // msgTimer
            // 
            this.msgTimer.Interval = 150;
            this.msgTimer.Tick += new System.EventHandler(this.msgTimer_Tick);
            // 
            // AreaPnlContainer
            // 
            this.AreaPnlContainer.Controls.Add(this.screenPnlNormal);
            this.AreaPnlContainer.Controls.Add(this.screenPnlSequence);
            this.AreaPnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AreaPnlContainer.Location = new System.Drawing.Point(0, 45);
            this.AreaPnlContainer.Name = "AreaPnlContainer";
            this.AreaPnlContainer.Size = new System.Drawing.Size(872, 439);
            this.AreaPnlContainer.TabIndex = 5;
            // 
            // screenPnlNormal
            // 
            this.screenPnlNormal.BackColor = System.Drawing.Color.Transparent;
            this.screenPnlNormal.Controls.Add(this.normalPnlContainer);
            this.screenPnlNormal.Controls.Add(this.normalPnlTop);
            this.screenPnlNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenPnlNormal.Location = new System.Drawing.Point(0, 0);
            this.screenPnlNormal.Name = "screenPnlNormal";
            this.screenPnlNormal.Size = new System.Drawing.Size(499, 439);
            this.screenPnlNormal.TabIndex = 4;
            // 
            // normalPnlContainer
            // 
            this.normalPnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.normalPnlContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.normalPnlContainer.Controls.Add(this.normalContentArea);
            this.normalPnlContainer.Controls.Add(this.normalContentTitle);
            this.normalPnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalPnlContainer.Location = new System.Drawing.Point(0, 42);
            this.normalPnlContainer.Name = "normalPnlContainer";
            this.normalPnlContainer.Size = new System.Drawing.Size(499, 397);
            this.normalPnlContainer.TabIndex = 4;
            // 
            // normalContentArea
            // 
            this.normalContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalContentArea.Location = new System.Drawing.Point(0, 41);
            this.normalContentArea.Name = "normalContentArea";
            this.normalContentArea.Size = new System.Drawing.Size(499, 356);
            this.normalContentArea.TabIndex = 1;
            this.normalContentArea.Paint += new System.Windows.Forms.PaintEventHandler(this.normalContentArea_Paint);
            // 
            // normalContentTitle
            // 
            this.normalContentTitle.BackgroundImage = global::ClientScreens.Properties.Resources.灰底;
            this.normalContentTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.normalContentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.normalContentTitle.Location = new System.Drawing.Point(0, 0);
            this.normalContentTitle.Name = "normalContentTitle";
            this.normalContentTitle.Size = new System.Drawing.Size(499, 41);
            this.normalContentTitle.TabIndex = 0;
            this.normalContentTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.normalContentTitle_Paint);
            // 
            // normalPnlTop
            // 
            this.normalPnlTop.BackColor = System.Drawing.Color.Transparent;
            this.normalPnlTop.Controls.Add(this.screenPnl12);
            this.normalPnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.normalPnlTop.Location = new System.Drawing.Point(0, 0);
            this.normalPnlTop.Name = "normalPnlTop";
            this.normalPnlTop.Size = new System.Drawing.Size(499, 42);
            this.normalPnlTop.TabIndex = 3;
            this.normalPnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.normalPnlTop_Paint);
            // 
            // screenPnl12
            // 
            this.screenPnl12.BackColor = System.Drawing.Color.Transparent;
            this.screenPnl12.BackgroundImage = global::ClientScreens.Properties.Resources.当前手术;
            this.screenPnl12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenPnl12.Dock = System.Windows.Forms.DockStyle.Left;
            this.screenPnl12.Location = new System.Drawing.Point(0, 0);
            this.screenPnl12.Name = "screenPnl12";
            this.screenPnl12.Size = new System.Drawing.Size(160, 42);
            this.screenPnl12.TabIndex = 4;
            // 
            // screenPnlSequence
            // 
            this.screenPnlSequence.BackColor = System.Drawing.Color.Transparent;
            this.screenPnlSequence.Controls.Add(this.seqPnlContainer);
            this.screenPnlSequence.Controls.Add(this.seqPnlTop);
            this.screenPnlSequence.Dock = System.Windows.Forms.DockStyle.Right;
            this.screenPnlSequence.Location = new System.Drawing.Point(499, 0);
            this.screenPnlSequence.Name = "screenPnlSequence";
            this.screenPnlSequence.Size = new System.Drawing.Size(373, 439);
            this.screenPnlSequence.TabIndex = 3;
            // 
            // seqPnlContainer
            // 
            this.seqPnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.seqPnlContainer.Controls.Add(this.seqContentArea);
            this.seqPnlContainer.Controls.Add(this.seqContentTitle);
            this.seqPnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seqPnlContainer.Location = new System.Drawing.Point(0, 42);
            this.seqPnlContainer.Name = "seqPnlContainer";
            this.seqPnlContainer.Size = new System.Drawing.Size(373, 397);
            this.seqPnlContainer.TabIndex = 5;
            // 
            // seqContentArea
            // 
            this.seqContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seqContentArea.Location = new System.Drawing.Point(0, 41);
            this.seqContentArea.Name = "seqContentArea";
            this.seqContentArea.Size = new System.Drawing.Size(373, 356);
            this.seqContentArea.TabIndex = 2;
            this.seqContentArea.Paint += new System.Windows.Forms.PaintEventHandler(this.seqContentArea_Paint);
            // 
            // seqContentTitle
            // 
            this.seqContentTitle.BackgroundImage = global::ClientScreens.Properties.Resources.灰底;
            this.seqContentTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.seqContentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.seqContentTitle.Location = new System.Drawing.Point(0, 0);
            this.seqContentTitle.Name = "seqContentTitle";
            this.seqContentTitle.Size = new System.Drawing.Size(373, 41);
            this.seqContentTitle.TabIndex = 1;
            this.seqContentTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.seqContentTitle_Paint);
            // 
            // seqPnlTop
            // 
            this.seqPnlTop.BackColor = System.Drawing.Color.Transparent;
            this.seqPnlTop.Controls.Add(this.screenPnl13);
            this.seqPnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.seqPnlTop.Location = new System.Drawing.Point(0, 0);
            this.seqPnlTop.Name = "seqPnlTop";
            this.seqPnlTop.Size = new System.Drawing.Size(373, 42);
            this.seqPnlTop.TabIndex = 4;
            // 
            // screenPnl13
            // 
            this.screenPnl13.BackColor = System.Drawing.Color.Transparent;
            this.screenPnl13.BackgroundImage = global::ClientScreens.Properties.Resources.接台手术;
            this.screenPnl13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenPnl13.Dock = System.Windows.Forms.DockStyle.Left;
            this.screenPnl13.Location = new System.Drawing.Point(0, 0);
            this.screenPnl13.Name = "screenPnl13";
            this.screenPnl13.Size = new System.Drawing.Size(160, 42);
            this.screenPnl13.TabIndex = 5;
            // 
            // screenBottomPnl
            // 
            this.screenBottomPnl.BackColor = System.Drawing.Color.Transparent;
            this.screenBottomPnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("screenBottomPnl.BackgroundImage")));
            this.screenBottomPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenBottomPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.screenBottomPnl.Location = new System.Drawing.Point(0, 484);
            this.screenBottomPnl.Name = "screenBottomPnl";
            this.screenBottomPnl.Size = new System.Drawing.Size(872, 37);
            this.screenBottomPnl.TabIndex = 4;
            this.screenBottomPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.screenBottomPnl_Paint);
            // 
            // screenTopPnl
            // 
            this.screenTopPnl.BackColor = System.Drawing.Color.Transparent;
            this.screenTopPnl.Controls.Add(this.screenPnlTime);
            this.screenTopPnl.Controls.Add(this.screenPnlLabel);
            this.screenTopPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.screenTopPnl.Location = new System.Drawing.Point(0, 0);
            this.screenTopPnl.Name = "screenTopPnl";
            this.screenTopPnl.Size = new System.Drawing.Size(872, 45);
            this.screenTopPnl.TabIndex = 1;
            // 
            // screenPnlTime
            // 
            this.screenPnlTime.BackgroundImage = global::ClientScreens.Properties.Resources.日期栏入;
            this.screenPnlTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenPnlTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenPnlTime.Location = new System.Drawing.Point(230, 0);
            this.screenPnlTime.Name = "screenPnlTime";
            this.screenPnlTime.Size = new System.Drawing.Size(642, 45);
            this.screenPnlTime.TabIndex = 1;
            this.screenPnlTime.Paint += new System.Windows.Forms.PaintEventHandler(this.screenPnlTime_Paint);
            this.screenPnlTime.DoubleClick += new System.EventHandler(this.screenPnlTime_DoubleClick);
            // 
            // screenPnlLabel
            // 
            this.screenPnlLabel.BackColor = System.Drawing.Color.Transparent;
            this.screenPnlLabel.BackgroundImage = global::ClientScreens.Properties.Resources.医院名称入;
            this.screenPnlLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenPnlLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.screenPnlLabel.Location = new System.Drawing.Point(0, 0);
            this.screenPnlLabel.Name = "screenPnlLabel";
            this.screenPnlLabel.Size = new System.Drawing.Size(230, 45);
            this.screenPnlLabel.TabIndex = 0;
            this.screenPnlLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.screenPnlLabel_Paint);
            // 
            // OperScheduleScreen
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.AreaPnlContainer);
            this.Controls.Add(this.screenBottomPnl);
            this.Controls.Add(this.screenTopPnl);
            this.DoubleBuffered = true;
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "OperScheduleScreen";
            this.Size = new System.Drawing.Size(872, 521);
            this.Load += new System.EventHandler(this.OperScheduleScreen_Load);
            this.AreaPnlContainer.ResumeLayout(false);
            this.screenPnlNormal.ResumeLayout(false);
            this.normalPnlContainer.ResumeLayout(false);
            this.normalPnlTop.ResumeLayout(false);
            this.screenPnlSequence.ResumeLayout(false);
            this.seqPnlContainer.ResumeLayout(false);
            this.seqPnlTop.ResumeLayout(false);
            this.screenTopPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private customPnl screenTopPnl;
        private customPnl screenPnlTime;
        private customPnl screenPnlLabel;
        private customPnl screenBottomPnl;
        private System.Windows.Forms.Timer dateTime;
        private customPnl AreaPnlContainer;
        private customPnl screenPnlNormal;
        private customPnl normalPnlContainer;
        private customPnl normalContentArea;
        private customPnl normalContentTitle;
        private customPnl normalPnlTop;
        private customPnl screenPnl12;
        private customPnl screenPnlSequence;
        private customPnl seqPnlContainer;
        private customPnl seqContentArea;
        private customPnl seqContentTitle;
        private customPnl seqPnlTop;
        private customPnl screenPnl13;
        private System.Windows.Forms.Timer timerRefreshPage;
        private System.Windows.Forms.Timer msgTimer;
    }
}
