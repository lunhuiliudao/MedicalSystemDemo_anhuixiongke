using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 登录用户信息表
    /// </summary>
    public partial class MED_BILL_TEMPLET_MASTER
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TEMPLET { get; set; }

        /// <summary>
        /// 模板分类
        /// </summary>
        public string TEMPLET_CLASS { get; set; }

        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
    }
}
