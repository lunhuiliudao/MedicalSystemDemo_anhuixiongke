using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entitys
{
    public class MedIfTrans
    {
        [Required]
        [Display(Name = "数据源名称")]
        public string TransName { get; set; }

        [Required]
        [Display(Name ="数据类型")]
        public string DBMS { get; set; }

        [Required]
        [Display(Name = "服务名")]
        public string ServerName { get; set; }

        [Display(Name="数据库名称")]
        public string DataBase { get; set; }

        [Required]
        [Display(Name = "登陆账号")]
        public string LogId { get; set; }

        [Required]
        [Display(Name = "登陆密码")]
        public string LogPass { get; set; }

        public string NlsLang { get; set; }

        public string DbParm { get; set; }

        public string Memo { get; set; }
    }
}