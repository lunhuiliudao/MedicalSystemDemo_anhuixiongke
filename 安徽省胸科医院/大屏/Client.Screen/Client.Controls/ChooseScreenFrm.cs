using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Controls
{
    public partial class ChooseScreenFrm : Form
    {
        public screenCtr SelectedScreen;
        public int SelectedIndex = 0;

        public ChooseScreenFrm()
        {
            InitializeComponent();
        }

        private void ChooseScreenFrm_Load(object sender, EventArgs e)
        {
            int screenCnt = System.Windows.Forms.Screen.AllScreens.Length;
            int left = 0;
            for(int i = 0;i < screenCnt;i++)
            {
                screenCtr ctr = new screenCtr();
                ctr.screenNo = i + 1;
                ctr.ScreenSelectChanged += ctr_ScreenSelectChanged;
                ctr.Click += ctr_Click;
                ctr.Left = left + 50;
                
                ctr.Top = 50;
                left += ctr.Width;
                int w = ctr.Width;
                this.Controls.Add(ctr);
            }
        }

        void ctr_Click(object sender, EventArgs e)
        {
            if (sender is screenCtr)
            {
                SelectedScreen = sender as screenCtr;
                SelectedScreen.IsSelected = true;
            }
        }

        void ctr_ScreenSelectChanged(object sender, EventArgs e)
        {
            if (sender is screenCtr)
            {
                SelectedScreen = sender as screenCtr;
                if (SelectedScreen.IsSelected)
                {
                    label1.Text = "当前选中屏幕--" + SelectedScreen.screenNo.ToString();
                    SelectedIndex = SelectedScreen.screenNo - 1;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
