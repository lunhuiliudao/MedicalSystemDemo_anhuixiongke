using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.FrameWork;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class LeaveOperTo : UserControl
    {
        public OperationStatus thisStatus;
        public LeaveOperTo()
        {
            InitializeComponent();
            if (ApplicationConfiguration.IsPACUProgram)
            {
                pictureBoxOper.Visible = false;
                labelPacu.Visible = false;
            }
        }

        private void pictureBoxAnes_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxAnes.Image = Resources.病房_button2;
        }

        private void pictureBoxAnes_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAnes.Image = Resources.病房_button1;
        }

        private void pictureBoxAnes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             thisStatus = OperationStatus.TurnToSickRoom;
             (this.Parent as Form).Close();
        }

        private void pictureBoxOper_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxOper.Image = Resources.复苏室_button2;
        }

        private void pictureBoxOper_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxOper.Image = Resources.复苏室_button1;
        }

        private void pictureBoxOper_MouseDoubleClick(object sender, MouseEventArgs e)
        {  
             thisStatus = OperationStatus.TurnToPACU;
             (this.Parent as Form).Close();
        }

        private void pictureBoxOut_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxOut.Image = Resources.icu_button2;
        }

        private void pictureBoxOut_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxOut.Image = Resources.icu_button1;
        }

        private void pictureBoxOut_MouseDoubleClick(object sender, MouseEventArgs e)
        { 
              thisStatus = OperationStatus.TurnToICU;
              (this.Parent as Form).Close();
        }
    }
}
