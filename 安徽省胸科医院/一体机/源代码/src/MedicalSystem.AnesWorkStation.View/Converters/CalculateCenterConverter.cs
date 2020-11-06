//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      CalculateCenterConverter.cs
//功能描述(Description)：    转换类，提供界面显示
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/26 14:58
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    public class CalculateCenterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal result;
            if(null != value && decimal.TryParse(value.ToString(), out result))
            {
                result = result / 2;
                return result;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
