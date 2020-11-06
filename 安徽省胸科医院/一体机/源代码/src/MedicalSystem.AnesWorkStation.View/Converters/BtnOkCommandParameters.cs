//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      BtnOkCommandParameters.cs
//功能描述(Description)：    手术取消转换类，提供界面显示
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/26 14:58
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Wpf.Helper;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    public class BtnOkCommandParameters : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Dictionary<string, string> parames = new Dictionary<string, string>();
            if(values.Length == 4)
            {
                string strReason = values[0].ToString();
                parames.Add("取消原因", strReason);

                for (int i = 1; i < values.Length; i++)
                {
                    string strInfo = string.Empty;
                    Grid grid = values[i] as Grid;
                    List<CheckBox> tempList = VisualTreeFinder.GetChildObjects<CheckBox>(grid, typeof(CheckBox));
                    foreach(CheckBox cb in tempList)
                    {
                        if((bool)cb.IsChecked)
                        {
                            strInfo += cb.Content.ToString() + ",";
                        }
                    }

                    parames.Add(grid.Name, strInfo);
                }
            }

            return parames;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
