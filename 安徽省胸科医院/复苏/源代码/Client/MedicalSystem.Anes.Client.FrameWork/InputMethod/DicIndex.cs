using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// 字库索引
    /// </summary>
    public class DicIndex
    {

        public DicIndex(string _FileName, string _StartStr, int _StartIndex, int _EndIndex)
        {
            FileName = _FileName;
            StartStr = _StartStr;
            StartIndex = _StartIndex;
            EndIndex = _EndIndex;
        }
        /// <summary>
        /// 词库名称
        /// </summary>
        public string FileName { set; get; }
        /// <summary>
        /// 开始字符
        /// </summary>
        public string StartStr { set; get; }
        /// <summary>
        /// 开始索引
        /// </summary>
        public int StartIndex { set; get; }
        /// <summary>
        /// 结束索引
        /// </summary>
        public int EndIndex { set; get; }
    }
}
