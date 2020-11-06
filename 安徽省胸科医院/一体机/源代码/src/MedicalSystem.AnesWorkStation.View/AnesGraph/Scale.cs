using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    abstract public class Scale
    {
        internal double _min,
                        _max,
                        _majorStep,
                        _minorStep,
                        _exponent,
                        _baseTic;

        internal bool _minAuto,
                                _maxAuto,
                                _majorStepAuto,
                                _minorStepAuto,
                                _magAuto,
                                _formatAuto;

        internal bool _isVisible,
                      _isMinLabelVisible,    //最小刻度值是否显示
                      _isMaxLabelVisible;    //最大刻度值是否显示

        /// <summary>
        /// 刻度值
        /// </summary>
        internal string[] _textLabels = null;

        /// <summary>
        /// 格式
        /// </summary>
        internal string _format;

        internal DateUnit _majorUnit,
                          _minorUnit;

        internal AlignP _align;

        internal AlignH _alignH;

        internal AlignH _alignHMinLabel;
        internal AlignH _alignHMaxLabel;

        internal Style _fontStyle = null;

        internal double _minPix = 0,
                            _maxPix = 0;

        internal Axis _ownerAxis;


        #region properties

        abstract public AxisType Type { get; }

        //public bool IsDate { get { return this is DateScale; } }

        public virtual double Min
        {
            get { return _min; }
            set { _min = value; _minAuto = false; }
        }

        public virtual double Max
        {
            get { return _max; }
            set { _max = value; _maxAuto = false; }
        }

        public double MajorStep
        {
            get { return _majorStep; }
            set
            {
                if (value < 1e-300)
                {
                    _majorStepAuto = true;
                }
                else
                {
                    _majorStep = value;
                    _majorStepAuto = false;
                }
            }
        }

        public double MinorStep
        {
            get { return _minorStep; }
            set
            {
                if (value < 1e-300)
                {
                    _minorStepAuto = true;
                }
                else
                {
                    _minorStep = value;
                    _minorStepAuto = false;
                }
            }
        }

        public double MinorStepVal
        {
            get
            {
                double val = 0;
                switch (MinorUnit)
                {
                    case DateUnit.Minute:
                        //val=XDate.DateTimeToXLDate()
                        break;
                }
                return val;
            }
        }
        public DateUnit MajorUnit
        {
            get { return _majorUnit; }
            set { _majorUnit = value; }
        }

        public DateUnit MinorUnit
        {
            get { return _minorUnit; }
            set { _minorUnit = value; }
        }

        virtual internal double MajorUnitMultiplier
        {
            get { return 1.0; }
        }
        virtual internal double MinorUnitMultiplier
        {
            get { return 1.0; }
        }
        public bool MinAuto
        {
            get { return _minAuto; }
            set { _minAuto = value; }
        }
        public bool MaxAuto
        {
            get { return _maxAuto; }
            set { _maxAuto = value; }
        }
        public bool MajorStepAuto
        {
            get { return _majorStepAuto; }
            set { _majorStepAuto = value; }
        }
        public bool MinorStepAuto
        {
            get { return _minorStepAuto; }
            set { _minorStepAuto = value; }
        }
        public bool FormatAuto
        {
            get { return _formatAuto; }
            set { _formatAuto = value; }
        }
        public string Format
        {
            get { return _format; }
            set { _format = value; _formatAuto = false; }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }
        public string[] TextLabels
        {
            get { return _textLabels; }
            set { _textLabels = value; }
        }
        #endregion

        public Scale(Axis ownerAxis)
        {
            _ownerAxis = ownerAxis;

            _min = 0.0;
            _max = 1.0;
            _majorStep = 0.1;
            _minorStep = 0.1;
            _exponent = 1.0;

            _minAuto = true;
            _maxAuto = true;
            _majorStepAuto = true;
            _minorStepAuto = true;
            _magAuto = true;
            _formatAuto = true;

            _isVisible = true;
            _isMinLabelVisible = true;
            _isMaxLabelVisible = true;

            _majorUnit = DateUnit.Day;
            _minorUnit = DateUnit.Day;

            _format = null;
            _textLabels = null;
        }
        public Scale(Scale rhs, Axis owner)
        {
            _ownerAxis = owner;

            _min = rhs._min;
            _max = rhs._max;
            _majorStep = rhs._majorStep;
            _minorStep = rhs._minorStep;
            _exponent = rhs._exponent;
            _baseTic = rhs._baseTic;

            _minAuto = rhs._minAuto;
            _maxAuto = rhs._maxAuto;
            _majorStepAuto = rhs._majorStepAuto;
            _minorStepAuto = rhs._minorStepAuto;
            _magAuto = rhs._magAuto;
            _formatAuto = rhs._formatAuto;

            _isMinLabelVisible = rhs._isMinLabelVisible;
            _isMaxLabelVisible = rhs._isMaxLabelVisible;

            _majorUnit = rhs._majorUnit;
            _minorUnit = rhs._minorUnit;

            _format = rhs._format;

            _align = rhs._align;
            _alignH = rhs._alignH;
            _alignHMaxLabel = rhs._alignHMaxLabel;
            _alignHMinLabel = rhs._alignHMinLabel;

            if (rhs._textLabels != null)
                _textLabels = (string[])rhs._textLabels.Clone();
            else
                _textLabels = null;
        }

        public Scale MakeNewScale(Scale oldScale, AxisType type)
        {
            switch (type)
            {
                case AxisType.Linear:
                    return null;
                case AxisType.Date:
                    return null;
                //case AxisType.Log:
                //    return new LogScale(oldScale, _ownerAxis);
                //case AxisType.Exponent:
                //    return new ExponentScale(oldScale, _ownerAxis);
                //case AxisType.Ordinal:
                //    return new OrdinalScale(oldScale, _ownerAxis);
                //case AxisType.Text:
                //    return new TextScale(oldScale, _ownerAxis);
                //case AxisType.DateAsOrdinal:
                //    return new DateAsOrdinalScale(oldScale, _ownerAxis);
                //case AxisType.LinearAsOrdinal:
                //    return new LinearAsOrdinalScale(oldScale, _ownerAxis);
                default:
                    throw new Exception("Implementation Error: Invalid AxisType");
            }
        }

        virtual internal double CalcBaseTic()
        {
            return Math.Ceiling((double)_min / (double)_majorStep - 0.00000001)
                                                        * (double)_majorStep;
        }
        virtual internal double CalcMajorTicValue(double baseVal, double tic)
        {
            // Default behavior is a normal linear scale (also works for ordinal types)
            return baseVal + (double)_majorStep * tic;
        }
    }

    //internal class DateScale : Scale
    //{
    //    public override AxisType Type
    //    {
    //        get
    //        {
    //            return AxisType.Date;
    //        }
    //    }

    //    public DateScale(Scale rhs, Axis owner)
    //        : base(rhs, owner)
    //    {
    //    }
    //}
}
