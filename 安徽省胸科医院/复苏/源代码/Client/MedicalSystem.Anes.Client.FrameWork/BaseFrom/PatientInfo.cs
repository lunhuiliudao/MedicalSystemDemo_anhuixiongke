using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// 判断是否是一个窗口
    /// </summary>
    public class PatientInfo : Panel
    {
        public PatientInfo()
        {
            InitializeComponent();
        }

        private Label label1;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // PatientInfo
            // 
            this.BackgroundImage = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.PatientInfo;
            this.MaximumSize = new System.Drawing.Size(298, 96);
            this.MinimumSize = new System.Drawing.Size(298, 96);
            this.Size = new System.Drawing.Size(298, 96);
            this.ResumeLayout(false);

        }
    }
}
