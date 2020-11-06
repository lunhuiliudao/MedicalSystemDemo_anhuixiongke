using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_USERS_SCHEDULE : BaseModel
    {
        /// <summary>
        /// 用户科室代码
        /// </summary>
        [NotMapped]
        public string Dept_Name { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        [NotMapped]
        public string USER_JOB { get; set; }

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
    }
}
