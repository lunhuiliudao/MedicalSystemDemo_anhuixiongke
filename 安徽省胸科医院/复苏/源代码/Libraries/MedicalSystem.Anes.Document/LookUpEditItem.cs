using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    public class LookUpEditItem
    {
        public LookUpEditItem(string displayText, object itemValue)
        {
            _displayText = displayText;
            _itemValue = itemValue;
        }
        private string _displayText;
        private object _itemValue;

        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;
            }
        }

        public object ItemValue
        {
            get
            {
                return _itemValue;
            }
            set
            {
                _itemValue = value;
            }
        }
    }
}
