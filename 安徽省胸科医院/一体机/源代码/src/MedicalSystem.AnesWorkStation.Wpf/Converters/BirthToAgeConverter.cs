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
    public class BirthToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            DateTime birthDate = (DateTime)value;

            double age = DateTime.Now.Year - birthDate.Year;
            return age;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            
            return string.Empty;
            
        }
    }
}
