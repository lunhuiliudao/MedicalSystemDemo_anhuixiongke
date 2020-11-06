//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      BloodGasAnalysisControl.cs
//功能描述(Description)：    血气转换类，提供界面显示
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/26 14:58
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Linq;
using System.Windows.Data;

namespace MedicalSystem.AnesWorkStation.View.Converters
{
    public class BloodGasAnalysisControl : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;
            if (null != value)
            {
                MED_HIS_USERS tempUser = ApplicationModel.Instance.AllDictList.HisUsersList.FirstOrDefault(x => x.USER_JOB_ID.Equals(value.ToString()));
                if (null != tempUser)
                {
                    result = tempUser.USER_NAME;
                }
                else
                {
                    result = value.ToString();
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
