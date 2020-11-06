using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class CommonFun
    {
        /// <summary>
        /// 以"'"切分返回数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] StringSplitToArr(string str)
        {
            return str.Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 九宫格拼音排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetListIndex(List<string> list, string str)
        {
            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (GetCount(str) > GetCount(list[i]))
                {
                    result = i;
                    break;
                }
                else
                {
                    result = i;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取音节段个数，用“'”切分
        /// </summary>
        /// <param name="value">拼音字符串</param>
        /// <returns></returns>
        public static int GetCount(string value)
        {
            int result = 0;
            char[] temp = value.ToArray();
            foreach (char item in temp)
            {
                if (item.ToString() == "'")
                {
                    result++;
                }
            }
            return result;
        }


        /// <summary>
        /// 内容匹配完全相同
        /// </summary>
        /// <param name="sourse">字典数据</param>
        /// <param name="value">录入数据</param>
        /// <returns></returns>
        public static bool IsEque(string[] sourse, string[] value)
        {
            bool result = false;
            int count = sourse.Length < value.Length ? sourse.Length : value.Length;

            for (int i = 0; i < count; i++)
            {
                if (sourse[i] == value[i])//全字匹配
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 内容匹配 词语首字母完全匹配
        /// </summary>
        /// <param name="sourse">字典数据</param>
        /// <param name="value">录入数据</param>
        /// <returns></returns>
        public static bool IsStartEque(string[] sourse, string[] value)
        {
            bool result = false;
            int count = sourse.Length < value.Length ? sourse.Length : value.Length;

            for (int i = 0; i < count; i++)
            {
                if (sourse[i].StartsWith(value[i]))//首字母包含
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 内容匹配第一个首字母完全匹配
        /// </summary>
        /// <param name="sourse">字典数据</param>
        /// <param name="value">录入数据</param>
        /// <returns></returns>
        public static bool IsLess(string[] sourse, string[] value)
        {
            bool result = false;
            int count = sourse.Length < value.Length ? sourse.Length : value.Length;

            //for (
            int i = 0;// i < count; i++)
            //{
            if (sourse[i].StartsWith(value[i]))//首字母包含
            {
                result = true;
                //break;
            }
            //else
            //{
            //    break;
            //}
            //}
            return result;
        }
        /// <summary>
        /// 判断是否为有效音节
        /// </summary>
        /// <returns></returns>
        public static bool IsTrueYinJie(string value, string inputstr)
        {
            bool result = true;
            bool resultValue = true;
            bool resultAll = true;
            string tempStr = value + inputstr;
            for (int i = 0; i < Syllable.YinJieArr.Length; i++)
            {
                if (Syllable.YinJieArr[i].Length > value.Length && Syllable.YinJieArr[i].StartsWith(value))
                {
                    resultValue = false;
                    break;
                }
            }

            for (int i = 0; i < Syllable.YinJieArr.Length; i++)
            {
                if (Syllable.YinJieArr[i].Length >= tempStr.Length && Syllable.YinJieArr[i].StartsWith(tempStr))
                {
                    resultAll = false;
                    break;
                }
            }
            if (!resultValue && !resultAll)
            {
                result = false;
            }
            return result;
        }



        /// <summary>
        /// 判断是否为有效音节
        /// </summary>
        /// <returns></returns>
        public static bool IsTrueYinJie(string value)
        {
            for (int i = 0; i < Syllable.YinJieArr.Length; i++)
            {
                if (Syllable.YinJieArr[i] == value)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断是否是声母
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsShenMu(string value)
        {
            bool result = false;
            for (int i = 0; i < Syllable.ShenMu.Length; i++)
            {
                if (Syllable.ShenMu[i] == value)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 判断是否是韵母单字 1包含 2相等
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IsyYunMuZi(string value)
        {
            int result = 0;
            for (int i = 0; i < Syllable.YunMuZi.Length; i++)
            {
                if (Syllable.YunMuZi[i] == value)
                {
                    result = 2;
                    break;
                }
                else if (Syllable.YunMuZi[i].StartsWith(value))
                {
                    result = 1;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 是否包含音节的一部分
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTrueYinJieContains(string value)
        {
            bool result = false;

            for (int i = 0; i < Syllable.YinJieArr.Length; i++)
            {
                if (Syllable.YinJieArr[i].StartsWith(value))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// 接受输入音节进行切分
        /// </summary>
        /// <param name="inputStr">输入字符</param>
        /// <param name="allstr">CN字符串</param>
        /// <returns></returns>
        public static string GetEnterPinyin(string inputStr, string allstr)
        {
            string[] temp = CommonFun.StringSplitToArr(allstr);
            string value = temp.Length > 0 ? temp[temp.Length - 1] : "";//CN分割最后一组
            bool tempSheMu = CommonFun.IsShenMu(inputStr);//当前输入声母
            bool oldSheMu = CommonFun.IsShenMu(value);//最后组声母
            int tempYunMuZi = CommonFun.IsyYunMuZi(value + inputStr);//单字韵母
            if (tempYunMuZi == 1)//韵母制定汉字包含
            {
                allstr += inputStr;
            }
            else if (tempYunMuZi == 2)//韵母制定汉字匹配
            {
                allstr += inputStr;
            }
            else if (tempSheMu && oldSheMu)//多个声母组合
            {
                allstr += "'" + inputStr;
            }
            else
            {
                string last = value.Length > 0 ? value.Substring(value.Length - 1) : "";
                if (last == "g" || last == "r" || last == "n")
                {
                    string moveLast = value.Substring(0, value.Length - 1);
                    //特殊符前面的音节有效果，并且与最后一位能够组成有效音节
                    if (!string.IsNullOrEmpty(moveLast) && CommonFun.IsTrueYinJieContains(moveLast) && CommonFun.IsTrueYinJieContains(last + inputStr))
                    {
                        allstr = allstr.Insert(allstr.Length - 1, "'");
                        allstr += inputStr;
                        return allstr;
                    }
                }

                bool isYinJie = CommonFun.IsTrueYinJie(value, inputStr);
                if (isYinJie)
                {
                    allstr += "'" + inputStr;
                }
                else
                {
                    allstr += inputStr;
                }
            }
            return allstr;
        }
        /// <summary>
        ///二分查找关键字key是否在查找表arr中存在，若存在，返回索引号，否则返回-1;
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int FindIndex(string[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (key == CommonFun.GetCount(arr[mid]))
                    return mid;
                else if (key < CommonFun.GetCount(arr[mid]))
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return low == arr.Length ? arr.Length : low;
        }

        /// <summary>
        ///二分查找关键字key是否在查找表arr中存在，若存在，返回索引号，否则返回-1;
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int FindIndex(List<string> list, int key)
        {
            int low = 0;
            int high = list.Count - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (key == CommonFun.GetCount(list[mid]))
                    return mid;
                else if (key < CommonFun.GetCount(list[mid]))
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return low == list.Count ? list.Count : low;
        }
    }
}
