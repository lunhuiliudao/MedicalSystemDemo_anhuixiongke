//2013-12-11 周青 监测项目个性化设置
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedSheetDetail
    {
        private string _curveCode;
        [DisplayName("监测项目代码")]
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
        [DisplayName("监测项目名称")]
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
        [DisplayName("是否持续显示")]
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
