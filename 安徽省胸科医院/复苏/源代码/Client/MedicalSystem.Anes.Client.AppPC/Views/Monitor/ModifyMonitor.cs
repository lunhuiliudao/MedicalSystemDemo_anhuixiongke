using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ModifyMonitor : BaseView
    {
        public string _strUseTime = string.Empty;
        public string _strUseCount = string.Empty;
        public bool _isConfirm = false;

        public ModifyMonitor(string monitorName)
        {
            InitializeComponent();

            lblMonitorName.Text = monitorName;
            tbTime.Text = "1";
            tbCount.Text = "9";
            tbTime.Focus();
        }

        private void tbTime_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                tbCount.Focus();
            }
        }

        private void tbCount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                tbTime.Focus();
            }else if(e.KeyCode == Keys.Enter)
            {
                _strUseTime = tbTime.Text;
               _strUseCount = tbCount.Text;
               _isConfirm = true;
               CloseView();
            }
        }

        private void CloseView()
        {
            (this.Parent as Form).Close();
        } 
    }
}
