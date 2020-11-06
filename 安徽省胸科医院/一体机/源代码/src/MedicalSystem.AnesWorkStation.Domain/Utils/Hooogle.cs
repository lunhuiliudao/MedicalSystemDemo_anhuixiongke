/**************************************************************************
模    块:        
项    目:        MedicalSystem.AnesPlatform.Domain.Utils
作    者:        zhaoerye是当前登录用户名
创建时间:        2018/12/21 13:41:04
Copyright (c)    2005 麦迪斯顿(北京)医疗科技发展有限公司
修改时间：       2018/12/21 13:41:04
修 改 人：       zhaoerye
描    述：       Excel列字母与数字的转换
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedicalSystem.AnesPlatform.Domain.Utils
{
   public class Hooogle
    {

        #region - 由数字转换为Excel中的列字母 -

        public static int ToIndex(string columnName)
        {
            if (!Regex.IsMatch(columnName.ToUpper(), @"[A-Z]+")) { throw new Exception("invalid parameter"); }

            int index = 0;
            char[] chars = columnName.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                index += ((int)chars[i] - (int)'A' + 1) * (int)Math.Pow(26, chars.Length - i - 1);
            }
            return index - 1;
        }


        public static string ToName(int index)
        {
            if (index < 0) { throw new Exception("invalid parameter"); }

            List<string> chars = new List<string>();
            do
            {
                if (chars.Count > 0) index--;
                chars.Insert(0, ((char)(index % 26 + (int)'A')).ToString());
                index = (int)((index - index % 26) / 26);
            } while (index > 0);

            return String.Join(string.Empty, chars.ToArray());
        }
        #endregion
    }
}
