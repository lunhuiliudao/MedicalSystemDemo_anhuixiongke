using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class LineParameter
    {
        public LineParameter() { }

        private string _text = "";
        [DisplayName("名称")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        private string _text2 = "";
        [DisplayName("名称2")]
        public string Text2
        {
            get
            {
                return _text2;
            }
            set
            {
                _text2 = value;
            }
        }

        public string DisplayText = "";
        public string DisplayText2 = "";
        public string DisplayUnit = "";
        public string DisplayUnit2 = "";
        private string _unit = "";
        [DisplayName("单位")]
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        private string _unit2 = "";
        [DisplayName("单位2")]
        public string Unit2
        {
            get
            {
                return _unit2;
            }
            set
            {
                _unit2 = value;
            }
        }

        private int _intervalMinute = 15;
        [DisplayName("时间间隔")]
        public int IntervalMinute
        {
            get
            {
                return _intervalMinute;
            }
            set
            {
                _intervalMinute = value;
            }
        }

        private int _intervalMinute2 = 15;
        [DisplayName("时间间隔2")]
        public int IntervalMinute2
        {
            get
            {
                return _intervalMinute2;
            }
            set
            {
                _intervalMinute2 = value;
            }
        }

        public override string ToString()
        {
            return  AssemblyHelper.GetTextUnit(this);
        }
    }

}
