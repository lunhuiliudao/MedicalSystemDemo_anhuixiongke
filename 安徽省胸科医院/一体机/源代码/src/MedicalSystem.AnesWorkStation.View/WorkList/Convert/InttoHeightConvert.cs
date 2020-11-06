// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      InttoHeightConvert.cs
// 功能描述(Description)：    转换器：根据StepIndex转换成对应的控件高度
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
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    public  class InttoHeightConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (int)value;
            if (text == 0)
            {
                return 0;
            }
            else if (text == 5)
            {
                return 750;
            }
            else
            {
                return text * 145;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
