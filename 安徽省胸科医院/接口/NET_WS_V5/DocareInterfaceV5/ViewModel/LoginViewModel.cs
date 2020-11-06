using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace  ViewModel
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "登陆账号")]
        public string LogId
        {

            get;
            set;
        }

        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}