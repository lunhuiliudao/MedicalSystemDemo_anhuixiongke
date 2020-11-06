/**************************************************************************
模    块:        
项    目:        MedicalSystem.AnesPlatform.Domain.Utils
作    者:        zhaoerye是当前登录用户名
创建时间:        2018/12/21 12:57:06
Copyright (c)    2005 麦迪斯顿(北京)医疗科技发展有限公司
修改时间：       2018/12/21 12:57:06
修 改 人：       zhaoerye
描    述：       字符串工具类
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedicalSystem.AnesPlatform.Domain.Utils
{
   public class StringUtils
    {
        public StringUtils()
        {

        }
        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }
    }
}
