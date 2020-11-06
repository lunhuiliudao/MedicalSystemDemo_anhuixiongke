using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    [Serializable]
    public class Axis : ICloneable
    {
        private double _min;
        private double _max;
        private double _majorStep;
        private double _minorStep;
        /// <summary>
        /// 格式
        /// </summary>
        private string _format;
        private bool _isVisible;

        /// <summary>
        /// 最小、最大实际长度
        /// </summary>
        private double _minPix,
               _maxPix;
        internal double _minLinTemp,
                                _maxLinTemp;
        internal bool _isReverse = false;
        /// <summary>
        /// 单位
        /// </summary>
        internal string _unit;
        /// <summary>
        /// 更多主刻度
        /// </summary>
        internal int _moreMajorTics;

        /// <summary>
        /// 绘制GridLine委托
        /// </summary>
        //private Action<double, bool> _drawLineAction;
        /// <summary>
        /// 绘制刻度委托
        /// </summary>
        //private Action<double, double, bool> _drawTicAction;

        internal double _minLinearized
        {
            get { return Linearize(_min); }
            set { _min = DeLinearize(value); }
        }
        internal double _maxLinearized
        {
            get { return Linearize(_max); }
            set { _max = DeLinearize(value); }
        }
        internal double _maxLinTemp2
        {
            get
            {
                return _maxLinTemp + _majorStep * (string.IsNullOrEmpty(_unit) ? 0 : 1 + _moreMajorTics);
            }
        }

        #region 属性
        /// <summary>
        /// 是否是主轴
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        /// 轴索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public double Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
            }
        }
        /// <summary>
        /// 最大值
        /// </summary>
        public double Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }
        /// <summary>
        /// 轴开始长度
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
        /// 轴结束长度
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

        public double MajorStepPix
        {
            get
            {
                double dVal = CalcMajorTicValue(_min, 0);
                double dVal1 = CalcMajorTicValue(_min, 1);
                return LocalTransform(dVal1) - LocalTransform(dVal);
            }
        }

        /// <summary>
        /// 刻度format
        /// </summary>
        public string Format
        {
            get { return _format; }
            set { _format = value; }
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

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        /// <summary>
        /// 更多主刻度数
        /// </summary>
        public int MoreMajorTics
        {
            get { return _moreMajorTics; }
            set { _moreMajorTics = value; }
        }
        /// <summary>
        /// 所有刻度数
        /// </summary>
        public int AllTics
        {
            get
            {
                return CalcNumTics();
            }
        }
        /// <summary>
        /// 有效刻度数
        /// </summary>
        public int ValidTics
        {
            get
            {
                int nTics = 1;
                nTics = (int)((_max - _min) / _majorStep + 0.01) + 1;

                if (nTics < 1)
                    nTics = 1;
                else if (nTics > 1000)
                    nTics = 1000;

                return nTics;
            }
        }
        #endregion


        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Axis Clone()
        {
            return new Axis(this);
        }

        public Axis(Axis rhs)
        {
            TitleSytle = rhs.TitleSytle;
        }

        public Axis()
        {
            _isVisible = true;
            IsShowMinorTic = false;
            _format = "";
        }

        #region Methods

        public void Draw(Action<double, bool, bool> DrawLineAction, Action<double, object, bool> DrawTicAction)
        {
            _minLinTemp = Linearize(_min);
            _maxLinTemp = Linearize(_max);
            if (_isVisible)
            {
                int nTics = CalcNumTics();
                double baseVal = CalcBaseTic();
                //绘制网格线（纵向）及刻度
                DrawMajorGrid(baseVal, nTics, DrawLineAction, DrawTicAction);
                if (IsShowMinorTic && _minorStep > 0)
                    DrawMinorGrid(baseVal, DrawLineAction, DrawTicAction);
            }
        }

        /// <summary>
        /// 绘制次网格及刻度
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="nTics"></param>
        /// <param name="DrawLineAction">绘制网格线委托</param>
        /// <param name="DrawTicAction">绘制刻度委托</param>
        private void DrawMajorGrid(double baseVal, int nTics, Action<double, bool, bool> DrawLineAction, Action<double, object, bool> DrawTicAction)
        {
            double dVal;
            double pixVal;

            double rangeTol = (_max - _min) * 0.001;

            int firstTic = (int)((_min - baseVal) / _majorStep + 0.99);
            if (firstTic < 0)
                firstTic = 0;

            // save the position of the previous tic
            //				float lastPixVal = -10000;

            bool isDrawedUnit = false;
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
                {
                    pixVal = LocalTransform(dVal);
                    if (!isDrawedUnit && DrawTicAction != null)
                    {
                        DrawTicAction(pixVal, Unit, true);
                        isDrawedUnit = true;
                    }
                    if (DrawLineAction != null)
                        DrawLineAction(pixVal, true, true);
                    //break;
                }
                else
                {
                    // convert the value to a pixel position
                    //bool IsOverMin, IsOverMax;
                    pixVal = LocalTransform(dVal);
                    if (DrawLineAction != null)
                        DrawLineAction(pixVal, true, false);
                    if (DrawTicAction != null)
                        DrawTicAction(pixVal, dVal, true);
                }
            }
        }
        /// <summary>
        /// 绘制次网格及刻度
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="DrawLineAction">绘制网格线委托</param>
        /// <param name="DrawTicAction">绘制刻度委托</param>
        private void DrawMinorGrid(double baseVal, Action<double, bool, bool> DrawLineAction, Action<double, object, bool> DrawTicAction)
        {
            if (_minorStep <= 0)
                return;
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
                    //bool IsOverMin, IsOverMax;
                    pixVal = LocalTransform(dVal);
                    //画线
                    if (DrawLineAction != null)
                        DrawLineAction(pixVal, false, false);
                    if (DrawTicAction != null)
                        DrawTicAction(pixVal, dVal, false);
                }

                iTic++;
            }
        }

        /// <summary>
        /// the first major tic
        /// </summary>
        /// <returns></returns>
        private double CalcBaseTic()
        {
            return Math.Ceiling((double)_min / (double)_majorStep - 0.00000001)
                                                        * (double)_majorStep;
        }

        /// <summary>
        /// 计算某主刻度值
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="tic"></param>
        /// <returns></returns>
        private double CalcMajorTicValue(double baseVal, double tic)
        {
            return baseVal + (double)_majorStep * tic;
        }
        /// <summary>
        /// 计算某次刻度值
        /// </summary>
        /// <param name="baseVal"></param>
        /// <param name="iTic"></param>
        /// <returns></returns>
        private double CalcMinorTicValue(double baseVal, int iTic)
        {
            return baseVal + (double)_minorStep * (double)iTic;
        }

        /// <summary>
        /// 计算次刻度开始索引
        /// </summary>
        /// <param name="baseVal"></param>
        /// <returns></returns>
        private int CalcMinorStart(double baseVal)
        {
            return (int)((_min - baseVal) / _minorStep);
        }

        /// <summary>
        /// 计算刻度数
        /// </summary>
        /// <returns></returns>
        private int CalcNumTics()
        {
            int nTics = 1;

            // default behavior is for a linear or ordinal scale
            //nTics = (int)((_max - _min) / _majorStep + 0.01) + 1;
            nTics = (int)((_max - _min) / _majorStep + 0.01 + (string.IsNullOrEmpty(_unit) ? 0 : 1) + _moreMajorTics) + 1;

            if (nTics < 1)
                nTics = 1;
            else if (nTics > 1000)
                nTics = 1000;

            return nTics;
        }
        protected double MyMod(double x, double y)
        {
            double temp;

            if (y == 0)
                return 0;

            temp = x / y;
            return y * (temp - Math.Floor(temp));
        }

        public float Transform(double x)
        {
            // Must take into account Log, and Reverse Axes
            //double denom = (_maxLinTemp - _minLinTemp);
            double denom = (_maxLinTemp2 - _minLinTemp);
            double ratio;
            if (denom > 1e-100)
                ratio = (Linearize(x) - _minLinTemp) / denom;
            else
                ratio = 0;

            // _isReverse   axisType    Eqn
            //     T          XAxis     _maxPix - ...
            //     F          YAxis     _maxPix - ...
            //     F          Y2Axis    _maxPix - ...

            //     T          YAxis     _minPix + ...
            //     T          Y2Axis    _minPix + ...
            //     F          XAxis     _minPix + ...

            if (_isReverse == false)
                return (float)(_maxPix - (_maxPix - _minPix) * ratio);
            else
                return (float)(_minPix + (_maxPix - _minPix) * ratio);
        }

        public float Transform(bool isOverrideOrdinal, int i, double x)
        {
            return Transform(x);
        }

        public double ReverseTransform(float pixVal)
        {
            double val;

            // see if the sign of the equation needs to be reversed
            if ((_isReverse) == false)
                val = (double)(pixVal - _maxPix)
                        / (double)(_minPix - _maxPix)
                        * (_maxLinTemp2 - _minLinTemp) + _minLinTemp;
            else
                val = (double)(pixVal - _minPix)
                        / (double)(_maxPix - _minPix)
                        * (_maxLinTemp2 - _minLinTemp) + _minLinTemp;

            return DeLinearize(val);
        }

        public float LocalTransform(double x)
        {
            // Must take into account Log, and Reverse Axes
            double ratio;
            float rv;

            // Coordinate values for log scales are already in exponent form, so no need
            // to take the log here
            //ratio = (x - _minLinTemp) /
            //            (_maxLinTemp - _minLinTemp);
            ratio = (x - _minLinTemp) /
                (_maxLinTemp2 - _minLinTemp);

            if (_isReverse == false)
                rv = (float)((_maxPix - _minPix) * ratio);
            else
                rv = (float)((_maxPix - _minPix) * (1.0F - ratio));

            return rv;
        }
        public static double SafeLog(double x)
        {
            if (x > 1.0e-20)
                return Math.Log10(x);
            else
                return 0.0;
        }
        public static double SafeExp(double x, double exponent)
        {
            if (x > 1.0e-20)
                return Math.Pow(x, exponent);
            else
                return 0.0;
        }
        private double Linearize(double val)
        {
            return val;
        }
        private double DeLinearize(double val)
        {
            return val;
        }
        #endregion
    }
}
