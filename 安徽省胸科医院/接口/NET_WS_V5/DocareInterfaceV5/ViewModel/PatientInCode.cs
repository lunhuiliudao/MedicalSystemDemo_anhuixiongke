using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModel
{
    public class PatientInCode
    {
        [Display(Name = "患者ID")]
        public string PatientId { get; set; }

        [Display(Name = "住院次数")]
        public decimal? VisitId { get; set; }

        [Display(Name="住院号")]
        public string InpNo { get; set; }

        [Display(Name="功能编码")]
        public string Code { get; set; }

        [Display(Name="测试返回结果")]
        public string Result { get; set; }
    }
}