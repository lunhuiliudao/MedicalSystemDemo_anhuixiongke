using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entitys
{
    public class DataConfig
    {
        [Display(Name = "登录账号")]
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LoginName { get; set; }

        [Display(Name = "登录密码")]
        /// <summary>
        /// 默认登录密码
        /// </summary>
        public string LoginPwd { get; set; }

        [Display(Name = "Web服务地址A")]
        /// <summary>
        /// web服务A
        /// </summary>
        public string WebServerUrlA { get; set; }

        [Display(Name = "Web服务地址B")]
        /// <summary>
        /// web服务B
        /// </summary>
        public string WebServerUrlB { get; set; }

        [Display(Name = "Web服务地址C")]
        /// <summary>
        /// web服务C
        /// </summary>
        public string WebServerUrlC { get; set; }

        [Display(Name = "Web服务地址D")]
        /// <summary>
        /// web服务D
        /// </summary>
        public string WebServerUrlD { get; set; }

        [Display(Name = "Web服务地址E")]
        /// <summary>
        /// web服务e
        /// </summary>
        public string WebServerUrlE { get; set; }

        [Display(Name = "Web服务地址F")]
        /// <summary>
        /// web服务f
        /// </summary>
        public string WebServerUrlF { get; set; }

        [Display(Name = "数据库类型")]
        /// <summary>
        /// 数据库类型 ORACLE,OLEDB,SQLSERVER,MYSQL,
        /// </summary>
        public string DataServerType { get; set; }

        [Display(Name = "服务名")]
        /// <summary>
        /// sqlserver 的机器名或者Ip地址 ,oracle 的服务名
        /// </summary>
        public string ServerName { get; set; }

        [Display(Name = "数据库名称")]
        /// <summary>
        /// sqlserver 的数据库名称，oracle 为空
        /// </summary>
        public string DataBase { get; set; }

        [Display(Name = "数据库账号")]
        /// <summary>
        /// 账号
        /// </summary>
        public string UserId { get; set; }

        [Display(Name = "数据库密码")]
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

    }
}
