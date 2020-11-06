using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    public class LookUpEditItem : INotifyPropertyChanged
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
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string aa)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(aa));
            }
        }
    }
}
