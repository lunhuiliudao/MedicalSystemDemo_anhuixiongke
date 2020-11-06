using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using DevExpress.XtraEditors;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(true), DisplayName("�ı���ǩ"), Description("�ı���ǩ�ؼ�")]
    public partial class MedLabel : LabelControl
    {
        private float _printXOffSet = 0;
        [DisplayName("��ӡƫ����(����)")]
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
        [DisplayName("��ӡƫ����(����)")]
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
        /// �Ƿ����߱߿�
        /// </summary>
        private bool _dotBorder = false;

        private bool _noPrint = false;
        [Description("����ӡ")]
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
        [Description("����")]
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
        /// �Ƿ����߱߿�
        /// </summary>
        [Description("�Ƿ����߱߿�")]
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

        private System.Drawing.ContentAlignment _textAlign = ContentAlignment.MiddleLeft;
        public System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return _textAlign;
            }
            set
            {
                _textAlign = value;
                switch (_textAlign)
                {
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.TopLeft:
                        Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        break;
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.TopCenter:
                        Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.TopRight:
                    case ContentAlignment.BottomRight:
                        Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        break;
                    default:
                        Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                        break;
                }
            }
        }

        private bool _bottomLine = false;
        [Description("��ӡ����"), Category("����(�Զ���)")]
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


        private Image _image = null;
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
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
