using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.Wpf.Converters
{
    public class ItemClassConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string itemClass = value.ToString();
            if (itemClass == "1")
            {
                return "事件";
            }
            else if (itemClass == "2")
            {
                return "麻药";
            }
            else if (itemClass == "3")
            {
                return "输液";
            }
            else if (itemClass == "4")
            {
                return "输氧";
            }
            else if (itemClass == "5")
            {
                return "手术";
            }
            else if (itemClass == "7")
            {
                return "插管";
            }
            else if (itemClass == "8")
            {
                return "拔管";
            }
            else if (itemClass == "9")
            {
                return "辅助呼吸";
            }
            else if (itemClass == "A")
            {
                return "控制呼吸";
            }
            else if (itemClass == "B")
            {
                return "输血";
            }
            else if (itemClass == "C")
            {
                return "用药";
            }
            else if (itemClass == "D")
            {
                return "出液";
            }
            else if (itemClass == "Y")
            {
                return "呼吸";
            }
            else if (itemClass == "O")
            {
                return "附记项目";
            }
            else if (itemClass == "Z")
            {
                return "其他";
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string itemClassName = value.ToString();
            if (itemClassName == "事件")
            {
                return "1";
            }
            else if (itemClassName == "麻药")
            {
                return "2";
            }
            else if (itemClassName == "输液")
            {
                return "3";
            }
            else if (itemClassName == "输氧")
            {
                return "4";
            }
            else if (itemClassName == "手术")
            {
                return "5";
            }
            else if (itemClassName == "插管")
            {
                return "7";
            }
            else if (itemClassName == "拔管")
            {
                return "8";
            }
            else if (itemClassName == "辅助呼吸")
            {
                return "9";
            }
            else if (itemClassName == "控制呼吸")
            {
                return "A";
            }
            else if (itemClassName == "输血")
            {
                return "B";
            }
            else if (itemClassName == "用药")
            {
                return "C";
            }
            else if (itemClassName == "出液")
            {
                return "D";
            }
            else if (itemClassName == "呼吸")
            {
                return "Y";
            }
            else if (itemClassName == "附记项目")
            {
                return "O";
            }
            else if (itemClassName == "其他")
            {
                return "Z";
            }
            else
                return null;
        }
    }
}
