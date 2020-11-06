using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MedicalSystem.Anes.Document;
using DevExpress.XtraEditors;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false), DisplayName("文本标签"), Description("文本标签控件")]
    public partial class MLabel : Label, IPrintable
    {
        public MLabel()
        {
            base.BackColor = Color.White;
            base.AutoSize = true;
        }
        private float _printXOffSet = 0;
        [DisplayName("打印偏移量(横向)")]
        public float PrintXOffSet
        {
            set
            {
                _printXOffSet = value;
            }
            get
            {
                return _printXOffSet;
            }
        }

        private float _printYOffSet = 0;
        [DisplayName("打印偏移量(纵向)")]
        public float PrintYOffSet
        {
            set
            {
                _printYOffSet = value;
            }
            get
            {
                return _printYOffSet;
            }
        }

        /// <summary>
        /// 是否画虚线边框
        /// </summary>
        private bool _dotBorder = false;

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

        private bool _multiLine = false;
        [Description("多行")]
        public bool MultiLine
        {
            get
            {
                return _multiLine;
            }
            set
            {
                _multiLine = value;
            }
        }

        /// <summary>
        /// 是否画虚线边框
        /// </summary>
        [Description("是否画虚线边框")]
        public bool DotBorder
        {
            get
            {
                return _dotBorder;
            }
            set
            {
                _dotBorder = value;
                Refresh();
            }
        }

        private string _varKey;
        public string VarKey
        {
            get
            {
                return _varKey;
            }
            set
            {
                _varKey = value;
            }
        }

        private MedSymbolType _symbolType = MedSymbolType.None;
        public MedSymbolType SymbolType
        {
            get
            {
                return _symbolType;
            }
            set
            {
                _symbolType = value;
            }
        }

        
        //public System.Drawing.ContentAlignment TextAlign
        //{
        //    get
        //    {
        //        return base.TextAlign;
        //    }
        //    set
        //    {

        //        base.TextAlign = value;
        //    }
        //}

        private bool _bottomLine = false;
        [Description("打印底线"), Category("数据(自定义)")]
        public bool BottomLine
        {
            get
            {
                return _bottomLine;
            }
            set
            {
                _bottomLine = value;
            }
        }


       
       

        public void Draw(Graphics g, float x, float y)
        {
            Draw(g, new RectangleF(x + _printXOffSet, y + _printYOffSet, Width, Height));
            if (_bottomLine)
            {
                using (Pen pen = new Pen(ForeColor))
                {
                    g.DrawLine(pen, x + _printXOffSet, y + Height + _printYOffSet, x + Width + _printXOffSet, y + Height + _printYOffSet);
                }
            }
        }

        public void Draw(Graphics g, RectangleF rectF)
        {
            using (Brush brush = new SolidBrush(ForeColor))
            {
                if (Image != null)
                {
                    g.DrawImage(Image, rectF);
                }
                else if (_symbolType != MedSymbolType.None)
                {
                    MedSymbol symbol = new MedSymbol(_symbolType);
                    symbol.Size = 8;
                    symbol.Pen = new Pen(ForeColor);
                    symbol.Draw(g, rectF.X + symbol.Size / 2, rectF.Y + symbol.Size / 2);
                }
                else if (_multiLine)
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;
                    g.DrawString(Text, Font, brush, rectF, sf);
                }
                else
                {
                    switch (TextAlign)
                    {
                        case ContentAlignment.MiddleCenter:
                            g.DrawString(Text, Font, brush, rectF.X + (rectF.Width - g.MeasureString(Text, Font).Width) / 2, rectF.Y + (rectF.Height - g.MeasureString(Text, Font).Height) / 2);
                            break;
                        default:
                            g.DrawString(Text, Font, brush, rectF.X, rectF.Y);
                            break;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_symbolType != MedSymbolType.None)
            {
                Draw(e.Graphics, 0, 0);
            }
            else
            {
                base.OnPaint(e);
            }
        }

      

      
    }
}
