// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      IntakeAndOutputClickData.cs
// 功能描述(Description)：    术中界面，涉及到体征单击OR双击事件的事件信息实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Model.AnesGraphModel
{
    public class IntakeAndOutputClickData
    {
        /// <summary>
        /// 点击的出入量类型
        /// </summary>
        public IntakeAndOutputType InAndOutType { get; set; }

        /// <summary>
        /// 点击时数据
        /// </summary>
        public List<IntakeAndOutputData> Data { get; set; }
    }
}
