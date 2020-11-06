using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    /// <summary>
    /// 时间轴
    /// </summary>
    public class DateAxis : ICloneable
    {
        private double _min;
        private double _max;
        private double _majorStep;
        private double _minorStep;

        private bool _isVisible;

        private DateTime _minTime;
        private DateTime _maxTime;

        /// <summary>
        /// 刻度文本
        /// </summary>
        private string[] _textLabels = null;
        /// <summary>
        /// 刻度值
        /// </summary>
        //private double[] _ticVals = null;
        /// <summary>
        /// 时间刻度
        /// </summary>
        //private DateTime[] _tics = null;

        /// <summary>
        /// 格式
        /// </summary>
        private string _format;

        /// <summary>
        /// 主次刻度单位
        /// </summary>
        private DateUnit _majorUnit,
                          _minorUnit;

        //private Style _fontStyle;

        /// <summary>
        /// 最小、最大实际长度
        /// </summary>
        private double _minPix,
               _maxPix;

        #region private property

        /// <summary>
        /// 次刻度步长值
        /// </summary>
        private double GetMinorStepVal
        {
            get
            {
                DateTime dt = _minTime;
                int num = (int)_minorStep;
                dt = AddDateForMinor(dt, num);                
                return XDate.DateTimeToXLDate(dt) - _min;
            }            
        }
        /// <summary>
        /// 主刻度步长值
        /// </summary>
        private double GetMajorStepVal
        {
            get
            {
                DateTime dt = _minTime;
                int num = (int)_majorStep;
                switch (_majorUnit)
                {
                    case DateUnit.Year:
                        dt = dt.AddYears(num);
                        break;
                    case DateUnit.Month:
                        dt = dt.AddMonths(num);
                        break;
                    case DateUnit.Day:
                        dt = dt.AddDays(num);
                        break;
                    case DateUnit.Hour:
                        dt = dt.AddYears(num);
                        break;
                    case DateUnit.Minute:
                        dt = dt.AddMinutes(num);
                        break;
                    case DateUnit.Second:
                        dt = dt.AddSeconds(num);
                        break;
                }
                return XDate.DateTimeToXLDate(dt) - _min;
            }
        }
        /// <summary>
        /// 绘制表格线委托
        /// </summary>
        private Action<double, bool> _drawLineAction;
        /// <summary>
        /// 绘制刻度委托
        /// </summary>
        private Action<double, DateTime, bool> _drawTicAction;

        #endregion

        #region public property

        /// <summary>
        /// 时间轴开始时间
        /// </summary>
        public DateTime MinTime
        {
            get
            {
                return _minTime;
            }
            set
            {
                _minTime = value;
                _min = XDate.DateTimeToXLDate(value);
            }
        }
        /// <summary>
        /// 时间轴结束时间
        /// </summary>
        public DateTime MaxTime
        {
            get
            {
                return _maxTime;
            }
            set
            {
                _maxTime = value;
                _max = XDate.DateTimeToXLDate(value);
            }
        }
        /// <summary>
        /// 移动时间轴最小时间
        /// </summary>
        public DateTime? MoveMinLimitTime { get; set; }
        /// <summary>
        /// 移动时间轴最大时间
        /// </summary>
        public DateTime? MoveMaxLimitTime { get; set; }
        /// <summary>
        /// 时间轴开始长度
        /// </summary>
        public double MinPix
        {
            get
            {
                return _minPix;
            }
            set
            {
                _minPix = value;
            }
        }
        /// <summary>
        /// 时间轴结束长度
        /// </summary>
        public double MaxPix
        {
            get
            {
                return _maxPix;
            }
            set
            {
                _maxPix = value;
            }
        }
        /// <summary>
        /// 主刻度步长
        /// </summary>
        public double MajorStep
        {
            get { return _majorStep; }
            set { _majorStep = value; }
        }
        /// <summary>
        /// 次刻度步长
        /// </summary>
        public double MinorStep
        {
            get { return _minorStep; }
            set { _minorStep = value; }
        }
        /// <summary>
        /// 主刻度单位
        /// </summary>
        public DateUnit MajorUnit
        {
            get { return _majorUnit; }
            set { _majorUnit = value; }
        }
        /// <summary>
        /// 次刻度单位
        /// </summary>
        public DateUnit MinorUnit
        {
            get { return _minorUnit; }
            set { _minorUnit = value; }
        }
        /// <summary>
        /// 刻度format
        /// </summary>
        public string Format
        {
            get { return _format; }
            set { _format = value;}
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }
        /// <summary>
        /// 刻度值
        /// </summary>
        public string[] TextLabels
        {
            get { return _textLabels; }
            set { _textLabels = value; }
        }
        /// <summary>
        /// 是否显示次刻度
        /// </summary>
        public bool IsShowMinorTic { get; set; }
        /// <summary>
        /// 是否显示次刻度Label
        /// </summary>
        public bool IsShowMinorTicLabel { get; set; }

        /// <summary>
        /// 时间轴名称
        /// </summary>
        public string Title { get; set; }
        public Style TitleSytle { get; set; }

        public Style MinorTicStyle { get; set; }

        public Style MajorTicStyle { get; set; }

        /// <summary>
        /// 次网格线样式
        /// </summary>
        public Style MinorGridStyle { get; set; }

        /// <summary>
        /// 主网格线样式
        /// </summary>
        public Style MajorGridStyle { get; set; }

        #endregion

        public DateAxis()
        {
            IsShowMinorTic = true;
            IsShowMinorTicLabel = false;
            _format = "hh:mm";
        }

        #region Clone

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public DateAxis Clone()
        {
            return new DateAxis(this);
        }

        public DateAxis(DateAxis rhs)
        {
            TitleSytle = rhs.TitleSytle;
            //待完善
        }

        #endregion

        #region Methods

        //private double GetTimeVal(int indx,double step)

        /// <summary>
        /// the first major tic
        /// </summary>
        /// <returns></returns>
        private double CalcBaseTic()
        {
            int year, month, day, hour, minute, second, millisecond;
            XDate.XLDateToCalendarDate(_min, out year, out month, out day, out hour, out minute,
                                        out second, out millisecond);
            switch (_majorUnit)
            {
                case DateUnit.Year:
                default:
                    month = 1; day = 1; hour = 0; minute = 0; second = 0; millisecond = 0;
                    break;
                case DateUnit.Month:
                    day = 1; hour = 0; minute = 0; second = 0; millisecond = 0;
                    break;
                case DateUnit.Day:
                    hour = 0; minute = 0; second = 0; millisecond = 0;
                    break;
                case DateUnit.Hour:
                    minute = 0; second = 0; millisecond = 0;
                    break;
                case DateUnit.Minute:
                    second = 0; millisecond = 0;
                    break;
                case DateUnit.Second:
                    millisecond = 0;
                    break;
                case DateUnit.Millisecond:
                    break;

            }

            double xlDate = XDate.CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
            if (xlDate < _min)
            {
                switch (_majorUnit)
                {
                    case DateUnit.Year:
                    default:
                        year++;
                        break;
                    case DateUnit.Month:
                        month++;
                        break;
                    case DateUnit.Day:
                        day++;
                        break;
                    case DateUnit.Hour:
                        hour++;
                        break;
                    case DateUnit.Minute:
                        minute++;
                        break;
                    case DateUnit.Second:
                        second++;
                        break;
                    case DateUnit.Millisecond:
                        millisecond++;
                        break;

                }

                xlDate = XDate.CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
            }

            return xlDate;
        }

        /// <summary>
        /// 计算某主刻度值
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="tic"></param>
        /// <returns></returns>
        private double CalcMajorTicValue(double baseVal, double tic)
        {
            XDate xDate = new XDate(baseVal);

            switch (_majorUnit)
            {
                case DateUnit.Year:
                default:
                    xDate.AddYears(tic * _majorStep);
                    break;
                case DateUnit.Month:
                    xDate.AddMonths(tic * _majorStep);
                    break;
                case DateUnit.Day:
                    xDate.AddDays(tic * _majorStep);
                    break;
                case DateUnit.Hour:
                    xDate.AddHours(tic * _majorStep);
                    break;
                case DateUnit.Minute:
                    xDate.AddMinutes(tic * _majorStep);
                    break;
                case DateUnit.Second:
                    xDate.AddSeconds(tic * _majorStep);
                    break;
                case DateUnit.Millisecond:
                    xDate.AddMilliseconds(tic * _majorStep);
                    break;
            }

            return xDate.XLDate;
        }
        /// <summary>
        /// 计算某次刻度值
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="iTic"></param>
        /// <returns></returns>
        private double CalcMinorTicValue(double baseVal, int iTic)
        {
            XDate xDate = new XDate(baseVal);

            switch (_minorUnit)
            {
                case DateUnit.Year:
                default:
                    xDate.AddYears((double)iTic * _minorStep);
                    break;
                case DateUnit.Month:
                    xDate.AddMonths((double)iTic * _minorStep);
                    break;
                case DateUnit.Day:
                    xDate.AddDays((double)iTic * _minorStep);
                    break;
                case DateUnit.Hour:
                    xDate.AddHours((double)iTic * _minorStep);
                    break;
                case DateUnit.Minute:
                    xDate.AddMinutes((double)iTic * _minorStep);
                    break;
                case DateUnit.Second:
                    xDate.AddSeconds((double)iTic * _minorStep);
                    break;
            }

            return xDate.XLDate;
        }

        /// <summary>
        /// 计算次刻度开始索引
        /// </summary>
        /// <param name="baseVal"></param>
        /// <returns></returns>
        private int CalcMinorStart(double baseVal)
        {
            switch (_minorUnit)
            {
                case DateUnit.Year:
                default:
                    return (int)((_min - baseVal) / (365.0 * _minorStep));
                case DateUnit.Month:
                    return (int)((_min - baseVal) / (28.0 * _minorStep));
                case DateUnit.Day:
                    return (int)((_min - baseVal) / _minorStep);
                case DateUnit.Hour:
                    return (int)((_min - baseVal) * XDate.HoursPerDay / _minorStep);
                case DateUnit.Minute:
                    return (int)((_min - baseVal) * XDate.MinutesPerDay / _minorStep);
                case DateUnit.Second:
                    return (int)((_min - baseVal) * XDate.SecondsPerDay / _minorStep);
            }
        }

        /// <summary>
        /// 计算刻度数
        /// </summary>
        /// <returns></returns>
        private int CalcNumTics()
        {
            int nTics = 1;

            int year1, year2, month1, month2, day1, day2, hour1, hour2, minute1, minute2;
            int second1, second2, millisecond1, millisecond2;

            XDate.XLDateToCalendarDate(_min, out year1, out month1, out day1,
                                        out hour1, out minute1, out second1, out millisecond1);
            XDate.XLDateToCalendarDate(_max, out year2, out month2, out day2,
                                        out hour2, out minute2, out second2, out millisecond2);

            switch (_majorUnit)
            {
                case DateUnit.Year:
                default:
                    nTics = (int)((year2 - year1) / _majorStep + 1.001);
                    break;
                case DateUnit.Month:
                    nTics = (int)((month2 - month1 + 12.0 * (year2 - year1)) / _majorStep + 1.001);
                    break;
                case DateUnit.Day:
                    nTics = (int)((_max - _min) / _majorStep + 1.001);
                    break;
                case DateUnit.Hour:
                    nTics = (int)((_max - _min) / (_majorStep / XDate.HoursPerDay) + 1.001);
                    break;
                case DateUnit.Minute:
                    nTics = (int)((_max - _min) / (_majorStep / XDate.MinutesPerDay) + 1.001);
                    break;
                case DateUnit.Second:
                    nTics = (int)((_max - _min) / (_majorStep / XDate.SecondsPerDay) + 1.001);
                    break;
                case DateUnit.Millisecond:
                    nTics = (int)((_max - _min) / (_majorStep / XDate.MillisecondsPerDay) + 1.001);
                    break;
            }

            if (nTics < 1)
                nTics = 1;
            else if (nTics > 1000)
                nTics = 1000;

            return nTics;
        }

        /// <summary>
        /// 计算接近指定日期的日期，并选择所选日期的偶数倍
        /// </summary>
        /// <param name="date"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        protected double CalcEvenStepDate(double date, int direction)
        {
            int year, month, day, hour, minute, second, millisecond;

            XDate.XLDateToCalendarDate(date, out year, out month, out day,
                                        out hour, out minute, out second, out millisecond);

            // If the direction is -1, then it is sufficient to go to the beginning of
            // the current time period, .e.g., for 15-May-95, and monthly steps, we
            // can just back up to 1-May-95
            if (direction < 0)
                direction = 0;

            switch (_majorUnit)
            {
                case DateUnit.Year:
                default:
                    // If the date is already an exact year, then don't step to the next year
                    if (direction == 1 && month == 1 && day == 1 && hour == 0
                        && minute == 0 && second == 0)
                        return date;
                    else
                        return XDate.CalendarDateToXLDate(year + direction, 1, 1,
                                                        0, 0, 0);
                case DateUnit.Month:
                    // If the date is already an exact month, then don't step to the next month
                    if (direction == 1 && day == 1 && hour == 0
                        && minute == 0 && second == 0)
                        return date;
                    else
                        return XDate.CalendarDateToXLDate(year, month + direction, 1,
                                                0, 0, 0);
                case DateUnit.Day:
                    // If the date is already an exact Day, then don't step to the next day
                    if (direction == 1 && hour == 0 && minute == 0 && second == 0)
                        return date;
                    else
                        return XDate.CalendarDateToXLDate(year, month,
                                            day + direction, 0, 0, 0);
                case DateUnit.Hour:
                    // If the date is already an exact hour, then don't step to the next hour
                    if (direction == 1 && minute == 0 && second == 0)
                        return date;
                    else
                        return XDate.CalendarDateToXLDate(year, month, day,
                                                    hour + direction, 0, 0);
                case DateUnit.Minute:
                    // If the date is already an exact minute, then don't step to the next minute
                    if (direction == 1 && second == 0)
                        return date;
                    else
                        return XDate.CalendarDateToXLDate(year, month, day, hour,
                                                    minute + direction, 0);
                case DateUnit.Second:
                    return XDate.CalendarDateToXLDate(year, month, day, hour,
                                                    minute, second + direction);

                case DateUnit.Millisecond:
                    return XDate.CalendarDateToXLDate(year, month, day, hour,
                                                    minute, second, millisecond + direction);

            }
        }

        /// <summary>
        /// 获取刻度值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="dVal"></param>
        /// <returns></returns>
        private string MakeLabel(int index, double dVal)
        {
            return XDate.ToString(dVal, _format);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DrawLineAction"><![CDATA[Action<double, bool>:<pix,isMajorGrid>]]></param>
        /// <param name="DrawTicAction"><![CDATA[Action<double, string, bool>:<pix,LabelText,isMajorGrid>]]></param>
        public void Draw(Action<double, bool> DrawLineAction, Action<double, DateTime, bool> DrawTicAction)
        {
            _drawLineAction = DrawLineAction;
            _drawTicAction = DrawTicAction;
            //MajorGrid majorGrid = _ownerAxis._majorGrid;
            //MajorTic majorTic = _ownerAxis._majorTic;
            //MinorTic minorTic = _ownerAxis._minorTic;

            //float rightPix,
            //        topPix;

            //GetTopRightPix(pane, out topPix, out rightPix);

            // calculate the total number of major tics required
            int nTics = CalcNumTics();

            // get the first major tic value
            double baseVal = CalcBaseTic();

            //绘制网格线（纵向）及刻度
            DrawMajorGrid(baseVal, nTics, DrawLineAction, DrawTicAction);
            DrawMinorGrid(baseVal, DrawLineAction, DrawTicAction);
        }
        /// <summary>
        /// 绘制次网格及刻度
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="nTics"></param>
        /// <param name="DrawLineAction">绘制网格线委托</param>
        /// <param name="DrawTicAction">绘制刻度委托</param>
        private void DrawMajorGrid(double baseVal, int nTics, Action<double, bool> DrawLineAction, Action<double, DateTime, bool> DrawTicAction)
        {
            double dVal;
            double pixVal;

            double rangeTol = (_max - _min) * 0.001;

            int firstTic = (int)((_min - baseVal) / _majorStep + 0.99);
            if (firstTic < 0)
                firstTic = 0;

            // save the position of the previous tic
            //				float lastPixVal = -10000;

            // loop for each major tic
            for (int i = firstTic; i < nTics + firstTic; i++)
            {
                dVal = CalcMajorTicValue(baseVal, i);

                // If we're before the start of the scale, just go to the next tic
                if (dVal < _min)
                    continue;
                // if we've already past the end of the scale, then we're done
                //if (dVal > _maxLinTemp + rangeTol)
                //    break;
                if (dVal > _max)
                    break;

                // convert the value to a pixel position
                bool IsOverMin, IsOverMax;
                pixVal = LocalTransform(dVal, out IsOverMin, out IsOverMax);
                if (DrawLineAction != null)
                    DrawLineAction(pixVal, true);
                if (DrawTicAction != null)
                    DrawTicAction(pixVal, XDate.XLDateToDateTime(dVal), true);
            }
        }
        /// <summary>
        /// 绘制次网格及刻度
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="DrawLineAction">绘制网格线委托</param>
        /// <param name="DrawTicAction">绘制刻度委托</param>
        private void DrawMinorGrid(double baseVal, Action<double, bool> DrawLineAction, Action<double, DateTime, bool> DrawTicAction)
        {
            double first = _min,
                   last = _max;
            double dVal = first;
            double pixVal;

            int iTic = CalcMinorStart(baseVal);
            int MajorTic = 0;
            double majorVal = CalcMajorTicValue(baseVal, MajorTic);

            while (dVal < last && iTic < 5000)
            {
                dVal = CalcMinorTicValue(baseVal, iTic);
                if (dVal > majorVal)
                    majorVal = CalcMajorTicValue(baseVal, ++MajorTic);
                if (((Math.Abs(dVal) < 1e-20 && Math.Abs(dVal - majorVal) > 1e-20) ||
                                (Math.Abs(dVal) > 1e-20 && Math.Abs((dVal - majorVal) / dVal) > 1e-10)) &&
                                (dVal >= first && dVal <= last))
                {
                    bool IsOverMin, IsOverMax;
                    pixVal = LocalTransform(dVal, out IsOverMin, out IsOverMax);
                    //画线
                    if (DrawLineAction != null)
                        DrawLineAction(pixVal, false);
                    if (IsShowMinorTic && DrawTicAction != null)
                        DrawTicAction(pixVal, XDate.XLDateToDateTime(dVal), false);
                }

                iTic++;
            }
        }
        private double LocalTransform(double x, out bool IsOverMin, out bool IsOverMax)
        {
            IsOverMin = false;
            IsOverMax = false;
            // Must take into account Log, and Reverse Axes
            double ratio;
            double rv;

            // Coordinate values for log scales are already in exponent form, so no need
            // to take the log here
            //ratio = (x - _minLinTemp) /
            //            (_maxLinTemp - _minLinTemp);
            ratio = (x - _min) / (_max - _min);

            //rv = (float)((_maxPix - _minPix) * (1.0F - ratio));
            rv = (double)((_maxPix - _minPix) * ratio) + _minPix;

            if (rv < _minPix)
            {
                rv = _minPix;
                IsOverMin = true;
            }
            else if (rv > _maxPix)
            {
                rv = _maxPix;
                IsOverMax = true;
            }
            return rv;
        }

        public double LocalTransform(DateTime time, out bool IsOverMin, out bool IsOverMax)
        {
            return LocalTransform(XDate.DateTimeToXLDate(time), out IsOverMin, out IsOverMax);
        }

        public TimeSpan GetMoveTs(double pix)
        {
            return XDate.XLDateToDateTime((_max - _min) / (_maxPix - _minPix) * pix + _min) - _minTime; 
        }
        public DateTime GetTime(double pix)
        {
            return XDate.XLDateToDateTime((_max - _min) / (_maxPix - _minPix) * (pix - _minPix) + _min);
        }
        public string GetMoveDesc(double pix)
        {
            string strDesc = string.Empty;
            int iMoveMinor = (int)(((_max - _min) / (_maxPix - _minPix) * pix) / GetMinorStepVal);
            string minorUnitDesc = "分钟";
            switch (_minorUnit)
            {
                case DateUnit.Year:
                    minorUnitDesc = "年";
                    break;
                case DateUnit.Month:
                    minorUnitDesc = "月";
                    break;
                case DateUnit.Day:
                    minorUnitDesc = "天";
                    break;
                case DateUnit.Hour:
                    minorUnitDesc = "小时";
                    break;
                case DateUnit.Minute:
                    minorUnitDesc = "分钟";
                    break;
                case DateUnit.Second:
                    minorUnitDesc = "秒";
                    break;
            }
            strDesc = System.Math.Abs(_minorStep * iMoveMinor) + minorUnitDesc;

            DateTime movedMintime = AddDateForMinor(MinTime, iMoveMinor);
            DateTime movedMaxtime = AddDateForMinor(MaxTime, iMoveMinor);
            if (MoveMinLimitTime.HasValue && movedMintime < MoveMinLimitTime)
            {
                //movedMaxtime = movedMaxtime + (MoveMinLimitTime.Value - movedMintime);
                //movedMintime = MoveMinLimitTime.Value;
                strDesc = "已移到最小时间";
            }
            if (MoveMaxLimitTime.HasValue && movedMaxtime > MoveMaxLimitTime)
            {
                //movedMintime = movedMintime + (MoveMaxLimitTime.Value - movedMaxtime);
                //movedMaxtime = MoveMaxLimitTime.Value;
                strDesc = "已移到最大时间";
            }
            return strDesc;
        }

        public void MoveAxis(double pix, Action MoveBeforeAction, Action MoveAfterAction)
        {
            int iMoveMinor = (int)(((_max - _min) / (_maxPix - _minPix) * pix) / GetMinorStepVal);
            int num = (int)_minorStep * iMoveMinor;
            if (num == 0)
                return;
            DateTime movedMintime = AddDateForMinor(MinTime, num);
            DateTime movedMaxtime = AddDateForMinor(MaxTime, num);
            if (MoveMinLimitTime.HasValue && movedMintime < MoveMinLimitTime)
            {
                movedMaxtime = movedMaxtime + (MoveMinLimitTime.Value - movedMintime);
                movedMintime = MoveMinLimitTime.Value;
            }
            if (MoveMaxLimitTime.HasValue && movedMaxtime > MoveMaxLimitTime)
            {
                movedMintime = movedMintime + (MoveMaxLimitTime.Value - movedMaxtime);
                movedMaxtime = MoveMaxLimitTime.Value;
            }
                
            MinTime = movedMintime;
            MaxTime = movedMaxtime;
            if (MoveBeforeAction != null)
                MoveBeforeAction();
            if (_drawLineAction != null)
                Draw(_drawLineAction, _drawTicAction);
            if (MoveAfterAction != null)
                MoveAfterAction();
        }

        private DateTime AddDateForMinor(DateTime dt, int num)
        {
            switch (_minorUnit)
            {
                case DateUnit.Year:
                    dt = dt.AddYears(num);
                    break;
                case DateUnit.Month:
                    dt = dt.AddMonths(num);
                    break;
                case DateUnit.Day:
                    dt = dt.AddDays(num);
                    break;
                case DateUnit.Hour:
                    dt = dt.AddHours(num);
                    break;
                case DateUnit.Minute:
                    dt = dt.AddMinutes(num);
                    break;
                case DateUnit.Second:
                    dt = dt.AddSeconds(num);
                    break;
            }
            return dt;
        }

        //public DateTime GetTime()


        #endregion
    }
}
