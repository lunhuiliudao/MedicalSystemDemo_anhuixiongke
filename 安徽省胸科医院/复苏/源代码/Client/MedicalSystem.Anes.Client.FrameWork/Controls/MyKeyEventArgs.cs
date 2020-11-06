using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
   public class MyKeyEventArgs : EventArgs
    {
       public Keys key = Keys.None ;
       public string memo = "";
    }
}
