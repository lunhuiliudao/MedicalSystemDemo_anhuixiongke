namespace MedicalSystem.Anes.Document.Controls
{
    partial class MedGraph
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
            if (disposing && (_mainPanel != null))
            {
                _mainPanel.Dispose();

            }
            if (disposing && (_cursorPosPen != null))
            {
                _cursorPosPen.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedGraph));
            this.SuspendLayout();
            // 
            // MedGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MedGraph";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MedGraph_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
