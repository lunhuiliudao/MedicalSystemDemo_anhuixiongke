using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Designer
{
    [ToolboxItem(false)]
    public class AliasNamesDropDownEditorControl : ListDropDownEditorControl
    {
        public AliasNamesDropDownEditorControl(List<KeyValue> list, bool mulitSelect) : base(list,mulitSelect) { }
        private int IndexOf(string value)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if ((_list[i] as KeyValue).Value.Equals(value))
                {
                    return i;
                }
            }
            return 0;
        }

        public override object GetEditValue()
        {
            if (_newvalue is KeyValue)
            {
                return (_newvalue as KeyValue).Value;
            }
            else if (_newvalue is List<object>)
            {
                List<object> list = _newvalue as List<object>;
                string text = "";
                foreach (object obj in list)
                {
                    if (obj is KeyValue)
                    {
                        text += "," + (obj as KeyValue).Value;
                    }
                }
                if (!string.IsNullOrEmpty(text))
                {
                    text = text.Substring(1);
                    return text;
                }
            }
            return null;
        }

        public override void SetEditValue(object value)
        {
            _oldvalue = _list[IndexOf((value == null)?"":value.ToString())];
            OnValueChange();
        }
    }
}
