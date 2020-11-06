using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MedicalSystem.AnesWorkStation.Model.DocControl
{
    public class MemberDetail
    {
        private string _name;
        private object _value;
        private Type _type;
        public MemberDetail(string name, object value, Type type) { _name = name; _value = value; _type = type; }
        public object Value
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public PropertyInfo PropertyInfo
        {
            get
            {
                if (_value is string)
                {
                    return _type.GetProperty(_value.ToString());
                }
                else
                {
                    return _type.GetProperty(_value.GetType().Name);
                }
            }
        }

        public override string ToString()
        {
            return _name;
        }

    }

}
