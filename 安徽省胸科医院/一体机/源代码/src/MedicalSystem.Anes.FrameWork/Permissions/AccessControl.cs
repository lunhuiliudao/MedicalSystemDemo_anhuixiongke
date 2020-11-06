using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class AccessControl
    {
        public static bool IsAuthorized(string functionName)
        {
            return true;
        }
        /// <summary>
        /// 权限具体处理
        /// </summary>
        private static PermissionProvider _permissionCustom = new PermissionProvider();

        public static PermissionProvider PermissionProviderCustom
        {
            get { return AccessControl._permissionCustom; }
            set { AccessControl._permissionCustom = value; }
        }



        /// <summary>
        /// 增加权限
        /// </summary>
        /// <param name="permissionKey">权限关键字</param>
        /// <param name="value">是否拥有权限</param>
        /// <returns>增加成功返回真，失败返回假</returns>
        public static bool AddPermission(string permissionKey, string type)
        {
            bool result = false;
            if (!ExtendApplicationContext.Current.PermissionContext.Permissions.ContainsKey(permissionKey.ToUpper()))
            {
                ExtendApplicationContext.Current.PermissionContext.Permissions.Add(permissionKey.ToUpper(), type);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 校验是否拥有某权限
        /// </summary>
        /// <param name="permissionKey">权限名称</param>
        /// <returns>拥有权限返回真否则返回假</returns>
        public static bool CheckPermission(string permissionKey)
        {
            if (ExtendApplicationContext.Current.LoginUser.isMDSD) return true;
            bool result = false;

            if (ExtendApplicationContext.Current.PermissionContext.Permissions.ContainsKey(permissionKey.ToUpper()))
            {
                result = true;
            }
            return result;
        }


        /// <summary>
        /// 核查权限
        /// </summary>
        /// <returns></returns>
        public static PermissionContext.RightType CheckRight(string text)
        {
            return AccessControl.PermissionProviderCustom.CheckRight(text);
        }

        /// <summary>
        /// 核查病案归档后医疗文书是否可修改
        /// </summary>
        /// <returns></returns>
        public static bool CheckDoneDocumentRight()
        {
            return AccessControl.PermissionProviderCustom.CheckDoneDocumentRight();
        }
        /// <summary>
        /// 常用按钮-检查是否有编辑权限
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool CheckModifyRight(string text)
        {
            return AccessControl.PermissionProviderCustom.CheckModifyRight(text);
        }


        /// <summary>
        /// 常用按钮-检查是否有浏览权限
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool CheckBrowseRight(string text)
        {
            return AccessControl.PermissionProviderCustom.CheckBrowseRight(text);
        }

        /// <summary>
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey">文书名</param>
        /// <param name="operationMasterRow">当前用户 麻醉主记录</param>
        /// <param name="anesOperHandoverRow">当前用户 交班记录</param>
        /// <returns></returns>
        public static PermissionContext.RightType GetDocRightTypeForOperator(string rightKey)
        {
            return AccessControl.PermissionProviderCustom.GetDocRightTypeForOperator(rightKey);
        }

        /// <summary>
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey">文书名</param>
        /// <param name="operationMasterRow">当前用户 麻醉主记录</param>
        /// <param name="anesOperHandoverRow">当前用户 交班记录</param>
        /// <returns></returns>
        public static bool CheckModifyRightForOperator(string rightKey)
        {
            return AccessControl.PermissionProviderCustom.CheckModifyRightForOperator(rightKey);
        }
        /// <summary>
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey">文书名</param>
        /// <param name="operationMasterRow">当前用户 麻醉主记录</param>
        /// <param name="anesOperHandoverRow">当前用户 交班记录</param>
        /// <returns></returns>
        public static bool CheckBrowseRightForOperator(string rightKey)
        {
            return AccessControl.PermissionProviderCustom.CheckBrowseRightForOperator(rightKey);
        }
        /// <summary>
        /// 
        /// </summary>

        /// <returns></returns>
        public static bool CheckModifyPrintedDoc()
        {
            return AccessControl.PermissionProviderCustom.CheckModifyPrintedDoc();
        }
    }
}
