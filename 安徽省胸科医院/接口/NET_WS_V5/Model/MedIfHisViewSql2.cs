using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET_WS_V5
{
    public class MedIfHisViewSql2
    {
        /// <summary>
        ///  同步内容
        /// </summary>
        public string AppCode { get; set; }

        /// <summary>
        /// 数据源，如果是webservices 地址，
        /// </summary>
        public string TransName { get; set; }

        /// <summary>
        ///  webservices 方式 配置HIS 
        /// </summary>
        public string SqlText { get; set; }

        /// <summary>
        /// 手麻表名称,
        /// </summary>
        public string MedTableName { get; set; }

        /// <summary>
        /// 对方的存储过程名称，试图名称 或者表名称， 或者websercies 的函数名称
        /// </summary>
        public string DataSourceName {  get;set;}

        /// <summary>
        /// 参数名称 或者where 调解，  数据库方式 为where 调解，webservices 方式 为参数名称
        /// </summary>
        public string SqlPara { get; set; }

        public string Description { get; set; }

       /// <summary>
        ///  ///数据库类型则配置 text 或者，produce,  webservices  
       /// </summary>
        public string CommandType { get; set; }

        public string Memo1 { get; set; }

        public string Memo2 { get; set; }
    }
}
