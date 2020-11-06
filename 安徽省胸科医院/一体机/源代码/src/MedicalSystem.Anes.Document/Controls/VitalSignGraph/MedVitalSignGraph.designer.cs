namespace MedicalSystem.Anes.Document.Controls
{
    partial class MedVitalSignGraph
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
            if (disposing && (_bloodGasFont != null))
            {
                _bloodGasFont.Dispose();
            }
            if (disposing && (_breathDigitsFont != null))
            {
                _breathDigitsFont.Dispose();
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
            this.picCursor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCursor)).BeginInit();
            this.SuspendLayout();
            // 
            // picCursor
            // 
            this.picCursor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCursor.Enabled = false;
            this.picCursor.Location = new System.Drawing.Point(12, 162);
            this.picCursor.Name = "picCursor";
            this.picCursor.Size = new System.Drawing.Size(135, 49);
            this.picCursor.TabIndex = 0;
            this.picCursor.TabStop = false;
            this.picCursor.Visible = false;
            // 
            // MedVitalSignGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picCursor);
            this.Name = "MedVitalSignGraph";
            this.Size = new System.Drawing.Size(150, 517);
            this.TopOffSet = 15.5F;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MedVitalSignGraph_MouseMove);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MedVitalSignGraph_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MedVitalSignGraph_MouseDown);
            this.Resize += new System.EventHandler(this.MedVitalSignGraph_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MedVitalSignGraph_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCursor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picCursor;
    }
}
