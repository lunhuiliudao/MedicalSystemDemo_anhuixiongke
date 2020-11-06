using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.AppPC
{
    /// <summary>
    /// 主窗口定时器
    /// </summary>
    public interface ITimeTick
    {
        /// <summary>
        /// 每秒刷新
        /// </summary>
        void OnTicked();
    }
}
