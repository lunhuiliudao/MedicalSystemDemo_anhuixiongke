/*----------------------------------------------------------------
      // Copyright (C) 2010 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：EventItem.cs
      // 文件功能描述：麻醉事件条目
      //
      // 
      // 创建标识：戴呈祥-2011-01-14
      // 修改标识：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class EventItem
    {
        private DateTime _startTime;
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        private string _eventName = "";
        public string EventName
        {
            get
            {
                return _eventName;
            }
            set
            {
                _eventName = value;
            }
        }

        public EventItem(DateTime startTime, string eventName)
        {
            _startTime = startTime;
            _eventName = eventName;
        }
    }
}
