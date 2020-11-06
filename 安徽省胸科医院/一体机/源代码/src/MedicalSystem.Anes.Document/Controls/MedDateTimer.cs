using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false), Description("日期控件")]
    public class MedDateTimer : DateTimePicker
    {
        private bool _isStart;
        [Description("是否开始时间")]
        public bool IsStart
        {
            get
            {
                return _isStart;
            }
            set
            {
                _isStart = value;
            }
        }
        private bool _isEnd;
        [Description("是否结束时间")]
        public bool IsEnd
        {
            get
            {
                return _isEnd;
            }
            set
            {
                _isEnd = value;
            }
        }
        private string _initValue = "0";
        [Description("初始值")]
        public string InitValue
        {
            get
            {
                return _initValue;
            }
            set
            {
                _initValue = value;
                if (string.IsNullOrEmpty(value))
                {
                    Value = DateTime.Today;
                }
                else
                {
                    string initValue = value.Trim().ToLower();
                    string format = "d";
                    if (initValue.EndsWith("m") || initValue.EndsWith("y") || initValue.EndsWith("h") || initValue.EndsWith("n"))
                    {
                        format = initValue.Substring(initValue.Length - 1);
                        initValue = initValue.Substring(0, initValue.Length - 1);
                    }
                    int tp = 0;
                    if (int.TryParse(initValue, out tp))
                    {
                        switch (format)
                        {
                            case "y":
                                Value = DateTime.Today.AddYears(tp);
                                break;
                            case "m":
                                Value = DateTime.Today.AddMonths(tp);
                                break;
                            case "h":
                                Value = DateTime.Now.AddHours(tp);
                                break;
                            case "n":
                                Value = DateTime.Now.AddMinutes(tp);
                                break;
                            default:
                                Value = DateTime.Today.AddDays(tp);
                                break;
                        }
                    }
                }                
            }
        }
    }
}
