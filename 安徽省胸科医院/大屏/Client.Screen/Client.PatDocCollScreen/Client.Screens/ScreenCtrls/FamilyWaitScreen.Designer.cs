
using MedicalSystem.MedScreen.Controls;
namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    partial class FamilyWaitScreen
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
            this.dateTime = new System.Windows.Forms.Timer(this.components);
            this.timerRefreshPage = new System.Windows.Forms.Timer(this.components);
            this.msgTimer = new System.Windows.Forms.Timer(this.components);
            this.screenPnl5 = new customPnl();
            this.screenPnl7 = new customPnl();
            this.normalContentArea = new customPnl();
            this.normalContentTitle = new customPnl();
            this.screenPnlRight = new customPnl();
            this.screenBottomPnl = new customPnl();
            this.screenTopPnl = new customPnl();
            this.screenPnlTime = new customPnl();
            this.screenPnlLabel = new customPnl();
            this.screenPnl5.SuspendLayout();
            this.screenPnl7.SuspendLayout();
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
            // screenPnl5
            // 
            this.screenPnl5.BackColor = System.Drawing.Color.Transparent;
            this.screenPnl5.Controls.Add(this.screenPnl7);
            this.screenPnl5.Controls.Add(this.screenPnlRight);
            this.screenPnl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenPnl5.Location = new System.Drawing.Point(0, 51);
            this.screenPnl5.Name = "screenPnl5";
            this.screenPnl5.Size = new System.Drawing.Size(862, 342);
            this.screenPnl5.TabIndex = 2;
            // 
            // screenPnl7
            // 
            this.screenPnl7.BackColor = System.Drawing.Color.Transparent;
            this.screenPnl7.Controls.Add(this.normalContentArea);
            this.screenPnl7.Controls.Add(this.normalContentTitle);
            this.screenPnl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenPnl7.Location = new System.Drawing.Point(0, 0);
            this.screenPnl7.Name = "screenPnl7";
            this.screenPnl7.Size = new System.Drawing.Size(430, 342);
            this.screenPnl7.TabIndex = 3;
            // 
            // normalContentArea
            // 
            this.normalContentArea.BackColor = System.Drawing.Color.Transparent;
            this.normalContentArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.normalContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalContentArea.Location = new System.Drawing.Point(0, 42);
            this.normalContentArea.Name = "normalContentArea";
            this.normalContentArea.Size = new System.Drawing.Size(430, 300);
            this.normalContentArea.TabIndex = 4;
            this.normalContentArea.Paint += new System.Windows.Forms.PaintEventHandler(this.normalContentArea_Paint);
            // 
            // normalContentTitle
            // 
            this.normalContentTitle.BackColor = System.Drawing.Color.Transparent;
            this.normalContentTitle.BackgroundImage = global::ClientScreens.Properties.Resources.灰底;
            this.normalContentTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.normalContentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.normalContentTitle.Location = new System.Drawing.Point(0, 0);
            this.normalContentTitle.Name = "normalContentTitle";
            this.normalContentTitle.Size = new System.Drawing.Size(430, 42);
            this.normalContentTitle.TabIndex = 3;
            this.normalContentTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.normalContentTitle_Paint);
            // 
            // screenPnlRight
            // 
            this.screenPnlRight.BackColor = System.Drawing.Color.Transparent;
            this.screenPnlRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenPnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.screenPnlRight.Location = new System.Drawing.Point(430, 0);
            this.screenPnlRight.Name = "screenPnlRight";
            this.screenPnlRight.Size = new System.Drawing.Size(432, 342);
            this.screenPnlRight.TabIndex = 2;
            // 
            // screenBottomPnl
            // 
            this.screenBottomPnl.BackColor = System.Drawing.Color.Transparent;
            this.screenBottomPnl.BackgroundImage = global::ClientScreens.Properties.Resources.底部通知栏;
            this.screenBottomPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenBottomPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.screenBottomPnl.Location = new System.Drawing.Point(0, 393);
            this.screenBottomPnl.Name = "screenBottomPnl";
            this.screenBottomPnl.Size = new System.Drawing.Size(862, 42);
            this.screenBottomPnl.TabIndex = 1;
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
            this.screenTopPnl.Size = new System.Drawing.Size(862, 51);
            this.screenTopPnl.TabIndex = 0;
            // 
            // screenPnlTime
            // 
            this.screenPnlTime.BackgroundImage = global::ClientScreens.Properties.Resources.日期栏入;
            this.screenPnlTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenPnlTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenPnlTime.Location = new System.Drawing.Point(239, 0);
            this.screenPnlTime.Name = "screenPnlTime";
            this.screenPnlTime.Size = new System.Drawing.Size(623, 51);
            this.screenPnlTime.TabIndex = 1;
            this.screenPnlTime.Paint += new System.Windows.Forms.PaintEventHandler(this.screenPnlTime_Paint);
            this.screenPnlTime.DoubleClick += new System.EventHandler(this.screenPnlTime_DoubleClick);
            // 
            // screenPnlLabel
            // 
            this.screenPnlLabel.BackgroundImage = global::ClientScreens.Properties.Resources.医院名称入;
            this.screenPnlLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screenPnlLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.screenPnlLabel.Location = new System.Drawing.Point(0, 0);
            this.screenPnlLabel.Name = "screenPnlLabel";
            this.screenPnlLabel.Size = new System.Drawing.Size(239, 51);
            this.screenPnlLabel.TabIndex = 0;
            this.screenPnlLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.screenPnlLabel_Paint);
            // 
            // FamilyWaitScreen
            // 
            this.Appearance.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClientScreens.Properties.Resources.背景图;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.screenPnl5);
            this.Controls.Add(this.screenBottomPnl);
            this.Controls.Add(this.screenTopPnl);
            this.DoubleBuffered = true;
            this.Name = "FamilyWaitScreen";
            this.Size = new System.Drawing.Size(862, 435);
            this.Load += new System.EventHandler(this.FamilyWaitScreen_Load);
            this.screenPnl5.ResumeLayout(false);
            this.screenPnl7.ResumeLayout(false);
            this.screenTopPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private customPnl screenTopPnl;
        private customPnl screenPnlLabel;
        private customPnl screenPnlTime;
        private customPnl screenBottomPnl;
        private customPnl screenPnl5;
        private customPnl screenPnl7;
        private customPnl normalContentArea;
        private customPnl normalContentTitle;
        private customPnl screenPnlRight;
        private System.Windows.Forms.Timer dateTime;
        private System.Windows.Forms.Timer timerRefreshPage;
        private System.Windows.Forms.Timer msgTimer;
    }
}
