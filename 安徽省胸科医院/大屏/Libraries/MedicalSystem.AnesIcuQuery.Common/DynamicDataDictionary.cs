using System;
using System.Collections.Generic;
using System.Dynamic;

namespace MedicalSystem.AnesIcuQuery.Common
{
    /// <summary>
    /// 动态泛型字典类, 用法如下：
    /// dynamic viewBag = new DynamicDataDictionary();
    /// viewBag.Name = "zan"; 或 viewBag[Name] = "zan";
    /// </summary>
    public class DynamicDataDictionary : DynamicObject
    {
        private readonly Dictionary<string, object> _innerDictionary
            = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        public object this[string key]
        {
            get
            {
                object value;
                _innerDictionary.TryGetValue(key, out value);
                return value;
            }
            set { _innerDictionary[key] = value; }
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _innerDictionary.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            _innerDictionary.TryGetValue(binder.Name, out result);
            // since ViewDataDictionary always returns a result even if the key does not exist, always return true
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _innerDictionary[binder.Name] = value;
            // you can always set a key in the dictionary so return true 
            return true;
        }


    }
}
