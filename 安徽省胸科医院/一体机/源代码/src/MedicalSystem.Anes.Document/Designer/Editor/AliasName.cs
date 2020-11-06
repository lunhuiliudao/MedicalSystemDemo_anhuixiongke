using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Designer
{
    [Serializable]
    public class AliasName
    {
        public AliasName() { }
        public AliasName(string value, string alias)
        {
            _value = value;
            _alias = alias;
        }

        private string _value;
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
        private string _alias;
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
            }
        }

        public override string ToString()
        {
            return _alias + "(" + _value + ")";
        }
    }
}
