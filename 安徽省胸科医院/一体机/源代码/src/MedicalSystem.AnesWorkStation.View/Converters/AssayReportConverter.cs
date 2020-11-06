//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AssayReportConverter.cs
//功能描述(Description)：    检验转换类，提供界面显示
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
    public class AssayReportConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strSymbol = string.Empty;
            try
            {
                if (values.Length == 2)
                {
                    // 检验结果
                    string strResult = values[0].ToString();
                    // 参考值
                    string strReferenceResult = values[1].ToString();
                    string[] strRefResultArr = strReferenceResult.Split(new string[] { "～" }, StringSplitOptions.RemoveEmptyEntries);
                    decimal result = 0;     // 检验结果
                    decimal refResMin = 0;  // 参考值最小值
                    decimal refResMax = 0;  // 参考值最大值
                    if (decimal.TryParse(strResult, out result) && strRefResultArr.Length == 2 &&
                        decimal.TryParse(strRefResultArr[0], out refResMin) &&
                        decimal.TryParse(strRefResultArr[1], out refResMax))
                    {
                        if (result < refResMin)           // 偏低
                        {
                            strSymbol = "↓";
                        }
                        else if (result > refResMax)      // 偏高
                        {
                            strSymbol = "↑";
                        }
                    }
                }
            }
            catch
            { 
            }

            return strSymbol;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
