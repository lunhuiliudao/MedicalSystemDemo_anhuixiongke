using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Designer
{
    [Serializable]
    public class KeyValue
    {
        public KeyValue() { }
        public KeyValue(string key, string value)
        {
            _key = key;
            _value = value;
        }

        private string _key;
        [Description("键")]
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        private string _value;
        [Description("值")]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public override string ToString()
        {
            return _key + "(" + _value + ")";
        }
    }
}
