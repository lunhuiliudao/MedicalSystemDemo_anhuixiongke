using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 判断是否是一个窗口
    /// </summary>
    public interface IChildForm
    {
        bool IsForm { get; set; }
    }
}
