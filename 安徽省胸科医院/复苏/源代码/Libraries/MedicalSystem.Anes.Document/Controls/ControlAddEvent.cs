using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Controls
{
    public class ControlAddEvent
    {
        Control control = null;
        Image One = null;
        Image Two = null;
        Image Three = null;


        private bool showLeave = true;

        public bool ShowLeave
        {
            get { return showLeave; }
            set { showLeave = value; }
        }

        public ControlAddEvent(Image one, Image two, Image three)
        {
            One = one;
            Two = two;
            Three = three;
        }

        public void AddMouseMove(Control ctl)
        {
            control = ctl;

            control.MouseEnter += ctl_MouseEnter;
            control.MouseLeave += ctl_MouseLeave;
            control.MouseDown += ctl_MouseDown;
        }

        void ctl_MouseDown(object sender, MouseEventArgs e)
        {
            if (control is PictureBox)
                ((PictureBox)control).Image = Three;
            else if (control is Label)
                ((Label)control).Image = Three;
            else
                control.BackgroundImage = Three;
        }

        void ctl_MouseLeave(object sender, EventArgs e)
        {
            if (showLeave)
            {
                if (control is PictureBox)
                    ((PictureBox)control).Image = One;
                else if (control is Label)
                    ((Label)control).Image = One;
                else
                    control.BackgroundImage = One;
            }
        }

        void ctl_MouseEnter(object sender, EventArgs e)
        {
            if (showLeave)
            {
                if (control is PictureBox)
                    ((PictureBox)control).Image = Two;
                else if (control is Label)
                    ((Label)control).Image = Two;
                else
                    control.BackgroundImage = Two;
            }
        }
    }
}
