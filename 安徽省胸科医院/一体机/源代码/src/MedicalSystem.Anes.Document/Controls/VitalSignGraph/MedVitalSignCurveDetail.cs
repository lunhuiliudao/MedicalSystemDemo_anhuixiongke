using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedVitalSignCurveDetail
    {
        private string _curveCode;
        [DisplayName("曲线代码")]
        public string CurveCode
        {
            get
            {
                return _curveCode;
            }
            set
            {
                _curveCode = value;
            }
        }

        private string _curveName;
        [DisplayName("曲线名称")]
        public string CurveName
        {
            get
            {
                return _curveName;
            }
            set
            {
                _curveName = value;
            }
        }

        private bool _visible = true;
        [DisplayName("是否显示")]
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
            }
        }

        private MedSymbolType _symbolType = MedSymbolType.Circle;
        [DisplayName("标识类型")]
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

        private string _symbolEntry = null;
        [DisplayName("标识实体")]
        public string SymbolEntry
        {
            get
            {
                return _symbolEntry;
            }
            set
            {
                _symbolEntry = value;
            }
        }

        private Color _color = Color.Red;
        [DisplayName("颜色")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        private MedCurveShowType _showType = MedCurveShowType.Line;
        [DisplayName("显示类型")]
        public MedCurveShowType ShowType
        {
            get
            {
                return _showType;
            }
            set
            {
                _showType = value;
            }
        }

        private int _yAxisIndex = 0;
        [DisplayName("Y坐标索引")]
        public int YAxisIndex
        {
            get
            {
                return _yAxisIndex;
            }
            set
            {
                _yAxisIndex = value;
            }
        }

        private int _dotNumber = 0;
        /// <summary>
        /// 小数位数
        /// </summary>
        [DisplayName("小数位数")]
        public int DotNumber
        {
            get
            {
                return _dotNumber;
            }
            set
            {
                if (value >= 0)
                {
                    _dotNumber = value;
                }
                else
                {
                    _dotNumber = 0;
                }
            }
        }

        private MedShowTimeInterval _showTimeInterval = MedShowTimeInterval.Five;
        [DisplayName("显示时间间隔")]
        public MedShowTimeInterval ShowTimeInterval
        {
            get
            {
                return _showTimeInterval;
            }
            set
            {
                _showTimeInterval = value;
            }
        }

        private DateTime _hideStartTime;
        [DisplayName("开始隐藏时间")]
        public DateTime HideStartTime
        {
            get { return _hideStartTime; }
            set { _hideStartTime = value; }
        }

        private DateTime _hideEndTime;
        [DisplayName("结束隐藏时间")]
        public DateTime HideEndTime
        {
            get { return _hideEndTime; }
            set { _hideEndTime = value; }
        }

        public override string ToString()
        {
            return _curveName;
        }

    }
}
