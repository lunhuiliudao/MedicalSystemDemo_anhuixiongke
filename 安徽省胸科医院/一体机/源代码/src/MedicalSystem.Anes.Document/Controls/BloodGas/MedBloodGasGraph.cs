using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false), Description("血气分析")]
    public partial class MedBloodGasGraph : AnesBand, IPrintable
    {
        private List<MedBloodGasItem> itemList = new List<MedBloodGasItem>();
        [Category("数据-自定义"), DisplayName("血气分析项目")]
        public List<MedBloodGasItem> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        private List<MedBloodGasRecord> bloodGasRecords = new List<MedBloodGasRecord>();
        [Category("数据-自定义"), DisplayName("自定义血气记录")]
        public List<MedBloodGasRecord> BloodGasRecords
        {
            get { return bloodGasRecords; }
            set { bloodGasRecords = value; }
        }

        private List<BloodGasMaster> bloodGasItems = new List<BloodGasMaster>();
        [Browsable(false)]
        public List<BloodGasMaster> BloodGasItems
        {
            get
            {
                return bloodGasItems;
            }

            set
            {
                bloodGasItems = value;
            }
        }

        private string title = "血气";
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

        private int headerHeight;
        [Category("数据-自定义"), DisplayName("项目名称单位栏高度")]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set { headerHeight = value; }
        }

        private bool isShowAll;
        [Category("数据-自定义"), DisplayName("显示所有记录")]
        public bool IsShowAll
        {
            get { return isShowAll; }
            set
            {
                if (isShowAll != value)
                {
                    isShowAll = value;
                    Invalidate();
                }

            }
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


        public MedBloodGasGraph()
        {
            InitializeComponent();
            isShowAll = false;
            MedBloodGasRecord bgr = new MedBloodGasRecord();
            bgr.RecordName = "转前血气";
            bgr.ShowText = "转前血气";
            bloodGasRecords.Add(bgr);
            bgr = new MedBloodGasRecord();
            bgr.RecordName = "转中血气1";
            bgr.ShowText = "转中血气";
            bloodGasRecords.Add(bgr);
            bgr = new MedBloodGasRecord();
            bgr.RecordName = "转中血气2";
            bgr.ShowText = "";
            bloodGasRecords.Add(bgr);
            bgr = new MedBloodGasRecord();
            bgr.RecordName = "转后血气";
            bgr.ShowText = "转后血气";
            bloodGasRecords.Add(bgr);
            headerHeight = 30;

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
            DrawBloodGas(g, rect);

        }

        private void DrawBloodGas(Graphics g, Rectangle rect)
        {
            using (Font newfont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold))
            {
                using (SolidBrush sbrush = new SolidBrush(ForeColor))
                {
                    g.DrawString(title, titleFont, sbrush, (float)rect.X, (float)rect.Y);
                    float y = (float)rect.Y + (float)headerHeight;

                    SizeF timesz = g.MeasureString("2010-12-29 23:59", Font);

                    SizeF recorddNamesz = g.MeasureString("转前血气", newfont);
                    foreach (MedBloodGasRecord blg in bloodGasRecords)
                    {
                        SizeF sftmp = g.MeasureString(blg.ShowText, newfont);
                        if (sftmp.Width > recorddNamesz.Width)
                        {
                            recorddNamesz = sftmp;
                        }
                    }

                    SizeF itemNamesz = g.MeasureString("mmol/L", Font);
                    if (itemList.Count > 0)
                    {
                        itemNamesz.Width = ((float)rect.Width - recorddNamesz.Width - timesz.Width - 6f) / itemList.Count - 4f;
                    }

                    g.DrawString("时间点", Font, sbrush, (float)rect.X + recorddNamesz.Width + 2f, (float)rect.Y);

                    float itemX = recorddNamesz.Width + timesz.Width + 6f;
                    foreach (MedBloodGasItem item in itemList)
                    {
                        g.DrawString(item.ItemName, Font, sbrush, itemX, (float)rect.Y);
                        g.DrawString(item.ItemUnit, Font, sbrush, itemX, (float)rect.Y + itemNamesz.Height);
                        itemX += itemNamesz.Width + 4f;
                    }
                    if (isShowAll)
                    {
                        foreach (BloodGasMaster master in bloodGasItems)
                        {
                            if (master.Recorddate != null && !master.Recorddate.Equals(DateTime.MinValue))
                            {
                                g.DrawString(master.Recorddate.ToString("yyyy-MM-dd HH:mm"), Font, sbrush, (float)rect.X + recorddNamesz.Width + 2f, y);
                            }
                            Dictionary<string, string> dict = new Dictionary<string, string>();
                            foreach (BloodGasDetail detail in master.Details)
                            {
                                dict.Add(detail.BloodGasCode, detail.BloodGasValue);
                            }
                            float valueX = (float)rect.X + recorddNamesz.Width + timesz.Width + 6f;
                            foreach (MedBloodGasItem item in itemList)
                            {
                                if (dict.ContainsKey(item.ItemCode) && dict[item.ItemCode] != null)
                                {
                                    g.DrawString(dict[item.ItemCode], Font, sbrush, valueX, y);
                                }
                                valueX += itemNamesz.Width + 4f;
                            }
                            y += recorddNamesz.Height + 2f;
                        }
                    }
                    else
                    {
                        foreach (MedBloodGasRecord record in bloodGasRecords)
                        {
                            g.DrawString(record.ShowText, newfont, sbrush, (float)rect.X, y);
                            if (record.TimePoint != null && !record.TimePoint.Equals(DateTime.MinValue))
                            {
                                g.DrawString(record.TimePoint.ToString("yyyy-MM-dd HH:mm"), Font, sbrush, (float)rect.X + recorddNamesz.Width + 2f, y);
                            }
                            foreach (BloodGasMaster master in bloodGasItems)
                            {
                                if (master.DetailId.Equals(record.DetailId))
                                {
                                    Dictionary<string, string> dict = new Dictionary<string, string>();
                                    foreach (BloodGasDetail detail in master.Details)
                                    {
                                        dict.Add(detail.BloodGasCode, detail.BloodGasValue);
                                    }
                                    float valueX = (float)rect.X + recorddNamesz.Width + timesz.Width + 6f;
                                    foreach (MedBloodGasItem item in itemList)
                                    {
                                        if (dict.ContainsKey(item.ItemCode) && dict[item.ItemCode] != null)
                                        {
                                            g.DrawString(dict[item.ItemCode], Font, sbrush, valueX, y);
                                        }
                                        valueX += itemNamesz.Width + 4f;
                                    }
                                }
                            }
                            y += recorddNamesz.Height + 2f;
                        }
                    }
                    Height = Convert.ToInt32(y) - rect.Y;
                }
            }
        }
    }
}
