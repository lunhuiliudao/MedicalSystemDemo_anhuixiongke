using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using MedicalSystem.Anes.Document.Controls;
using System.Drawing.Drawing2D;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false), Description("线")]
    public class MedMyLine : Control, IPrintable
    {
        public enum InnerLineType
        {
            Horizontal,
            Vertical,
        }

        public MedMyLine()
        {
            Paint += new PaintEventHandler(MedMyLine_Paint);
            Padding = new Padding(0, 0, 0, 0);
            Margin = new Padding(0, 0, 0, 0);
        }

        private bool _noPrint = false;
        [Description("不打印")]
        public bool NoPrint
        {
            get
            {
                return _noPrint;
            }
            set
            {
                _noPrint = value;
            }
        }

        private InnerLineType _lineType = InnerLineType.Horizontal;
        public InnerLineType LineType
        {
            get
            {
                return _lineType;
            }
            set
            {
                _lineType = value;
            }
        }

        void MedMyLine_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics, 0, 0);
        }

        private DashStyle _lineStyle = DashStyle.Solid;
        [Description("线条样式")]
        public DashStyle LineStyle
        {
            get
            {
                return _lineStyle;
            }
            set
            {
                _lineStyle = value;
            }
        }

        public void Draw(Graphics g, float x, float y)
        {
            using (Pen pen = new Pen(ForeColor))
            {
                pen.DashStyle = _lineStyle;
                switch (_lineType)
                {

                    case InnerLineType.Horizontal:

                        g.DrawLine(pen, x, y + Height / 2, x + Width, y + Height / 2);
                        break;
                    case InnerLineType.Vertical:
                        g.DrawLine(pen, x + Width / 2, y, x + Width / 2, y + Height);
                        break;
                    default:
                        g.DrawLine(pen, x, y + Height / 2, x + Width, y + Height / 2);
                        break;
                }
            }
            
        }
    }
}
