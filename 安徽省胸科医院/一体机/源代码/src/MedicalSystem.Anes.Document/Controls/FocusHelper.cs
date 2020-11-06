using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 焦点接口
    /// </summary>
    public interface IFocusNext
    {
        /// <summary>
        /// 焦点操作
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="upOrDown"></param>
        /// <returns></returns>
        bool FocusNext(Control ctrl, bool upOrDown);
    }

    /// <summary>
    /// 焦点帮助
    /// </summary>
    public static class FocusHelper
    {
        public static bool FocusNext(this Control ctrl, bool upOrDown)
        {
            var focus = GetParentFocus(ctrl);
            if (focus != null)
            {
                return focus.FocusNext(ctrl, upOrDown);
            }
            else
            {
                return false;
            }
        }

        public static IFocusNext GetParentFocus(this Control ctrl)
        {
            if (ctrl == null)
            {
                return null;
            }
            else if (ctrl is IFocusNext)
            {
                return ctrl as IFocusNext;
            }
            else
            {
                return GetParentFocus(ctrl.Parent);
            }  
        }
    }
}
