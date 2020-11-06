//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      DynamicPathConverter.cs
//功能描述(Description)：    转换类，提供界面显示，根据体征图标对象，返回图标的绘制路径
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
using System.Drawing;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    public class DynamicPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var pathmodel = value as SymbolModel;
            if (pathmodel != null)
            {
                SolidBrush brush = (SolidBrush)pathmodel.Brush;
                System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(brush.Color.R, brush.Color.G, brush.Color.B);
                Path path = Symbol.MakePath(pathmodel.SymbolType, new System.Windows.Point(0, 0), new System.Windows.Size(20, 20), color,Colors.White);
                Geometry g = path.Data;
                return path.Data;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
