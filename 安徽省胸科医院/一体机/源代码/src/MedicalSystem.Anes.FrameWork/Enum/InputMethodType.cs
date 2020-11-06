using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{
    public class InputMethodType
    {
        /// <summary>
        /// 输入模式
        /// </summary>
        public enum InputType
        {
            /// <summary>
            /// 英文(小写)
            /// </summary>
            EN,
            /// <summary>
            /// 英文(大写)
            /// </summary>
            ENUpper,
            /// <summary>
            /// 中文全键盘
            /// </summary>
            CN,
            /// <summary>
            /// 中文九宫格
            /// </summary>
            CN9,
            /// <summary>
            /// 数字
            /// </summary>
            NO,
            /// <summary>
            /// 符号
            /// </summary>
            Symbol,
            /// <summary>
            /// 关闭输入法
            /// </summary>
            NULL,
        }
    }
}
