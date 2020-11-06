using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.Wpf.Converters
{
    /// <summary>
    /// 急诊择期转化为数字
    /// </summary>
    public class PlanWhereAbortsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string emergencyCode = value.ToString();
            if (emergencyCode == "40")
            {
                return "恢复室";
            }
            else if (emergencyCode == "60")
            {
                return "病房";
            }
            else if (emergencyCode == "65")
            {
                return "ICU";
            }
            else if (emergencyCode == "66")
            {
                return "急诊";
            }
            else if (emergencyCode == "67")
            {
                return "离院";
            }
            else
            {
                return "无计划";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string emergencyCode = value.ToString();
            if (emergencyCode == "恢复室")
            {
                return "40";
            }
            else if (emergencyCode == "病房")
            {
                return "60";
            }
            else if (emergencyCode == "ICU")
            {
                return "65";
            }
            else if (emergencyCode == "急诊")
            {
                return "66";
            }
            else if (emergencyCode == "离院")
            {
                return "67";
            }
            else
            {
                return "";
            }
        }
    }
}
