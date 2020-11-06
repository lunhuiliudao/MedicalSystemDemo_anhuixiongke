// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperCheckGridViewHandler.cs
// 功能描述(Description)：    手术清点单中的表格对应的Handler，用于处理表格个性化的关系
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 手术清点单中的表格对应的Handler
    /// </summary>
    public class OperCheckGridViewHandler : GridViewHandler
    {
        /// <summary>
        /// 将数据源绑定显示到表格上
        /// </summary>
        public override void BindDataToUI(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            control.EnableHeadersVisualStyles = false;
            base.BindDataToUI(control, dataSources);
            control.Rows.Clear();

            // 自动生成列
            control.AutoCreateColumns();
            InitGridSource(control, dataSources);
            for (int j = 0; j < control.Columns.Count; j++)
            {
                control.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            List<MED_QIXIE_QINGDIAN> dataTable = new ModelHandler<MED_QIXIE_QINGDIAN>().FillModel(dataSources["MED_QIXIE_QINGDIAN"]); 
            int rowCount = control.LinesPerPage;
            for (int i = 0; i < rowCount; i++)
            {
                int index = control.Rows.Add();
                control.Rows[i].Tag = i;
            }

            if (dataTable!=null && dataTable.Count > 0)
            {
                foreach (MED_QIXIE_QINGDIAN row in dataTable)
                {
                    if (control.Name == row.TABLETAG) 
                    {
                        if (row.Y_POSITION >= rowCount || row.Y_POSITION < 0)
                        {
                            continue;
                        }

                        int x, y;
                        x = Convert.ToInt16(row.X_POSITION);
                        y = Convert.ToInt16(row.Y_POSITION);
                        control[x, y].Value = row.POSITION_VALUE;
                        control[x, y].Tag = row.POSITION_VALUE; 
                    }
                }
            }
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        private void InitGridSource(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            List<MED_QIXIE_QINGDIAN> dataTable = new ModelHandler<MED_QIXIE_QINGDIAN>().FillModel(dataSources["MED_QIXIE_QINGDIAN"]);
            List<MED_QIXIE_QINGDIAN> qiXierows = null;
            if (dataTable != null && dataTable.Count > 0)
            {
                qiXierows = dataTable.Where(x => x.TABLETAG == control.Name).ToList(); ;
            }

            if (qiXierows == null || qiXierows.Count == 0)
            {
                if (string.IsNullOrEmpty(control.DefaultDatas))
                {
                    return;
                }

                if (dataTable == null)
                {
                    dataTable = CareDocService.ClientInstance.GetOperCheckList(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                               ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,     
                                                                               ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                }

                string defaultDatas = control.DefaultDatas;
                string[] rows = defaultDatas.Split(new string[] { "{}" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < rows.Length; i++)
                {
                    string[] rowdatas = rows[i].Split(new string[] { "[]" }, StringSplitOptions.None);
                    for (int j = 0; j < rowdatas.Length; j++)
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(rowdatas[j])) continue;
                            MED_QIXIE_QINGDIAN row = new MED_QIXIE_QINGDIAN();
                            row.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                            row.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                            row.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                            row.X_POSITION = j;
                            row.Y_POSITION = i;
                            row.POSITION_VALUE = rowdatas[j];
                            row.TABLETAG = control.Name;
                            dataTable.Add(row);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }

                dataSources["MED_QIXIE_QINGDIAN"] = new ModelHandler<MED_QIXIE_QINGDIAN>().FillDataTable(dataTable); 
            }
        }

        /// <summary>
        /// 刷新文书
        /// </summary>
        public override void RefreshData()
        { 
            base.RefreshData();
        }
    }
}
