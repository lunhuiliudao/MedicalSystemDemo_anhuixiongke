using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class PermissionContext
    {
        /// <summary>
        /// 权限列表
        /// </summary>
        private Hashtable _permissions = new Hashtable();
        /// <summary>
        /// 权限列表
        /// </summary>
        public Hashtable Permissions
        {
            get
            {
                return _permissions;

            }
            set
            {
                _permissions = value;
            }
        }

        public enum RightType
        {
            /// <summary>
            /// 无
            /// </summary>
            None = 1,
            /// <summary>
            /// 浏览
            /// </summary>
            Browse = 2,
            /// <summary>
            /// 修改
            /// </summary>
            Modify = 4,
            /// <summary>
            /// 导入
            /// </summary>
            Import = 16,
            /// <summary>
            /// 导出
            /// </summary>
            Export = 32,
        }

        #region "权限常用常量"
        /// <summary>
        /// 永久可修改医疗文书
        /// </summary>
        public const string MODIFYDOCUMENTFOREVER = "ModifyDocumentForver";
        /// <summary>
        /// 修改医疗文书
        /// </summary>
        public const string MODIFYDOCUMENT = "ModifyDocument";
        /// <summary>
        /// 麻醉记录数据维护
        /// </summary>
        public const string ANESRECORDOPER = "麻醉记录数据维护";
        /// <summary>
        /// 体征数据操作权限
        /// </summary>
        public const string MonitorDataEdit = "SignsDataManagement";
        /// <summary>
        /// 公有模板维护
        /// </summary>
        public const string PublicTempletEdit = "PublicTempletEdit";
        /// <summary>
        /// 系统锁定
        /// </summary>
        public const string LockSystem = "系统锁定";

        /// <summary>
        /// 修改已打印的文书
        /// </summary>
        public const string ModifyPrintedDoc = "修改已打印的文书";

        #endregion
    }
}
