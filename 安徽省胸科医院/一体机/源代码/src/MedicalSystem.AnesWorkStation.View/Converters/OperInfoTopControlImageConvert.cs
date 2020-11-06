//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperInfoTopControlImageConvert.cs
//功能描述(Description)：    转换类，提供界面显示
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:35
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.FrameWork;
using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    /// <summary>
    /// 该转换器是判断选中的手术间和当前一体机所在的手术间是否一致
    /// </summary>
    public class OperInfoTopControlImageConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage map = new BitmapImage(new Uri(@"/MedicalSystem.AnesWorkStation.View;component/Images/oproomnormal.png", UriKind.RelativeOrAbsolute));
            if (values == null || values.Length != 2)
            {
                return map;
            }

            // 要显示的手术间
            string strOperRoomNo = values[0].ToString();     
            // 当前显示的手术间
            string strCurSelectOperRoomNo = values[1].ToString();

            if (ExtendAppContext.Current.OperRoomNo.Equals(strOperRoomNo) && ExtendAppContext.Current.OperRoomNo.Equals(strCurSelectOperRoomNo))
            {
                // 当前选中的手术间是全局变量
                return new BitmapImage(new Uri(@"/MedicalSystem.AnesWorkStation.View;component/Images/ExtendAppContentOperRoomNoCheck.png", UriKind.RelativeOrAbsolute));
            }
            else if(ExtendAppContext.Current.OperRoomNo.Equals(strOperRoomNo))
            {
                return new BitmapImage(new Uri(@"/MedicalSystem.AnesWorkStation.View;component/Images/ExtendAppContentOperRoomNo.png", UriKind.RelativeOrAbsolute));
            }
            else if (strOperRoomNo.Equals(strCurSelectOperRoomNo))
            {
                return new BitmapImage(new Uri(@"/MedicalSystem.AnesWorkStation.View;component/Images/oproomnormalchecked.png", UriKind.RelativeOrAbsolute));
            }

            return map;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
