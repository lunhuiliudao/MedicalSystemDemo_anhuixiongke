
using MedicalSystem.MedScreen.Controls;
namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    partial class alarmMsgFrm
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
            this.msgAlarmArea = new customPnl();
            this.leftMargin = new customPnl();
            this.rightMargin = new customPnl();
            this.bottomMargin = new customPnl();
            this.SuspendLayout();
            // 
            // msgAlarmArea
            // 
            this.msgAlarmArea.BackgroundImage = global::ClientScreens.Properties.Resources.右方信息屏;
            this.msgAlarmArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.msgAlarmArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgAlarmArea.Location = new System.Drawing.Point(37, 0);
            this.msgAlarmArea.Name = "msgAlarmArea";
            this.msgAlarmArea.Size = new System.Drawing.Size(604, 496);
            this.msgAlarmArea.TabIndex = 4;
            // 
            // leftMargin
            // 
            this.leftMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftMargin.Location = new System.Drawing.Point(0, 0);
            this.leftMargin.Name = "leftMargin";
            this.leftMargin.Size = new System.Drawing.Size(37, 496);
            this.leftMargin.TabIndex = 3;
            // 
            // rightMargin
            // 
            this.rightMargin.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightMargin.Location = new System.Drawing.Point(641, 0);
            this.rightMargin.Name = "rightMargin";
            this.rightMargin.Size = new System.Drawing.Size(10, 496);
            this.rightMargin.TabIndex = 2;
            // 
            // bottomMargin
            // 
            this.bottomMargin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomMargin.Location = new System.Drawing.Point(0, 496);
            this.bottomMargin.Name = "bottomMargin";
            this.bottomMargin.Size = new System.Drawing.Size(651, 10);
            this.bottomMargin.TabIndex = 1;
            // 
            // alarmMsgFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.msgAlarmArea);
            this.Controls.Add(this.leftMargin);
            this.Controls.Add(this.rightMargin);
            this.Controls.Add(this.bottomMargin);
            this.Name = "alarmMsgFrm";
            this.Size = new System.Drawing.Size(651, 506);
            this.Load += new System.EventHandler(this.alarmMsgFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private customPnl rightMargin;
        private customPnl leftMargin;
        private customPnl msgAlarmArea;
        private customPnl bottomMargin;
    }
}
