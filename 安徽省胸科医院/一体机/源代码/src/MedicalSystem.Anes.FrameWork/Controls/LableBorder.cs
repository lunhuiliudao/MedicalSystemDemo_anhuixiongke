using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// Lable边框加粗
    /// </summary>
    public class LableBorder : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(132, 135, 137), 1))
            {
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 3f, 1f };
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
