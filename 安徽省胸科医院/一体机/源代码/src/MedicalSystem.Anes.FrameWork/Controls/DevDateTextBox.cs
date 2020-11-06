using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork.Controls
{
    public partial class DevDateTextBox : DevExpress.XtraEditors.DateEdit 
    {

        //键盘上下按的事件
        public delegate void RaiseKeyDownUpEventHandle(object sender, MyKeyEventArgs e);
        //键盘上下按的事件
        public event RaiseKeyDownUpEventHandle RaiseKeyDownUpEvent;


        protected override void WndProc(ref   Message m)
        {

          
            if (m.WParam == (IntPtr)Keys.Up)
            {
  

                if (RaiseKeyDownUpEvent != null)
                {

                    MyKeyEventArgs args = new MyKeyEventArgs();
                    args.key = Keys.Up;
                    RaiseKeyDownUpEvent(this, args);
                }

            }

            else if (m.WParam == (IntPtr)Keys.Down)
            {

                if (RaiseKeyDownUpEvent != null)
                {
                    MyKeyEventArgs args = new MyKeyEventArgs();
                    args.key = Keys.Down;
                    RaiseKeyDownUpEvent(this, args);
                }


            }
            else
            {
                base.WndProc(ref   m);

            }
        } 


    }
}
