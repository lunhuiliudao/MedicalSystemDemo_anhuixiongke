using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// 日期时间控件
    /// </summary>
    public class DateTextBox : DateTimePicker
    {
        //HorizontalAlignment textAlign = HorizontalAlignment.Center;
        public DateTextBox()
        {
            CustomFormat = "yyyy-MM-dd HH:mm";
            Format = DateTimePickerFormat.Custom;
            ShowUpDown = true;
            AutoTurnRight = false;

            

        }



        /// <summary>
        /// 自动调整到下一个设置上。
        /// </summary>
        [Category("Appearance")]
        [Description("自动调整到下一个设置上。")]
        [DefaultValue(true)]
        public bool AutoTurnRight { get; set; }

        private bool updownKey = false;



        DateTime dtTemp = DateTime.MinValue;


        protected override void OnKeyDown(KeyEventArgs e)
        {
            updownKey = e.KeyCode == Keys.Up || e.KeyCode == Keys.Down;
            base.OnKeyDown(e);
            dtTemp = this.Value;

        }

  
        protected override void OnValueChanged(EventArgs eventargs)
        {
            if (!updownKey && AutoTurnRight)
            {

                TimeSpan diff =dtTemp - this.Value ;
                if (diff.TotalMinutes < 60 && diff.TotalMinutes > -60)
                {  
                
                }
                else
                {

      
                    SendKeys.Send("{right}"); 
                
                
                }
             

               
            }
            base.OnValueChanged(eventargs);
        }


        ////键盘上下按的事件
        //public delegate void RaiseKeyDownUpEventHandle(object sender, MyKeyEventArgs e);
        ////键盘上下按的事件
        //public event RaiseKeyDownUpEventHandle RaiseKeyDownUpEvent;


        //protected override void WndProc(ref   Message m)
        //{
          

        //    if (m.WParam == (IntPtr)Keys.Up)
        //    {

        //        if (RaiseKeyDownUpEvent != null)
        //        {

        //            MyKeyEventArgs args = new MyKeyEventArgs();
        //            args.key = Keys.Up;
        //            RaiseKeyDownUpEvent(this, args);
        //        }
        
        //    }

        //    else if (m.WParam == (IntPtr)Keys.Down)
        //    {

        //        if (RaiseKeyDownUpEvent != null)
        //        {
        //            MyKeyEventArgs args = new MyKeyEventArgs();
        //            args.key = Keys.Down;
        //            RaiseKeyDownUpEvent(this, args);
        //        }


        //    }
        //    else
        //    {
        //        base.WndProc(ref   m);
            
        //    }
        //}

      



    }

}
