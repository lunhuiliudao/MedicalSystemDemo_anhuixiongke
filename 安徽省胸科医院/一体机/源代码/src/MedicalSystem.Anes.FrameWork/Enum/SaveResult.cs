﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{
    public enum SaveResult
    {
        /// <summary>
        /// 保存成功提示
        /// </summary>
        Success,
        /// <summary>
        /// 保存失败提示
        /// </summary>
        Fail,
        /// <summary>
        /// 取消操作
        /// </summary>
        Cancel,
        /// <summary>
        /// 不显示提示框
        /// </summary>
        CancelMessageBox,
    }
}
