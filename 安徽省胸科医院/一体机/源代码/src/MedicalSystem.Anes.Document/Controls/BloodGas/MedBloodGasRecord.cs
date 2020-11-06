using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedBloodGasRecord
    {
        private string showText;
        [DisplayName("显示文本")]
        public string ShowText
        {
            get { return showText; }
            set { showText = value; }
        }

        private string recordName;
        [DisplayName("记录名称")]
        public string RecordName
        {
            get { return recordName; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    recordName = value;
                }
                else
                {
                    Exception ex = new Exception("无效的记录名称,不能为空!");
                    throw ex;
                }
            }
        }

        private DateTime timePoint;
        [DisplayName("血气时间点"),Browsable(false)]
        public DateTime TimePoint
        {
            get { return timePoint; }
            set { timePoint = value; }
        }

        private string detailId;
        [DisplayName("血气Id"), Browsable(false)]
        public string DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }

        public override string ToString()
        {
            return showText;
        }
    }
}
