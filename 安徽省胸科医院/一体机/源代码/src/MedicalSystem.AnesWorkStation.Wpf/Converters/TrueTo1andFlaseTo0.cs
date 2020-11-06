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
    /// 0或1分别代表False和True
    /// </summary>
    public class TrueTo1andFlaseTo0 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            // 值
            int numToTrueOrFalse = 0;
            int.TryParse(value.ToString(), out numToTrueOrFalse);
            // 偏移量
            int offset = 0;
            if (parameter != null)
            {
                int.TryParse(parameter.ToString(), out offset);
            }

            if ((numToTrueOrFalse - offset) == 1)
            {
                return true;
            }
            else if ((numToTrueOrFalse - offset) == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            bool trueOrFalseToNum=false;
            trueOrFalseToNum = (bool)value;
            // 偏移量
            int offset = 0;
            if (parameter != null)
            {
                int.TryParse(parameter.ToString(), out offset);
            }
            if (trueOrFalseToNum)
            {
                return 1 + offset;
            }
            else
            {
                return 0 + offset;
            }
        }
    }
}
