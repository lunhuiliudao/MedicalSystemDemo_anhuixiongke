//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      DynamicPathMarginConverter.cs
//功能描述(Description)：    转换类，提供界面显示
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:35
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.View.AnesGraph;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    public class DynamicPathMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var pathmodel = value as SymbolModel;
            if (pathmodel != null)
            {
                Path path = Symbol.MakePath(pathmodel.SymbolType, new System.Windows.Point(0, 0), new System.Windows.Size(20, 20), Colors.White, Colors.White);
                Geometry g = path.Data;
                Rect rect = g.Bounds;
                return new Thickness(Math.Abs(rect.Left), Math.Abs(rect.Top), 0, 0);
            }

            return new Thickness(0, 0, 0, 0);;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
