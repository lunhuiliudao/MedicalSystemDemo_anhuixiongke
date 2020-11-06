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
    public class EmergencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string emergencyCode = value.ToString();
            if (emergencyCode == "1")
            {
                return "急诊";
            }
            else if (emergencyCode == "0")
            {
                return "择期";
            }

            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string emergencyCode = value.ToString();
            if (emergencyCode == "急诊")
            {
                return "1";
            }
            else if (emergencyCode == "择期")
            {
                return "0";
            }

            else
            {
                return string.Empty;
            }
        }
    }
}
