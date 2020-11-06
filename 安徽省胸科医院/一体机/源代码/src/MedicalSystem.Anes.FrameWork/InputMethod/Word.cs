using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class Word
    {
        public Word()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Key"> 全体内容</param>
        /// <param name="_PinYinArr"> 拼音数组</param>
        /// <param name="_PinYinStr">拼音串</param>
        /// <param name="_Words">词</param>
        /// <param name="_Counts">词频</param>
        public Word(string _Key, string[] _PinYinArr, string _PinYinStr, string _Words, int _Counts)
        {
            Key = _Key;
            PinYinArr = _PinYinArr;
            PinYinStr = _PinYinStr;
            Words = _Words;
            Counts = _Counts;
        }

        /// <summary>
        /// 默认字典内容
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 拼音数组
        /// </summary>
        public string[] PinYinArr { set; get; }
        /// <summary>
        /// 拼音串
        /// </summary>
        public string PinYinStr { set; get; }
        /// <summary>
        /// 词
        /// </summary>
        public string Words { set; get; }
        /// <summary>
        /// 词频
        /// </summary>
        public int Counts { set; get; }
    }
}
