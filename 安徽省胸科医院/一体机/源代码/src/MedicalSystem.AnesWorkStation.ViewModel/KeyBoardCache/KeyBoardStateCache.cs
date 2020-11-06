using MedicalSystem.UsbKeyBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.ViewModel.Cache
{
    public class KeyBoardStateCache
    {
        /// <summary>
        /// 键盘驱动
        /// </summary>
        public static KeyBoardEvent KeyBoard { get; set; }
        /// <summary>
        /// 大写
        /// </summary>
        public static bool CapsLock { get; set; }
        /// <summary>
        /// 是否英文
        /// </summary>
        public static bool IsEN { get; set; }

        /// <summary>
        /// 按键堆栈
        /// </summary>
        public static Stack<string> AppCodeStack = new Stack<string>();

        /// <summary>
        /// 任意界面允许响应键盘
        /// </summary>
        public static string[] AppCodeEnable = new string[]
        {
            AppCode.Rescue,AppCode.PACU,AppCode.Coordination,
            AppCode.Back, AppCode.Save, AppCode.Print, AppCode.HOME,
            AppCode.TAB,AppCode.Insert,AppCode.Delete,            
            //AppCode.M8,
            AppCode.Symbol
        };
        /// <summary>
        /// 当前按下键盘Code
        /// </summary>
        public static string CurrentAppCode = string.Empty;

    }
}
