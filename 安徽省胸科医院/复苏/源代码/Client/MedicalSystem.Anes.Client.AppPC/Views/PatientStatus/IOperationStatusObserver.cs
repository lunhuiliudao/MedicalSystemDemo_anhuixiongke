using MedicalSystem.Anes.Client.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.AppPC
{
    public interface IOperationStatusObserver
    {
        /// <summary>
        /// 设置手术状态,更新主界面
        /// </summary>
        /// <param name="operationStatus"></param>
        void NoifyOperationStatusChange(OperationStatus operationStatus);
        //手术状态时间改变,更新 文书
        void NoifyOperationTimeChange();

    }
}
