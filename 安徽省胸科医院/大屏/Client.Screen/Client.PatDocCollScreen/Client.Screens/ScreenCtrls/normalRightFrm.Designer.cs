using MedicalSystem.MedScreen.Controls;
namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    partial class normalRightFrm
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
            this.leftMargin = new customPnl();
            this.rightMargin = new customPnl();
            this.bottomMargin = new customPnl();
            this.normalPicturePnl = new customPnl();
            this.SuspendLayout();
            // 
            // leftMargin
            // 
            this.leftMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftMargin.Location = new System.Drawing.Point(0, 0);
            this.leftMargin.Name = "leftMargin";
            this.leftMargin.Size = new System.Drawing.Size(37, 487);
            this.leftMargin.TabIndex = 6;
            // 
            // rightMargin
            // 
            this.rightMargin.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightMargin.Location = new System.Drawing.Point(675, 0);
            this.rightMargin.Name = "rightMargin";
            this.rightMargin.Size = new System.Drawing.Size(10, 487);
            this.rightMargin.TabIndex = 5;
            // 
            // bottomMargin
            // 
            this.bottomMargin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomMargin.Location = new System.Drawing.Point(0, 487);
            this.bottomMargin.Name = "bottomMargin";
            this.bottomMargin.Size = new System.Drawing.Size(685, 10);
            this.bottomMargin.TabIndex = 4;
            // 
            // normalPicturePnl
            // 
            this.normalPicturePnl.BackgroundImage = global::ClientScreens.Properties.Resources.右方信息屏有图;
            this.normalPicturePnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.normalPicturePnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalPicturePnl.Location = new System.Drawing.Point(37, 0);
            this.normalPicturePnl.Name = "normalPicturePnl";
            this.normalPicturePnl.Size = new System.Drawing.Size(638, 487);
            this.normalPicturePnl.TabIndex = 7;
            // 
            // normalRightFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.normalPicturePnl);
            this.Controls.Add(this.leftMargin);
            this.Controls.Add(this.rightMargin);
            this.Controls.Add(this.bottomMargin);
            this.Name = "normalRightFrm";
            this.Size = new System.Drawing.Size(685, 497);
            this.ResumeLayout(false);

        }

        #endregion

        private customPnl leftMargin;
        private customPnl rightMargin;
        private customPnl bottomMargin;
        private customPnl normalPicturePnl;
    }
}
