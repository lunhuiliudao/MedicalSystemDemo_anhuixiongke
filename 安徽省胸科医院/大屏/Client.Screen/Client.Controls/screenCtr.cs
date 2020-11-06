using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Controls
{
    public partial class screenCtr : UserControl
    {
        private int _screenNo = 1;
        public int screenNo
        {
            set
            {
                _screenNo = value;
                this.label1.Text = _screenNo.ToString();
            }
            get
            {
                return _screenNo;
            }
        }
        public event EventHandler ScreenSelectChanged;
        private bool _isSelected = false;
        /// <summary>
        /// 设置是否选中
        /// </summary>
        public bool IsSelected
        {
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    Control ParentControl = this.Parent;
                    SetControlColor(this,Color.Blue);
                    foreach (Control Control1 in Parent.Controls)
                    {
                        if (Control1 != this && !(Control1 is Label))
                        {
                            SetControlColor(Control1, Color.LightBlue);
                        }
                    }
                    if (ScreenSelectChanged != null)
                    {
                        ScreenSelectChanged(this, EventArgs.Empty);
                    }
                }
                else
                {
                    SetControlColor(this, Color.LightBlue);
                }
            }
            get
            {
                return _isSelected;
            }
        }
        public screenCtr()
        {
            InitializeComponent();
        }

        private void SetControlColor(Control ctr,Color c)
        {
            ctr.BackColor = c;
        }

    }
}
