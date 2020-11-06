using MedicalSystem.Anes.Document.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 基类用户控件，热键设置等。
    /// </summary>
    public partial class BaseFocusControl :BaseControl, IFocusNext
    {

        /// <summary>
        /// 获取底层通知的事件
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="upOrDown"></param>
        /// <returns></returns>
        public virtual bool FocusNext(Control ctrl, bool upOrDown)
        {
            return false;
        }

    }
}
