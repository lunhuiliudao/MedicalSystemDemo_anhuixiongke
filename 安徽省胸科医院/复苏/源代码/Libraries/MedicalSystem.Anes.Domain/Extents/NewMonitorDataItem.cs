using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    public class NewMonitorDataItem
    {
        private DateTime _timePoint;
        public DateTime TimePoint
        {
            get
            {
                return _timePoint;
            }
        }
        private string _itemCode;
        public string ItemCode
        {
            get
            {
                return _itemCode;
            }
        }
        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
        }

        private object _itemValue;
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

        private object _oldValue;
        public object OldValue
        {
            get
            {
                return _oldValue;
            }
            set
            {
                _oldValue = value;
            }
        }

        public NewMonitorDataItem(DateTime timePoint, string itemName, object itemValue, object oldvalue, string itemCode)
        {
            _timePoint = new DateTime(timePoint.Year, timePoint.Month, timePoint.Day, timePoint.Hour, timePoint.Minute, 0);
            _itemName = itemName;
            _itemValue = itemValue;
            _oldValue = oldvalue;
            _itemCode = itemCode;
        }
    }
}
