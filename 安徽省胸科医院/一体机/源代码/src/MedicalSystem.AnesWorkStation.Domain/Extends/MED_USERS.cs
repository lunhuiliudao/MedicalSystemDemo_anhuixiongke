using System;
using System.Collections.Generic;
using Dapper.Data;
using MDSD.Permission.Domain;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_USERS
    {
        [NotMapped]
        public string DEPT_NAME { get; set; }
        [NotMapped]
        public List<Permission.DataServices.Domain.MDSD_ACTION> MDSD_ACTION { get; set; }
        [NotMapped]
        public Permission.DataServices.Domain.MDSD_APPLICATION MDSD_APPLICATION { set; get; }

        /// <summary>
        /// 用户科室名称
        /// </summary>
        [NotMapped]
        public string Dept_Name { get; set; }
        /// <summary>
        /// 用户工作角色
        /// </summary>
        [NotMapped]
        public string USER_JOB { get; set; }
        ///// <summary>
        ///// 用户权限角色
        ///// </summary>
        //[NotMapped]
        //public string USER_ROLE { get; set; }

        /// <summary>
        /// 用户权限角色
        /// </summary>
        private string user_role;

        [NotMapped]
        public string USER_ROLE
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.user_role))
                {
                    return this.USER_JOB;
                }
                return this.user_role;
            }
            set
            {
                this.user_role = value;
            }
        }

        /// <summary>
        /// 是否具有主任权限
        /// </summary>
        [NotMapped]
        public bool IsDirector { get; set; }
        /// <summary>
        /// 平台菜单列表
        /// </summary>
        [NotMapped]
        public string Menus { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        [NotMapped]
        public string Token { get; set; }
        /// <summary>
        /// 原始密码
        /// </summary>
        [NotMapped]
        public string OLD_LOGIN_PWD { get; set; }
        /// <summary>
        /// 权限菜单
        /// </summary>
        [NotMapped]
        public dynamic MenuList { get; set; }
    }
}
