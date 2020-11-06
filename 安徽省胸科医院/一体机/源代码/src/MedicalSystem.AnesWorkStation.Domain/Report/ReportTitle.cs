//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      ReportInformation.cs
//功能描述(Description)：    
//数据表(Tables)：		     
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/8/31 16:18:03
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace MedicalSystem.AnesWorkStation.Domain.Report
{
    [DataContract]
    public class ReportTitle
    {
        /// <summary>
        /// 报表名称
        /// </summary>
        [DataMember]
        public string ReportName { get; set; }
        /// <summary>
        /// 所属菜单
        /// </summary>
        [DataMember]
        public string Menu { get; set; }
        /// <summary>
        /// SQL语句
        /// </summary>
        [DataMember]
        public string StrSql { get; set; }
        /// <summary>
        /// 每页行数
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        [DataMember]
        public string Meno { get; set; }
        /// <summary>
        /// 报表排序编号
        /// </summary>
        [DataMember]
        public int SortNumber { get; set; }
        /// <summary>
        /// 导出模板名称
        /// </summary>
        [DataMember]
        public string ModelFileName { get; set; }

        /// <summary>
        /// 是否显示合计
        /// </summary>
        [DataMember]
        public bool ShowSummary { get; set; }

        /// <summary>
        /// 是否显示连接跳转
        /// </summary>
        [DataMember]
        public bool IsLinkButton { get; set; }
    }
}
