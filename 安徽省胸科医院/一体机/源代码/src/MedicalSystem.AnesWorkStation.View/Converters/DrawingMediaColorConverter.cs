//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      DrawingMediaColorConverter.cs
//功能描述(Description)：    转换类，提供界面显示
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:35
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Globalization;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    public class DrawingMediaColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Drawing.Color? color = value as System.Drawing.Color?;

            if (color.HasValue)
            {
                return System.Windows.Media.Color.FromArgb(color.Value.A, color.Value.R, color.Value.G, color.Value.B);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Color? color = value as System.Windows.Media.Color?;

            if (color.HasValue)
            {
                return System.Drawing.Color.FromArgb(color.Value.A, color.Value.R, color.Value.G, color.Value.B);
            }
            else
            {
                return null;
            }
        }
    }
}
