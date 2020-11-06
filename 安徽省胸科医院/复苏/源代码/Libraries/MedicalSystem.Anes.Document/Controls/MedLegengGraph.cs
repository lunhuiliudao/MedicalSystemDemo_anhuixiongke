using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Controls
{
    public class MedLegeng
    {
        private string _legengCode;

        public string LegengCode
        {
            get { return _legengCode; }
            set { _legengCode = value; }
        }

        private string _legengName;

        public string LegengName
        {
            get { return _legengName; }
            set { _legengName = value; }
        }

        private MedSymbol _legengSymbol;

        public MedSymbol LegengSymbol
        {
            get { return _legengSymbol; }
            set { _legengSymbol = value; }
        }
    }

    [ToolboxItem(false)]
    public partial class MedLegengGraph : AnesBand, IPrintable
    {
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

        private LegengType _legendType = LegengType.Vertical;
        [DisplayName("图例分布")]
        public LegengType LegendType
        {
            get { return _legendType; }
            set { _legendType = value; }
        }

        private int _startLegendIndex = 0;
        [DisplayName("起始图例索引")]
        public int StartLegendIndex
        {
            get
            {
                return _startLegendIndex;
            }
            set
            {
                _startLegendIndex = value;
            }
        }

        private int _endLegendIndex;
        [Browsable(false)]
        public int EndLegendIndex
        {
            get { return _endLegendIndex; }
            set { _endLegendIndex = value; }
        }

        private Dictionary<string, MedLegeng> _symbolDict = new Dictionary<string, MedLegeng>();

        public Dictionary<string, MedLegeng> SymbolDict
        {
            get { return _symbolDict; }
            set { _symbolDict = value; }
        }

        /// <summary>
        /// 对应麻醉单之体征曲线
        /// </summary>
        private MedVitalSignGraph _vitalSign = null;
        [Browsable(false)]
        public MedVitalSignGraph VitalSign
        {
            set
            {
                _vitalSign = value;
            }
        }

        #region 事件接口

        /// <summary>
        /// 客户绘制事件 
        /// </summary>
        private static readonly object _customDraw = new object();
        public event PaintEventHandler CustomDraw
        {
            add
            {
                Events.AddHandler(_customDraw, value);
            }
            remove
            {
                Events.RemoveHandler(_customDraw, value);
            }
        }

        #endregion 事件接口

        public MedLegengGraph()
        {
            InitializeComponent();
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

        public void ReCalLastIndex(Dictionary<string, MedLegeng> symbolDict)
        {
            using (Graphics g = this.CreateGraphics())
            {
                List<string> aliass = new List<string>();
                RectangleF rectF = new RectangleF(OriginRect.X + 6, OriginRect.Y + 2, OriginRect.Width - 4, OriginRect.Height - 4);
                int index = 0;
                int idx = 0;
                if (_legendType == LegengType.Vertical)
                {
                    //float offX = 5;
                    float rowHeight = g.MeasureString("平均动脉压", Font).Height;
                    foreach (string str in symbolDict.Keys)
                    {
                        idx++;
                        if (string.IsNullOrEmpty(str) || aliass.Contains(str)) continue;

                        if ((idx - 1) >= _startLegendIndex)
                        {
                            if (rectF.Y + 1 + (index + 1) * rowHeight > rectF.Bottom) break;
                            aliass.Add(str);
                            index++;
                        }

                    }
                }
                else if (_legendType == LegengType.Horizontal)
                {
                    //float rowHeight = g.MeasureString("平均动脉压", Font).Height + 2;
                    float rowHeight = g.MeasureString("平均动脉压", Font).Height;
                    MedSymbol symbol = null;
                    float symbolPosX = 0, symbolStringPosY = 0, symbolPosY;
                    float offX = 5;
                    float rowSplitWidth = 10; //行项与项之间距
                    symbolPosX = rectF.X + offX;
                    // symbolPosY = rectF.Y + (rowHeight) / 2;
                    symbolPosY = rectF.Y + this.Height / 2;
                    symbolStringPosY = rectF.Y + this.Height / 2 - rowHeight / 2;

                    foreach (string str in symbolDict.Keys)
                    {
                        idx++;
                        if (string.IsNullOrEmpty(str) || aliass.Contains(str)) continue;

                        float rowWidth = g.MeasureString(str, Font).Width + 4f;

                        if ((idx - 1) >= _startLegendIndex)
                        {
                            symbol = symbolDict[str].LegengSymbol;
                            if ((symbolPosX + symbol.Size + offX + g.MeasureString(str, Font).Width + rowSplitWidth + offX) > rectF.Right) break;
                            aliass.Add(str);
                            symbolPosY = rectF.Y + (this.Height - symbol.Size) / 2;
                            symbolPosX += symbol.Size + offX; //加上偏移
                            symbolPosX += g.MeasureString(symbolDict[str].LegengName, Font).Width + rowSplitWidth + offX;
                            index++;
                        }
                    }
                }
                _endLegendIndex = idx == 0 ? 0 : (idx - 1);
            }
        }

        public override void DrawGraphics(Graphics g)
        {
            base.DrawGraphics(g);
            using (SolidBrush solidBrush = new SolidBrush(Color.White))
            {
                g.FillRectangle(solidBrush, OriginRect);
            }
            RectangleF rectF = new RectangleF(OriginRect.X + 2, OriginRect.Y + 2, OriginRect.Width - 4, OriginRect.Height - 4);
            if (_vitalSign != null && _legendType == LegengType.Vertical)
            {
                _vitalSign.DrawLegend(g, rectF);
            }
            else
            {
                List<string> aliass = new List<string>();
                int index = 0;
                int idx = 0;
                if (_legendType == LegengType.Vertical)
                {
                    float offX = 5;
                    float rowHeight = g.MeasureString("平均动脉压", Font).Height;
                    foreach (string str in _symbolDict.Keys)
                    {
                        idx++;
                        if (string.IsNullOrEmpty(str) || aliass.Contains(str)) continue;

                        if ((idx - 1) >= _startLegendIndex)
                        {
                            if (rectF.Y + 1 + (index + 1) * rowHeight > rectF.Bottom) break;
                            aliass.Add(str);
                            _symbolDict[str].LegengSymbol.Draw(g, rectF.X + offX, rectF.Y + (rowHeight) / 2 + index * rowHeight);
                            using (SolidBrush solidBrush = new SolidBrush(_symbolDict[str].LegengSymbol.Pen.Color))
                            {
                                g.DrawString(_symbolDict[str].LegengName, Font, solidBrush, rectF.X + 3 + _symbolDict[str].LegengSymbol.Size, rectF.Y + 1 + index * rowHeight);
                            }
                            index++;
                        }

                    }
                }
                else if (_legendType == LegengType.Horizontal)
                {
                    //float rowHeight = g.MeasureString("平均动脉压", Font).Height + 2;
                    float rowHeight = g.MeasureString("平均动脉压", Font).Height;
                    MedSymbol symbol = null;
                    float symbolPosX = 0, symbolStringPosY = 0, symbolPosY;
                    float offX = 5;
                    float rowSplitWidth = 10; //行项与项之间距
                    symbolPosX = rectF.X + offX;
                    //symbolPosY = rectF.Y + (rowHeight) / 2;
                    symbolPosY = rectF.Y + this.Height / 2;
                    symbolStringPosY = rectF.Y + this.Height / 2 - rowHeight / 2;

                    foreach (string str in _symbolDict.Keys)
                    {
                        idx++;
                        if (string.IsNullOrEmpty(str) || aliass.Contains(str)) continue;

                        float rowWidth = g.MeasureString(str, Font).Width + 4f;

                        if ((idx - 1) >= _startLegendIndex)
                        {
                            symbol = _symbolDict[str].LegengSymbol;
                            if ((symbolPosX + symbol.Size + offX + g.MeasureString(str, Font).Width + rowSplitWidth + offX) > rectF.Right) break;
                            symbolPosY = rectF.Y + (this.Height - symbol.Size) / 2;
                            aliass.Add(str);
                            symbol.Draw(g, symbolPosX, symbolPosY);
                            symbolPosX += symbol.Size + offX; //加上偏移
                            using (SolidBrush solidBrush3 = new SolidBrush(symbol.Pen.Color))
                            {
                                g.DrawString(_symbolDict[str].LegengName, Font, solidBrush3, symbolPosX, symbolStringPosY);
                            }
                            symbolPosX += g.MeasureString(_symbolDict[str].LegengName, Font).Width + rowSplitWidth + offX;
                            index++;
                        }
                    }
                }
                _endLegendIndex = idx == 0 ? 0 : (idx - 1);
            }
            PaintEventHandler eventHandle = Events[_customDraw] as PaintEventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, new PaintEventArgs(g, ClientRectangle));
            }
        }




    }
}
