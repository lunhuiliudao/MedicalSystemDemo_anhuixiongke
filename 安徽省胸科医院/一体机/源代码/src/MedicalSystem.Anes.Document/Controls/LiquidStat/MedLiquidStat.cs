using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 液体统计统计控件
    /// </summary>
    [ToolboxItem(false), Description("液体统计")]
    public partial class MedLiquidStat : AnesBand,IPrintable
    {
        private string title = "液体(ml)";
        [Category("数据-自定义"), DisplayName("控件标题")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private Font titleFont = DefaultFont;
        [Category("数据-自定义"), DisplayName("标题字体")]
        public Font TitleFont
        {
            get { return titleFont; }
            set { titleFont = value; }
        }

        private List<MedLiquidItem> liquidItems = new List<MedLiquidItem>();
        [Category("数据-自定义"), DisplayName("液体汇总项目集合")]
        public List<MedLiquidItem> LiquidItems
        {
            get { return liquidItems; }
            set { liquidItems = value; }
        }

        private int headerHeight;
        [Category("数据-自定义"), DisplayName("标题栏高度")]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set { headerHeight = value; }
        }

        private int itemNameWith;
        [Category("数据-自定义"), DisplayName("汇总项目名宽度")]
        public int ItemNameWith
        {
            get { return itemNameWith; }
            set { itemNameWith = value; }
        }

        private bool isAddLine = false;
        [Category("数据-自定义"), DisplayName("是否换行"),Description("当液体项目超出一行的范围时，是否换行继续全部显示，false只显示一行,true换行全部显示")]
        public bool IsAddLine
        {
            get { return isAddLine; }
            set { isAddLine = value; }
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

        public MedLiquidStat()
        {
            InitializeComponent();
            MedLiquidItem item=new MedLiquidItem();
            item.ItemName="预充";
            liquidItems.Add(item);
            item=new MedLiquidItem();
            item.ItemName="转中";
            liquidItems.Add(item);
            headerHeight = 15;
            itemNameWith = 30;
        }

        public void Draw(Graphics g, float x, float y)
        {
            _printing = true;
            g.TranslateTransform(x, y);
            int backHeight = Height;
            if (_backHeight > 0)
            {
                Height = _backHeight;
            }
            DrawGraphics(g);
            Height = backHeight;
            g.ResetTransform();
            _printing = false;
        }

        public override void DrawGraphics(Graphics g)
        {
            base.DrawGraphics(g);
            Rectangle rect = new Rectangle(ClientRectangle.X + 2, ClientRectangle.Y + 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4);
            DrawLiquidStat(g, rect);
        }

        private void DrawLiquidStat(Graphics g, Rectangle rect)
        {
            using (Font newfont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold))
            {
                using (SolidBrush sdrush = new SolidBrush(ForeColor))
                {
                    g.DrawString(title, titleFont, sdrush, (float)rect.X, (float)rect.Y);
                    string statString = "";
                    int totalVolume = 0;
                    float y = (float)rect.Y + (float)headerHeight;
                    foreach (MedLiquidItem item in liquidItems)
                    {
                        float x = (float)rect.X;
                        g.DrawString(item.ItemName, newfont, sdrush, x, y);
                        statString = statString + item.ItemName + "总量：";
                        x += (float)itemNameWith;
                        float xl = x;
                        int totalItemVolume = 0;
                        SizeF detailNameSize = new SizeF();
                        detailNameSize = g.MeasureString("转中液体", Font);
                        foreach (MedLiquidDetail detail in item.LiquidItemDetails)
                        {
                            detailNameSize = g.MeasureString(detail.LiquidName, Font);
                            bool b = true;
                            if ((x + detailNameSize.Width + 4f > (float)rect.Right))
                            {
                                b = false;
                                if (isAddLine)
                                {
                                    y += 2 * (detailNameSize.Height + 2f);
                                    x = xl;
                                    b = true;
                                }
                            }
                            if (b)
                            {
                                g.DrawString(detail.LiquidName, Font, sdrush, x, y);
                                g.DrawString(detail.LiquidValue.ToString(), Font, sdrush, x, y + detailNameSize.Height + 2f);
                                x += detailNameSize.Width + 4f;
                            }
                            totalItemVolume += detail.LiquidValue;
                        }
                        y += 2 * (detailNameSize.Height + 2f);
                        if (isAddLine)
                        {
                            Height = Convert.ToInt32(y + detailNameSize.Height + 2f);
                        }
                        totalVolume += totalItemVolume;
                        statString = statString + totalItemVolume.ToString() + "   ";
                    }
                    statString = statString + "共计：" + totalVolume.ToString();
                    g.MeasureString(statString, Font);
                    g.DrawString(statString, Font, sdrush, (float)rect.Right - g.MeasureString(statString, Font).Width, y);
                }
            }
        }
    }
}
