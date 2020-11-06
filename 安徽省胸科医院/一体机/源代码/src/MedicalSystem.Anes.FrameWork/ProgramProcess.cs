using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{
    /// 程序状态
    /// </summary>
    public enum ProgramProcess
    {
        /// <summary>
        /// 系统刚启动
        /// </summary>
        SystemStart,
        /// <summary>
        /// 系统登陆前启动
        /// </summary>
        SystemBeforeLogin,
        /// <summary>
        /// 登陆失败
        /// </summary>
        SystemLoginErr,
        /// <summary>
        /// 登陆成功
        /// </summary>
        SystemLoginOK,
        /// <summary>
        /// 系统初始化
        /// </summary>
        SystemBeforeLoad,
        /// <summary>
        /// 系统初始化数据成功
        /// </summary>
        SystemAfterLoad,

    }
}
