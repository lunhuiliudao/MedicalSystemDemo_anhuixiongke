// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnalgesicRecordDoc.cs
// 功能描述(Description)：    镇痛记录单对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections.Generic;
using System.Data;

namespace MedicalSystem.Anes.CustomProject
{
    public partial class AnalgesicRecordDoc : CustomBaseDoc
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public AnalgesicRecordDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_OPERATION_ANALGESIC_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_ANALGESIC_MASTER");
            dataSource["MED_OPER_ANALGESIC_MEDICINE"] = DataContext.GetCurrent().GetData("MED_OPER_ANALGESIC_MEDICINE");
            dataSource["MED_OPER_ANALGESIC_TOTAL"] = DataContext.GetCurrent().GetData("MED_OPER_ANALGESIC_TOTAL");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            bool result = this.SaveDocDataPars(dataSource);
            return result;
        }
    }
}
