//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      Class1.cs
//功能描述(Description)：    
//数据表(Tables)：		     
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/8/31 17:00:38
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MedicalSystem.AnesWorkStation.Domain.Report
{
    [DataContract]
    public class ReportInformation : ICloneable
    {
        /// <summary>
        /// 报表基本信息
        /// </summary>
        [DataMember]
        public ReportTitle ReportTitle { get; set; }
        /// <summary>
        /// 报表列
        /// </summary>
        [DataMember]
        public List<ReportColumn> ReportColumnList { get; set; }
        /// <summary>
        /// 报表条件
        /// </summary>
        [DataMember]
        public List<ReportCondition> ReportConditionList { get; set; }

        /// <summary>
        /// 报表附属条件
        /// </summary>
        [DataMember]
        public List<ReportSubCondition> ReportSubConditionList { get; set; }

        /// <summary>
        /// 子报表
        /// </summary>
        [DataMember]
        public List<ReportInformation> SubReportInformationList { get; set; }

        /// <summary>
        /// 图表类型
        /// </summary>
        [DataMember]
        public ReportChartInfo ReportChartInfo { get; set; } = new ReportChartInfo();

        #region 拷贝主体
        /// <summary>
        /// 深度拷贝
        /// </summary>
        /// <returns></returns>
        public ReportInformation DeepClone()
        {
            ReportInformation newObject;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer dcs = new DataContractSerializer(this.GetType());
                dcs.WriteObject(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                newObject = (ReportInformation)dcs.ReadObject(memoryStream);
            }
            return newObject;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
