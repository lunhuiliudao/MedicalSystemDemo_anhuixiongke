﻿namespace MedicalSystem.Anes.Document.Controls
{
    partial class MedDrugGraph
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
            if (disposing && (_legengFont != null))
            {
                _legengFont.Dispose();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // MedDrugGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MedDrugGraph";
            this.Size = new System.Drawing.Size(804, 405);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MedDrugGraph_MouseMove);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MedDrugGraph_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MedDrugGraph_MouseDown);
            this.Resize += new System.EventHandler(this.MedDrugCurve_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MedDrugGraph_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
    }
}
