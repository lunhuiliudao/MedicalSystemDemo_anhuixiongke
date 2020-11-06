using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork.Enum
{
    /// <summary>
    /// 登录枚举
    /// </summary>
    public enum EnumLoginType
    {
        /// <summary>
        /// 正常登录
        /// </summary>
        [Description("正常登录")]
        NormalLogin = 1,

        /// <summary>
        /// 锁屏
        /// </summary>
        [Description("锁屏")]
        LockScreen = 2,

        /// <summary>
        /// 注销当前用户
        /// </summary>
        [Description("注销当前用户")]
        Logout = 3,

        /// <summary>
        /// 关闭计算机
        /// </summary>
        [Description("关闭计算机")]
        ShutDown = 4,

        /// <summary>
        /// 已经登录
        /// </summary>
        [Description("已经登录")]
        Logined = 5,
    }
}
