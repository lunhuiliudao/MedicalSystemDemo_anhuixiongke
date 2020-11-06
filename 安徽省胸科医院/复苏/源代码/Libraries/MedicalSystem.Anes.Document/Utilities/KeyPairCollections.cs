using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Utilities
{
    public class KeyPairDictionary<T, U> : Dictionary<T, U>
    {
        public T GetKey(U value)
        {
            Dictionary<T, U>.Enumerator keyValues = GetEnumerator();
            while (keyValues.MoveNext())
            {
                if (keyValues.Current.Value.Equals(value))
                {
                    return keyValues.Current.Key;
                }
            }
            return Keys.GetEnumerator().Current;
        }

        public T GetKey(int index)
        {
            int i = 0;
            Dictionary<T, U>.Enumerator keyValues = GetEnumerator();
            while (keyValues.MoveNext())
            {
                if (i == index) return keyValues.Current.Key;
                i++;
            }
            return Keys.GetEnumerator().Current;
        }

        public KeyPairDictionary<U, T> SwitchKeyValue()
        {
            KeyPairDictionary<U, T> dict = new KeyPairDictionary<U, T>();
            Dictionary<T, U>.Enumerator keyValues = GetEnumerator();
            while (keyValues.MoveNext())
            {
                if (!dict.ContainsKey(keyValues.Current.Value))
                {
                    dict.Add(keyValues.Current.Value, keyValues.Current.Key);
                }
            }
            return dict;
        }
    }
}
