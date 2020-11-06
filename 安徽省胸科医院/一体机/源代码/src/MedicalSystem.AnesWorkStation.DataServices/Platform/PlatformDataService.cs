using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 数据服务
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// 获取当前程序集信息
        /// </summary>
        /// <returns></returns>
        public static Assembly GetExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
