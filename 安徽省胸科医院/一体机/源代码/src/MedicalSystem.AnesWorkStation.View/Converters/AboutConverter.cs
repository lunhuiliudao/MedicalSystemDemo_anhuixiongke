//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AboutConverter.cs
//功能描述(Description)：    转换类，提供界面显示
//数据表(Tables)：		     无
//作者(Author)：             许文龙
//日期(Create Date)：        2019-09-18 16:07
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    public class AboutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "Black";
            if (null != value && value is bool)
            {
                bool hasDif = (bool)value;
                result = hasDif ? "Red" : "Black";
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
