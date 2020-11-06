/*******************************
 * 文件名称：LoginUserModel.cs
 * 文件说明：登录用户的基本信息，因为不涉及交互功能，所以定义为普通实体类
 * 作    者：许文龙
 * 日    期：2017-04-13
 * *****************************/
using System;

namespace MedicalSystem.AnesWorkStation.Model
{
    /// <summary>
    /// 登录用户的基本信息
    /// </summary>
    public class LoginUserModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID;

        /// <summary>
        /// 医护人员工号	;	医护人员工号
        /// </summary>
        public string UserJobID;

        /// <summary>
        /// 登录名称	；	登录账号
        /// </summary>
        public string LoginName;

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd;

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 用户科室代码		对应科室代码表
        /// </summary>
        public string UserDeptCode;

        /// <summary>
        /// 建立日期
        /// </summary>
        public Nullable<DateTime> CreateDate;

        /// <summary>
        /// 停用标识	;	T 有效    F无效
        /// </summary>
        public string IsValid;

        /// <summary>
        /// 停用日期
        /// </summary>
        public Nullable<DateTime> StopDate;

        /// <summary>
        /// 描述	
        /// </summary>
        public string Memo;

        /// <summary>
        /// 登录模式;1-手术间模式，2-PACU模式,3-办公室模式
        /// </summary>
        public Nullable<Int32> RunMode;

        /// <summary>
        /// 登录位置信息说明;手术间模式下记录手术间号
        /// </summary>
        public string RunAddress;

        /// <summary>
        /// 是否是超级用户
        /// </summary>
        public bool IsMDSD;
    }
}
