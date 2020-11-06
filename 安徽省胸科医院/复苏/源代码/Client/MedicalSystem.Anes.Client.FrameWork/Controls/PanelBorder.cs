using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// Panel边框加粗
    /// </summary>
    public class PanelBorder : Panel
    {
        public PanelBorder()
        {
            BorderColor = Color.FromArgb(132, 135, 137);
            DashPattern = new float[] { 3f, 1f };
        }

        [DefaultValue(typeof(Color), "132, 135, 137")]
        public Color BorderColor { get; set; }

        [DefaultValue(new float[] { 3f, 1f })]
        public float[] DashPattern { get; set; }

        [DefaultValue(DashStyle.Custom)]
        public DashStyle DashStyle { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(BorderColor, 1))
            {
                pen.DashStyle = this.DashStyle;
                pen.DashPattern = this.DashPattern;
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
