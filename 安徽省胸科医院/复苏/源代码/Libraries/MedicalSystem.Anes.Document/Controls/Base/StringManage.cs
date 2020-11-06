using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 字符串处理
    /// </summary>
    public class StringManage
    {
        /// <summary>
        /// 汉字转拼音缩写        
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <returns>拼音缩写</returns>
        public static String GetPYString(String str)
        {
            String TempStr = "";
            foreach (char Chr in str)
            {
                if ((int)Chr >= 33 && (int)Chr <= 126)
                {
                    //字母和符号原样保留
                    TempStr += Chr.ToString();
                }
                else if ((int)Chr == 12288)
                {
                    //将全角空格转换为半角空格
                    TempStr += (char)32;
                }
                else if ((int)Chr > 65280 && (int)Chr < 65375)
                {
                    //将全角符号转换为半角符号
                    TempStr += (char)((int)Chr - 65248);
                }
                else
                {//累加拼音声母
                    TempStr += GetPYChar(Chr.ToString());
                }
            }
            return TempStr;
        }
        /// <summary>
        /// 汉字转拼音缩写        
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <param name="maxLength">转换的最大长度</param>
        /// <returns>拼音缩写</returns>
        public static String GetPYString(String str, int maxLength)
        {
            String TempStr = "";
            TempStr = GetPYString(str);
            if (TempStr.Length > maxLength)
            {
                TempStr = TempStr.Substring(0, 8);
            }
            return TempStr;
        }

        public static bool IsChinese(string str)
        {
            return str.CompareTo("吖") >= 0;
        }

        /// <summary>
        /// 取单个字符的拼音声母        
        /// </summary>
        /// <param name="c">要转换的单个汉字</param>
        /// <returns>拼音声母</returns>
        public static String GetPYChar(String str)
        {
            if (str.CompareTo("吖") < 0) return str;
            if (str.CompareTo("八") < 0) return "A";
            if (str.CompareTo("嚓") < 0) return "B";
            if (str.CompareTo("咑") < 0) return "C";
            if (str.CompareTo("妸") < 0) return "D";
            if (str.CompareTo("发") < 0) return "E";
            if (str.CompareTo("旮") < 0) return "F";
            if (str.CompareTo("铪") < 0) return "G";
            if (str.CompareTo("讥") < 0) return "H";
            if (str.CompareTo("咔") < 0) return "J";
            if (str.CompareTo("垃") < 0) return "K";
            if (str.CompareTo("嘸") < 0) return "L";
            if (str.CompareTo("拏") < 0) return "M";
            if (str.CompareTo("噢") < 0) return "N";
            if (str.CompareTo("妑") < 0) return "O";
            if (str.CompareTo("七") < 0) return "P";
            if (str.CompareTo("亽") < 0) return "Q";
            if (str.CompareTo("仨") < 0) return "R";
            if (str.CompareTo("他") < 0) return "S";
            if (str.CompareTo("哇") < 0) return "T";
            if (str.CompareTo("夕") < 0) return "W";
            if (str.CompareTo("丫") < 0) return "X";
            if (str.CompareTo("帀") < 0) return "Y";
            if (str.CompareTo("咗") < 0) return "Z";
            return str;
        }
        #region 获取字符串的实际字节长度的方法
        /// <summary>
        /// 获取字符串的实际字节长度的方法
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>实际长度</returns>
        public static int GetRealLength(string source)
        {
            return Encoding.Default.GetByteCount(source);
        }
        #endregion

        #region 按字节数截取字符串的方法
        /// <summary>
        /// 按字节数截取字符串的方法
        /// </summary>
        /// <param name="source">要截取的字符串</param>
        /// <param name="n">要截取的字节数</param>
        /// <param name="needEndDot">是否需要结尾的省略号</param>
        /// <returns>截取后的字符串</returns>
        public static string SubString(string source, int n, bool needEndDot)
        {
            string Result = string.Empty;
            if (GetRealLength(source) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return source;
            }
            else
            {
                int j = 0;
                char[] ChrList = source.ToCharArray();
                for (int i = 0; i < ChrList.Length && j < n; i++)
                {

                    if ((int)ChrList[i] > 127)//是否汉字
                    {
                        Result += ChrList[i];
                        j += 2;
                    }
                    else
                    {
                        Result += ChrList[i];
                        j++;
                    }
                }
                if (GetRealLength(Result) > n)
                {
                    Result = Result.Remove(Result.Length - 1, 1);
                }
                if (needEndDot)
                    Result += "...";
                return Result;
            }
        }
        #endregion
    }
}
