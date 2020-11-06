// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      BoolToVisibilityConvert.cs
// 功能描述(Description)：    转换器：根据true/false转换成Visibility枚举
// 数据表(Tables)：		      孙家富
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.View.WorkList.Convert
{
    public class BoolToVisibilityConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = Visibility.Visible;
            if (null != value && value is bool)
            {
                bool text = (bool)value;
                if (!text)
                {
                    result = Visibility.Collapsed;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}