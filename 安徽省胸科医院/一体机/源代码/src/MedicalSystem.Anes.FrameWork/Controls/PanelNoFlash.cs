using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 无闪烁Panel
    /// </summary>
    public class PanelNoFlash : Panel
    {
        public PanelNoFlash()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        #region 解决界面闪烁情况

        /// <summary>
        /// 解决界面闪烁情况
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                if (!DesignMode)
                {
                    var parms = base.CreateParams;
                    parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                    return parms;
                }
                return base.CreateParams;
            }
        }

        #endregion

        const int WM_ERASEBKGND = 0x14;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_ERASEBKGND)
                base.WndProc(ref m);
        }

    }
}
