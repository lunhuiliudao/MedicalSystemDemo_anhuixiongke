/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：AnesGraph.cs
      // 文件功能描述：麻醉基本图表控件（基类）
      //
      // 
      // 创建标识：戴呈祥-2008-10-29
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 刻度类型
    /// </summary>
    [Serializable]
    public enum ScaleType
    {
        /// <summary>
        /// 一分钟
        /// </summary>
        OneMin,
        /// <summary>
        /// 两分钟
        /// </summary>
        TwoMin,
        /// <summary>
        /// 五分钟
        /// </summary>
        FiveMin,
        /// <summary>
        /// 十分钟
        /// </summary>
        TenMin,
        /// <summary>
        /// 刻钟
        /// </summary>
        Quarter,
        /// <summary>
        /// 半小时
        /// </summary>
        HalfHour,
        /// <summary>
        /// 三刻钟
        /// </summary>
        TriQuarter,
        /// <summary>
        /// 小时
        /// </summary>
        Hour,
        /// <summary>
        /// 两小时
        /// </summary>
        TwiHour
    }

    /// <summary>
    /// 时间坐标轴位置类型
    /// </summary>
    [Serializable]
    public enum TimeAxisPositionType
    {
        /// <summary>
        /// 顶端
        /// </summary>
        [Description("顶端")]
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        [Description("底部")]
        Bottom,
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None
    }

    /// <summary>
    /// 麻醉基本图表控件（基类）
    /// </summary>
    [Serializable, ToolboxItem(false)]
    public partial class AnesGraph : AnesBand
    {
        #region 构造方法

        public AnesGraph()
        {
            InitializeComponent();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 左边百分比
        /// </summary>
        protected float _leftWidthPercent = .12f;

        /// <summary>
        /// 右边百分比
        /// </summary>
        protected float _rightWidthPercent = .1f;

        /// <summary>
        /// 开始时间
        /// </summary>
        protected DateTime _startTime = DateTime.Parse("08:00");

        /// <summary>
        /// 结束时间
        /// </summary>
        protected DateTime _endTime = DateTime.Parse("12:00");

        /// <summary>
        /// 刻度类型
        /// </summary>
        protected ScaleType _scaleType = ScaleType.HalfHour;

        /// <summary>
        /// 时间坐标轴位置类型
        /// </summary>
        protected TimeAxisPositionType _timeAxisPositionType = TimeAxisPositionType.Top;

        /// <summary>
        /// 顶部偏移量
        /// </summary>
        protected float _topOffSet = 0;
        public float TopOffSet
        {
            get
            {
                return _topOffSet;
            }
            set
            {
                _topOffSet = value;
            }
        }

        /// <summary>
        /// 刻度值字体
        /// </summary>
        private Font _scaleValueFont;

        #endregion 变量
        /// <summary>
        /// 时间标题
        /// </summary>
        private string _timeText = "时间";

        /// <summary>
        /// 总计标题
        /// </summary>
        private string _totalText = "总用量";

        #region 属性

        /// <summary>
        /// 时间标题
        /// </summary>
        [Category("数据-自定义"), DisplayName("时间标题")]
        public string TimeText
        {
            get
            {
                return _timeText;
            }
            set
            {
                _timeText = value;
            }
        }

        /// <summary>
        /// 总计标题
        /// </summary>
        [Category("数据-自定义"), DisplayName("总计标题")]
        public string TotalText
        {
            get
            {
                return _totalText;
            }
            set
            {
                _totalText = value;
            }
        }

        /// <summary>
        /// 刻度值字体
        /// </summary>
        [Category("数据-自定义"), DisplayName("刻度值字体")]
        public Font ScaleValueFont
        {
            get
            {
                if (_scaleValueFont == null)
                {
                    return DefaultFont;
                }
                else
                {
                    return _scaleValueFont;
                }
            }
            set
            {
                _scaleValueFont = value;
            }
        }
        private DateTime _maxDateTime;
        private DateTime _miniDateTime;

        /// <summary>
        /// 最大结束时间
        /// </summary>
        [Browsable(false)]
        public DateTime MaxEndDateTime
        {
            get
            {
                return _maxDateTime;
            }
            set
            {
                _maxDateTime = value;
            }
        }
        /// <summary>
        /// 最小开始时间
        /// </summary>
        [Browsable(false)]
        public DateTime MinStartDateTime
        {
            get
            {
                return _miniDateTime;
            }
            set
            {
                _miniDateTime = value;
            }
        }
        /// <summary>
        /// 时间坐标轴位置类型
        /// </summary>
        [Category("数据-自定义"), DisplayName("时间坐标轴位置类型")]
        public TimeAxisPositionType TimeAxisPositionType
        {
            get
            {
                return _timeAxisPositionType;
            }
            set
            {
                _timeAxisPositionType = value;
            }
        }

        /// <summary>
        /// 刻度类型
        /// </summary>
        [Category("数据-自定义"), DisplayName("刻度类型")]
        public ScaleType ScaleType
        {
            get
            {
                return _scaleType;
            }
            set
            {
                _scaleType = value;
            }
        }

        /// <summary>
        /// 左边百分比
        /// </summary>
        [Category("数据-自定义"), DisplayName("左边百分比")]
        public float LeftWidthPercent
        {
            get
            {
                return _leftWidthPercent;
            }
            set
            {
                //if (value > .05f && value <= 1)
                {
                    _leftWidthPercent = value;
                }
                //else
                //{
                //    Exception ex = new Exception("无效的百分比，必须介于5%和100%之间!");
                //    throw ex;
                //}
            }
        }

        /// <summary>
        /// 右边百分比
        /// </summary>
        [Category("数据-自定义"), DisplayName("右边百分比")]
        public float RightWidthPercent
        {
            get
            {
                return _rightWidthPercent;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    _rightWidthPercent = value;
                }
                else
                {
                    Exception ex = new Exception("无效的百分比，必须介于0%和100%之间!");
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        #endregion 属性

        #region 方法

        protected virtual void AddJustEndTime()
        {
            TimeSpan ts = _endTime - _startTime;
            float gridScale = .25f;// GetGridScale();
            int scaleCount = (int)(ts.TotalHours / gridScale);
            if (scaleCount * gridScale < ts.TotalHours) scaleCount++;
            _endTime = _startTime.AddHours(scaleCount * gridScale);
        }

        /// <summary>
        /// 获取网格刻度宽度
        /// </summary>
        /// <returns></returns>
        protected virtual float GetGridWidth()
        {
            TimeSpan ts = _endTime - _startTime;
            if (_endTime == DateTime.MinValue && _startTime == DateTime.MinValue)
            {
                ts = _endTime.AddHours(4) - _startTime;
            }


            RectangleF rectF = GetMainRect();
            return (float)(rectF.Width / ts.TotalHours) * GetGridScale();
        }

        /// <summary>
        /// 获取网格刻度时间--分钟数
        /// </summary>
        /// <returns></returns>
        protected virtual int GetGridMinutes()
        {
            return (int)(60 * GetGridScale());
        }

        /// <summary>
        /// 获取网格宽度因子
        /// </summary>
        /// <returns></returns>
        protected virtual float GetGridScale()
        {
            float scale = 1;
            switch (_scaleType)
            {
                case ScaleType.Hour:
                    scale = 1;
                    break;
                case ScaleType.Quarter:
                    scale = .25f;
                    break;
                case ScaleType.HalfHour:
                    scale = .5f;
                    break;
                case ScaleType.TriQuarter:
                    scale = .75f;
                    break;
                case ScaleType.TwiHour:
                    scale = 2;
                    break;
                case ScaleType.OneMin:
                    scale = (float)(1 / 60.0);
                    break;
                case ScaleType.FiveMin:
                    scale = (float)(5 / 60.0);
                    break;
                case ScaleType.TwoMin:
                    scale = (float)(2 / 60.0);
                    break;
                case ScaleType.TenMin:
                    scale = (float)(10 / 60.0);
                    break;

            }
            return scale;
        }

        /// <summary>
        /// 获取主矩形
        /// </summary>
        /// <returns></returns>
        public virtual RectangleF GetMainRect()
        {
            Rectangle rect = OriginRect;
            RectangleF rectF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
            rectF.X += rectF.Width * _leftWidthPercent;
            rectF.Width = rectF.Width * (1 - _leftWidthPercent - _rightWidthPercent);
            //return new RectangleF(rectF.X * _zoomRate, rectF.Y * _zoomRate, rectF.Width * _zoomRate, rectF.Height * _zoomRate);
            return rectF;
        }

        //protected override RectangleF GetMainRect()
        //{
        //    RectangleF rectF = base.GetMainRect();
        //}

        private bool _first = false;
        /// <summary>
        /// 画刻度值
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawScaleValue(Graphics g)
        {
            int vSpan = 1;
            Font font = ScaleValueFont;
            RectangleF rectF = GetMainRect();
            Rectangle rect = OriginRect;
            float gridWidth = GetGridWidth();
            int minutes = GetGridMinutes();
            DateTime dt = _startTime.AddMinutes(minutes);
            if (minutes == 15)
            {
                //minutes = 30;
                //gridWidth = gridWidth * 2;
            }
            float x = rectF.X + gridWidth;
            float topOffSet = rectF.Y + vSpan;
            if (_topOffSet > 0)
            {
                topOffSet = rectF.Y + vSpan + (_topOffSet * _zoomRate - g.MeasureString("H", font).Height) / 2;
                if (topOffSet < 0)
                {
                    topOffSet = 0;
                }
            }
            using (Brush brush = new SolidBrush(_scaleValueColor))
            {
                if (_timeText != null)
                {
                    g.DrawString(_timeText, font, brush, rect.X + (rectF.X - rect.X - g.MeasureString(_timeText, font).Width) / 2, topOffSet);
                }
                if (_rightWidthPercent > 0 && _totalText != null)
                {
                    g.DrawString(_totalText, font, brush, rectF.Right + (rect.Right - rectF.Right - g.MeasureString(_totalText, font).Width) / 2, topOffSet);
                }
                string firstScaleValue = dt.AddMinutes(-minutes).ToString("HH:mm");
                g.FillRectangle(Brushes.White, new RectangleF(rectF.X, topOffSet, 1, _topOffSet));
                g.DrawString(firstScaleValue, font, brush, rectF.X - g.MeasureString(firstScaleValue, font).Width / 2, topOffSet);
                while (x + gridWidth - 5 < rectF.Right)
                {
                    string scaleValue = dt.ToString("HH:mm");
                    g.DrawString(scaleValue, font, brush, x - g.MeasureString(scaleValue, font).Width / 2, topOffSet);
                    dt = dt.AddMinutes(minutes);
                    x += gridWidth;
                }
            }
            if (_topOffSet == 0)
            {
                _topOffSet = g.MeasureString("A", font).Height + vSpan * 2;
            }
            else if (_first)
            {
                _first = false;
                _topOffSet = _topOffSet * _zoomRate;
            }
            using (Pen pen = new Pen(_borderColor, _borderWidth))
            {
                g.DrawLine(pen, rect.X + 1, rectF.Y + _topOffSet, rect.Right, rectF.Y + _topOffSet);
            }

        }

        protected override void DoDrawBorder(Graphics g)
        {
            base.DoDrawBorder(g);
            using (Pen pen = new Pen(_borderColor))
            {
                Rectangle rect = OriginRect;
                rect.Width -= 1;
                rect.Height -= 1;
                //g.DrawRectangle(pen, rect);
                g.DrawLine(pen, rect.X + rect.Width * _leftWidthPercent, rect.Y + _topOffSet, rect.X + rect.Width * _leftWidthPercent, rect.Y + rect.Height - _topOffSet);
                g.DrawLine(pen, rect.X + rect.Width * (1 - _rightWidthPercent), rect.Y, rect.X + rect.Width * (1 - _rightWidthPercent), rect.Y + rect.Height);
            }
        }

        public override void DrawGraphics(Graphics g)
        {
            base.DrawGraphics(g);
            AddJustEndTime();
            if (_timeAxisPositionType == TimeAxisPositionType.Top)
            {
                DrawScaleValue(g);
            }
            //else if (_timeAxisPositionType == TimeAxisPositionType.Bottom)
            //{
            //    DrawScaleValue(g);
            //}
            else
            {
                _topOffSet = 0;
            }
        }

        #endregion 方法

    }
}
